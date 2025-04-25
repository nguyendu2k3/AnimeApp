using AnimeApp.DAL.API;
using AnimeApp.DAL.Models;
using AnimeApp.DAL.SQLServer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
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
        //public async Task<List<Anime>> SearchAnime(string query, int page = 1)
        //{
        //    //return await _api.SearchAnime(query, page);
        //}
        public async Task<Anime> GetAnimeDetails(int id)
        {
            Anime anime = null;
            try
            {
                anime = _animeDAO.GetAnimeByMyAnimeListId(id);
            }
            catch (SqlException ex)
            {
                // Log the exception
                Console.WriteLine($"SQL Exception: {ex.Message}");
                // Handle specific error for invalid object name
                if (ex.Message.Contains("Invalid object name 'Animes'"))
                {
                    Console.WriteLine("The table 'Animes' does not exist in the database.");
                    // Optionally, you can create the table here or notify the user/admin
                }
                else
                {
                    throw; // Re-throw the exception if it's not related to the table name
                }
            }

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
        public async Task<List<string>> GetAllAnimeGenres()
        {
            return await _api.GetAllAnimeGenres();
        }

        public List<Anime> GetAllAnimes()
        {
            return _animeDAO.GetAllAnimes();
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
        public List<Anime> SearchAnime(String keyword)
        {
            return _animeDAO.TimKiemAnime(keyword);
        }
    }
}
