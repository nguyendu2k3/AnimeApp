using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using AnimeApp.DAL.Models;

namespace AnimeApp.DAL.API
{
    public class MyAnimeListAPI
    {
        private readonly HttpClient _client;
        private const string BaseUrl = "https://api.jikan.moe/v4";
        public MyAnimeListAPI()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("User-Agent", "AnimeApp");
        }
        public async Task<List<Anime>> GetTopAnime(int page = 1)
        {
            string url = $"{BaseUrl}/top/anime?page={page}";
            HttpResponseMessage response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<JikanResponse>(json);
                return ConvertToAnimeList(result.data);
            }

            return new List<Anime>();
        }
        public async Task<List<Anime>> SearchAnime(string query, int page = 1)
        {
            string url = $"{BaseUrl}/anime?q={query}&page={page}";
            HttpResponseMessage response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<JikanResponse>(json);
                return ConvertToAnimeList(result.data);
            }

            return new List<Anime>();
        }
        public async Task<Anime> GetAnimeById(int id)
        {
            string url = $"{BaseUrl}/anime/{id}";
            HttpResponseMessage response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var animeData = JsonConvert.DeserializeObject<JikanAnimeData>(json);
                return ConvertToAnime(animeData.data);
            }

            return null;
        }
        private List<Anime> ConvertToAnimeList(List<JikanAnimeItem> items)
        {
            List<Anime> animeList = new List<Anime>();

            foreach (var item in items)
            {
                animeList.Add(new Anime
                {
                    MyAnimeListID = item.mal_id,
                    TenAnime = item.title,
                    TenAnimeJapanese = item.title_japanese,
                    MoTa = item.synopsis,
                    HinhAnh = item.images.jpg.large_image_url,
                    Kieu = item.type,
                    TapPhim = item.episodes,
                    DanhGia = item.score,
                    NgayPhatHanh = item.aired.from.HasValue ? item.aired.from.Value : DateTime.MinValue,
                    TrangThai = item.status,
                    TheLoai = ConvertGenres(item.genres)
                });
            }

            return animeList;
        }
        private Anime ConvertToAnime(JikanAnimeItem item)
        {
            return new Anime
            {
                MyAnimeListID = item.mal_id,
                TenAnime = item.title,
                TenAnimeJapanese = item.title_japanese,
                MoTa = item.synopsis,
                HinhAnh = item.images.jpg.large_image_url,
                Kieu = item.type,
                TapPhim = item.episodes,
                DanhGia = item.score,
                NgayPhatHanh = item.aired.from.HasValue ? item.aired.from.Value : DateTime.MinValue,
                TrangThai = item.status,
                TheLoai = ConvertGenres(item.genres)
            };
        }
        private List<string> ConvertGenres(List<JikanGenre> genres)
        {
            List<string> genreList = new List<string>();
            foreach (var genre in genres)
            {
                genreList.Add(genre.name);
            }
            return genreList;
        }
        private class JikanResponse
        {
            public List<JikanAnimeItem> data { get; set; }
        }

        private class JikanAnimeData
        {
            public JikanAnimeItem data { get; set; }
        }

        private class JikanAnimeItem
        {
            public int mal_id { get; set; }
            public string title { get; set; }
            public string title_japanese { get; set; }
            public string synopsis { get; set; }
            public JikanImages images { get; set; }
            public string type { get; set; }
            public int episodes { get; set; }
            public float score { get; set; }
            public JikanAired aired { get; set; }
            public string status { get; set; }
            public List<JikanGenre> genres { get; set; }
        }
        private class JikanImages
        {
            public JikanImageUrl jpg { get; set; }
        }

        private class JikanImageUrl
        {
            public string large_image_url { get; set; }
        }

        private class JikanAired
        {
            public DateTime? from { get; set; }
        }

        private class JikanGenre
        {
            public int mal_id { get; set; }
            public string name { get; set; }
        }
    }
}
