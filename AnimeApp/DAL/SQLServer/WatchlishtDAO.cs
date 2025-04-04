using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.DAL.SQLServer
{
    public class WatchlistDAO
    {
        // Thêm một anime vào danh sách xem của người dùng.
        public static void ThemVaoDanhSachXem(int userId, int animeId, bool watched)
        {
            string query = "INSERT INTO Watchlist (UserId, AnimeId, Watched) VALUES (@UserId, @AnimeId, @Watched)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@AnimeId", animeId),
                new SqlParameter("@Watched", watched)
            };
            DatabaseConnection.ExecuteNonQuery(query, parameters);
        }

        // Cập nhật trạng thái xem của một anime trong danh sách xem của người dùng.
        public static void CapNhatDanhSachXem(int userId, int animeId, bool watched)
        {
            string query = "UPDATE Watchlist SET Watched = @Watched WHERE UserId = @UserId AND AnimeId = @AnimeId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@AnimeId", animeId),
                new SqlParameter("@Watched", watched)
            };
            DatabaseConnection.ExecuteNonQuery(query, parameters);
        }

        public static void XoaKhoiDanhSachXem(int userId, int animeId)
        {
            string query = "DELETE FROM Watchlist WHERE UserId = @UserId AND AnimeId = @AnimeId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@AnimeId", animeId)
            };
            DatabaseConnection.ExecuteNonQuery(query, parameters);
        }

        public static DataTable LayDanhSachXem(int userId)
        {
            string query = "SELECT * FROM Watchlist WHERE UserId = @UserId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserId", userId)
            };
            return DatabaseConnection.ExecuteQuery(query, parameters);
        }
    }
}
