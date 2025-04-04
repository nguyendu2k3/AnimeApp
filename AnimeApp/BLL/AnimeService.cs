using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnimeApp.DAL.Models;
using AnimeApp.DAL.API;
using AnimeApp.DAL.SQLServer;
namespace AnimeApp.BLL
{
    public class AnimeService
    {
        private readonly MyAnimeListAPI _api;
        private readonly AnimeDAO _animeDAO;
        public AnimeService()
        {
            _api = new MyAnimeListAPI();
            _animeDAO = new AnimeDAO();
        }
        public async Task<List<Anime>> GetTopAnime(int page = 1)
        {
            return await _api.GetTopAnime(page);
        }
        public async Task<List<Anime>> GetAnimeNews()
        {
            
            return await _api.GetAnimeNews();
        }
        public async Task<List<Anime>> SearchAnime(string query, int page = 1)
        {
            return await _api.SearchAnime(query, page);
        }
        public async Task<Anime> GetAnimeDetails(int id)
        {
            Anime anime = _animeDAO.GetAnimeByMyAnimeListId(id);
            if (anime == null)
            {
                // If not found in database, fetch from API
                anime = await _api.GetAnimeById(id);

                // Save to database for future references
                if (anime != null)
                {
                    _animeDAO.ThemAnime(anime);
                }
            }
            return anime;
        }
        public bool ThemAnime(Anime anime)
        {
            return _animeDAO.ThemAnime(anime);
        }
        public bool CapNhatAnime(Anime anime)
        {
            return _animeDAO.CapNhatAnime(anime);
        }
        public bool XoaAnime(int animeID)
        {
            return _animeDAO.XoaAnime(animeID);
        }
    }
}
