using System;
using System.Collections.Generic;
using System.Data;
using AnimeApp.DAL.Models;
using AnimeApp.DAL.SQLServer;

namespace AnimeApp.BLL
{
    public class WatchlistService
    {
        public void AddToWatchlist(int userId, int animeId, string trangThai)
        {
            bool watched = trangThai == "Completed";
            WatchlistDAO.ThemVaoDanhSachXem(userId, animeId, watched);
        }

        public void UpdateWatchlist(int userId, int animeId, string trangThai)
        {
            bool watched = trangThai == "Completed";
            WatchlistDAO.CapNhatDanhSachXem(userId, animeId, watched);
        }

        public void RemoveFromWatchlist(int userId, int animeId)
        {
            WatchlistDAO.XoaKhoiDanhSachXem(userId, animeId);
        }

        public List<Watchlist> GetWatchlist(int userId)
        {
            DataTable dataTable = WatchlistDAO.LayDanhSachXem(userId);
            List<Watchlist> watchlist = new List<Watchlist>();

            foreach (DataRow row in dataTable.Rows)
            {
                Watchlist item = new Watchlist
                {
                    WatchlistID = Convert.ToInt32(row["WatchlistID"]),
                    UserID = Convert.ToInt32(row["UserId"]),
                    AnimeID = Convert.ToInt32(row["AnimeId"]),
                    TrangThai = Convert.ToBoolean(row["Watched"]) ? "Completed" : "PlanToWatch"
                };
                watchlist.Add(item);
            }

            return watchlist;
        }
    }
}
