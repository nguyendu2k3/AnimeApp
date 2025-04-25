using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeApp.DAL.SQLServer;
using JikanDotNet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using JikanAnime = JikanDotNet.Anime;
using LocalAnime = AnimeApp.DAL.Models.Anime;

namespace AnimeApp.DAL.API
{
    public class MyAnimeListAPI
    {
        private readonly IJikan _jikan;

        public MyAnimeListAPI()
        {
            _jikan = new Jikan();
        }

        public async Task<List<LocalAnime>> GetTopAnime(int page = 1)
        {
            try
            {
                var topAnime = await _jikan.GetTopAnimeAsync(page);
               
                return ConvertToAnimeList(topAnime.Data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting top anime: {ex.Message}");
                return new List<LocalAnime>();
            }
        }
        public async Task<List<LocalAnime>> GetTopAnimeBatch(int startPage, int numberOfPages)
        {
            List<LocalAnime> batchAnime = new List<LocalAnime>();
            AnimeDAO animeDAO = new AnimeDAO(); // Create an instance of AnimeDAO

            try
            {
                for (int page = startPage; page < startPage + numberOfPages; page++)
                {
                    try
                    {
                        // Thêm delay để tránh rate limit
                        if (page > startPage)
                        {
                            await Task.Delay(4000); // Đợi 4 giây giữa các request
                        }

                        var topAnime = await _jikan.GetTopAnimeAsync(page);
                        var animeList = ConvertToAnimeList(topAnime.Data);

                        // Thêm anime vào batch
                        batchAnime.AddRange(animeList);

                        Console.WriteLine($"Fetched page {page} successfully with {animeList.Count} anime");

                        // Dừng nếu trang không còn đủ dữ liệu
                        if (animeList.Count == 0 || animeList.Count < 25)
                        {
                            Console.WriteLine("Reached end of data");
                            break;
                        }
                    }
                    catch (JikanDotNet.Exceptions.JikanRequestException ex)
                    {
                        Console.WriteLine($"Error on page {page}: {ex.Message}");

                        if (ex.Message.Contains("429"))
                        {
                            // Nếu gặp rate limit, đợi lâu hơn và thử lại
                            Console.WriteLine("Rate limit hit, waiting longer...");
                            await Task.Delay(15000); // Đợi 15 giây

                            // Thử lại trang này
                            page--;
                        }
                        else
                        {
                            // Nếu là lỗi khác, tiếp tục với trang tiếp theo
                            continue;
                        }
                    }
                }

                // Lưu batch vào cơ sở dữ liệu
                foreach (var anime in batchAnime)
                {
                    // Kiểm tra xem anime đã tồn tại trong DB chưa
                    if (!animeDAO.AnimeExists(anime.MyAnimeListID))
                    {
                        var result = animeDAO.ThemAnime(anime);
                        if (!result)
                        {
                            Console.WriteLine($"Failed to save anime with ID: {anime.MyAnimeListID}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Anime with ID: {anime.MyAnimeListID} already exists, skipping");
                    }
                }

                return batchAnime;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting anime batch: {ex.Message}");
                return batchAnime;
            }
        }

        public async Task<List<string>> GetAllAnimeGenres()
        {
            try
            {
                var genres = await _jikan.GetAnimeGenresAsync();
                return genres.Data.Select(g => g.Name).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting anime genres: {ex.Message}");
                return new List<string>();
            }
        }
        public async Task<List<LocalAnime>> GetAnimeNews()
        {
            try
            {
                var watchEpisodes = await _jikan.GetWatchRecentEpisodesAsync();
                return ConvertWatchEpisodesToAnimeList(watchEpisodes.Data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting anime news: {ex.Message}");
                return new List<LocalAnime>();
            }
        }

        public async Task<List<LocalAnime>> SearchAnime(string query, int page = 1)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return new List<LocalAnime>();
            }

            try
            {
                var searchConfig = new AnimeSearchConfig
                {
                    Page = page,
                    Query = query.Trim()
                };

                var searchResult = await _jikan.SearchAnimeAsync(searchConfig);
                return ConvertToAnimeList(searchResult.Data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching anime: {ex.Message}");
                return new List<LocalAnime>();
            }
        }
        public async Task<List<LocalAnime>> SearchAnimeTheoDieuKien(
        string status = null,
        string genre = null,
        string season = null,
        int year = 0,
        int page = 1,
        string order_by = "popularity",
        string sort = "desc")
        {
            try
            {
                // Kiểm tra và xử lý các tham số đầu vào
                if (page < 1) page = 1;

                // Tạo danh sách các tham số query
                var queryParams = new List<string>();

                // Thêm tham số cơ bản
                queryParams.Add($"page={page}");
                queryParams.Add("limit=24");

                // QUAN TRỌNG: Thêm ít nhất một bộ lọc khác ngoài page và limit
                bool hasFilter = false;

                // Xử lý trạng thái
                //Tất cả
                //Đang phát sóng
                //Hoàn Thành
                //Sắp phát sóng
                string cleanStatus = status.Trim().ToLower();
                string apiStatus;

                if (!string.IsNullOrEmpty(status))
                {
                    

                    // In ra để debug
                    Console.WriteLine($"[DEBUG] CleanStatus sau khi ToLower(): '{cleanStatus}'");

                    // Kiểm tra CHÍNH XÁC từng trường hợp
                    if (cleanStatus.Contains("đang phát") || cleanStatus.Contains("dang phat"))
                    {
                        apiStatus = "airing";
                        Console.WriteLine("[DEBUG] Detected: đang phát sóng -> airing");
                    }
                    else if (cleanStatus.Contains("hoàn thành") || cleanStatus.Contains("hoan thanh"))
                    {
                        apiStatus = "complete";
                        Console.WriteLine("[DEBUG] Detected: hoàn thành -> complete");
                    }
                    else if (cleanStatus.Contains("sắp phát") || cleanStatus.Contains("sap phat"))
                    {
                        apiStatus = "upcoming";
                        Console.WriteLine("[DEBUG] Detected: sắp phát sóng -> upcoming");
                    }
                    else if (cleanStatus == "complete" || cleanStatus == "completed")
                    {
                        apiStatus = "complete";
                    }
                    else if (cleanStatus == "airing")
                    {
                        apiStatus = "airing";
                    }
                    else if (cleanStatus == "upcoming")
                    {
                        apiStatus = "upcoming";
                    }
                    else
                    {
                        // Mặc định với trạng thái không xác định
                        apiStatus = "airing";
                        Console.WriteLine("[DEBUG] Unknown status - defaulting to airing");
                    }

                    queryParams.Add($"status={apiStatus}");
                    hasFilter = true;
                    Console.WriteLine($"[DEBUG] Status: '{status}' -> '{apiStatus}'");
                }
                if (!string.IsNullOrEmpty(genre))
                {
                    queryParams.Add($"genres={Uri.EscapeDataString(genre)}");
                    hasFilter = true;
                    Console.WriteLine($"[DEBUG] Genre: '{genre}'");
                }
                // Xử lý mùa phát hành
                //Tất cả
                //Xuân
                //Hạ
                //Thu
                //Đông
                if (!string.IsNullOrEmpty(season))
                {
                    string cleanSeason = season.Trim().ToLower();
                    string apiSeason;
                    if (cleanSeason == "Xuân") apiSeason = "spring";
                    else if (cleanSeason == "Hạ") apiSeason = "summer";
                    else if (cleanSeason == "Thu") apiSeason = "fall";
                    else if (cleanSeason == "Đông") apiSeason = "winter";
                    else apiSeason = cleanSeason; // Giữ nguyên nếu đã là tiếng Anh

                    queryParams.Add($"season={apiSeason}");
                    hasFilter = true;
                    Console.WriteLine($"[DEBUG] Season: '{season}' -> '{apiSeason}'");
                }
                // Xử lý năm
                if (year > 0)
                {
                    // Xử lý năm bằng start_date và end_date
                    queryParams.Add($"start_date={year}-01-01");
                    queryParams.Add($"end_date={year}-12-31");
                    hasFilter = true;
                }

                // Nếu không có bộ lọc nào, PHẢI thêm ít nhất một bộ lọc
                if (!hasFilter)
                {
                    // Mặc định lấy anime đang phát sóng
                    queryParams.Add("status=airing");
                }
                // Xử lý sắp xếp
                queryParams.Add($"order_by={Uri.EscapeDataString(order_by.ToLower())}");
                queryParams.Add($"sort={Uri.EscapeDataString(sort.ToLower())}");

                // Tạo chuỗi truy vấn
                string query = string.Join("&", queryParams);

                // Log thông tin truy vấn
                Console.WriteLine($"[DEBUG] API Query: {query}");

                // Gọi API
                var searchResult = await _jikan.SearchAnimeAsync(query);

                // Kiểm tra kết quả
                if (searchResult?.Data == null)
                {
                    Console.WriteLine("[ERROR] API trả về kết quả null");
                    return new List<LocalAnime>();
                }

                // Log kết quả
                int resultCount = searchResult.Data.Count();
                Console.WriteLine($"[INFO] Tìm thấy {resultCount} anime");

                // Chuyển đổi kết quả
                return ConvertToAnimeList(searchResult.Data);


            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Lỗi khi tìm kiếm anime: {ex.Message}");
                Console.WriteLine($"[ERROR] Stack trace: {ex.StackTrace}");
                return new List<LocalAnime>();
            }
        }
       public async Task<LocalAnime> GetAnimeById(int id)
        {
            try
            {
                var animeData = await _jikan.GetAnimeAsync(id);
                return ConvertToAnime(animeData.Data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting anime by ID: {ex.Message}");
                return null;
            }
        }

        private List<LocalAnime> ConvertToAnimeList(ICollection<JikanAnime> items)
        {
            var animeList = new List<LocalAnime>();

            foreach (var item in items)
            {
                animeList.Add(ConvertToAnime(item));
            }

            return animeList;
        }

        private LocalAnime ConvertToAnime(JikanAnime item)
        {
            return new LocalAnime
            {
                MyAnimeListID = item.MalId.HasValue ? (int)item.MalId.Value : 0,
                TenAnime = item.Titles?.FirstOrDefault(t => t.Type == "Default")?.Title ?? string.Empty, // Use Titles property
                TenAnimeJapanese = item.Titles?.FirstOrDefault(t => t.Type == "Japanese")?.Title ?? string.Empty, // Use Titles property
                MoTa = item.Synopsis ?? string.Empty,
                HinhAnh = item.Images?.JPG?.LargeImageUrl ?? string.Empty,
                Kieu = item.Type?.ToString() ?? string.Empty,
                TapPhim = item.Episodes ?? 0,
                DanhGia = (float)(item.Score ?? 0), 
                NgayPhatHanh = item.Aired?.From ?? DateTime.MinValue,
                TrangThai = item.Status?.ToString() ?? string.Empty,
                TheLoai = ConvertGenres(item.Genres),
                Studios = ConvertStudios(item.Studios)
            };
        }
        private List<string> ConvertStudios(ICollection<MalUrl> studios)
        {
            var studioList = new List<string>();
            if (studios != null)
            {
                foreach (var studio in studios)
                {
                    studioList.Add(studio.Name);
                }
            }
            return studioList;
        }

        private List<string> ConvertGenres(ICollection<MalUrl> genres)
        {
            var genreList = new List<string>();
            if (genres != null)
            {
                foreach (var genre in genres)
                {
                    genreList.Add(genre.Name);
                }
            }
            return genreList;
        }

        private List<LocalAnime> ConvertWatchEpisodesToAnimeList(ICollection<WatchEpisode> watchEpisodes)
        {
            var animeList = new List<LocalAnime>();

            foreach (var episode in watchEpisodes)
            {
                var entry = episode.Entry;
                foreach (var ep in episode.Episodes)
                {
                    animeList.Add(new LocalAnime
                    {
                        MyAnimeListID = (int)entry.MalId,
                        TenAnime = entry.Title ?? string.Empty,
                        HinhAnh = entry.Images?.JPG?.LargeImageUrl ?? string.Empty,
                        MoTa = $"Episode: {ep.Title}\nURL: {ep.Url}\nPremium: {(ep.Premium ?? false ? "Yes" : "No")}", // Handle nullable bool
                        TrangThai = ep.Premium ?? false ? "Premium" : "Free",
                        TenAnimeJapanese = string.Empty,
                        Kieu = "Episode",
                        TapPhim = (int)ep.MalId, 
                        DanhGia = 0,
                        NgayPhatHanh = DateTime.UtcNow,
                        TheLoai = new List<string>()
                    });
                }
            }

            return animeList;
        }

        public async Task<List<AnimeEpisode>> GetLatestEpisodes(int page = 1)
        {
            try
            {
                var watchEpisodes = await _jikan.GetWatchRecentEpisodesAsync();
                return ConvertToEpisodeList(watchEpisodes.Data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting latest episodes: {ex.Message}");
                return new List<AnimeEpisode>();
            }
        }

        private List<AnimeEpisode> ConvertToEpisodeList(ICollection<WatchEpisode> watchEpisodes)
        {
            var episodeList = new List<AnimeEpisode>();

            foreach (var episode in watchEpisodes)
            {
                var entry = episode.Entry;
                foreach (var ep in episode.Episodes)
                {
                    episodeList.Add(new AnimeEpisode
                    {
                        MalId = (int)entry.MalId,
                        Title = entry.Title ?? string.Empty,
                        EpisodeTitle = ep.Title,
                        Url = ep.Url,
                        IsPremium = ep.Premium ?? false, 
                        ThumbnailUrl = entry.Images?.JPG?.LargeImageUrl,
                        IsRegionLocked = episode.RegionLocked
                    });
                }
            }

            return episodeList;
        }
    }
    public class AnimeEpisode
    {
        public long MalId { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string TitleJapanese { get; set; }
        public string TitleRomanji { get; set; }
        public int? Duration { get; set; }
        public DateTime? Aired { get; set; }
        public bool? Filler { get; set; }
        public bool? Recap { get; set; }
        public string Synopsis { get; set; }
        public string ForumUrl { get; set; }
        public string ThumbnailUrl { get; set; } 
        public bool? IsRegionLocked { get; set; }
        public bool? IsPremium { get; set; }
        public string EpisodeTitle { get; set; }
    }
}
