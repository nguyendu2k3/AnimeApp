using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JikanDotNet;
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
            try
            {
                var searchConfig = new AnimeSearchConfig
                {
                    Page = page,
                    Query = query
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
                TheLoai = ConvertGenres(item.Genres)
            };
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
