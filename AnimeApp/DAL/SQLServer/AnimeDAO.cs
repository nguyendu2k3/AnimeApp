using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using AnimeApp.DAL.Models;

namespace AnimeApp.DAL.SQLServer
{
    public class AnimeDAO
    {
        //Lấy anime từ database theo MyAnimeListId
        public Anime GetAnimeByMyAnimeListId(int myAnimeListId)
        {
            string query = "SELECT * FROM Anime WHERE MyAnimeListID = @MyAnimeListID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MyAnimeListId", myAnimeListId)
            };

            DataTable data = DatabaseConnection.ExecuteQuery(query, parameters);

            if (data.Rows.Count > 0)
            {
                Anime anime = ConvertDataRowToAnime(data.Rows[0]);
                // Lấy thể loại cho anime
                anime.TheLoai = GetGenresForAnime(anime.AnimeID);
                // Lấy studios cho anime
                anime.Studios = GetStudiosForAnime(anime.AnimeID);
                // Lấy danh sách tập phim
                anime.DanhSachTapPhim = GetEpisodesForAnime(anime.AnimeID);

                return anime;
            }
            return null;
        }

        // Thêm anime mới vào database
        public bool ThemAnime(Anime anime)
        {
            try
            {
                // Bắt đầu transaction để đảm bảo tính toàn vẹn dữ liệu
                using (SqlConnection conn = DatabaseConnection.KetNoi())
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Thêm thông tin anime cơ bản
                            string query = @"INSERT INTO Anime (
                                            MyAnimeListID, TenAnime, TenAnimeJapanese, 
                                            MoTa, HinhAnh, Kieu, TapPhim, 
                                            DanhGia, NgayPhatHanh, TrangThai
                                           ) VALUES (
                                            @MyAnimeListID, @TenAnime, @TenAnimeJapanese, 
                                            @MoTa, @HinhAnh, @Kieu, @TapPhim, 
                                            @DanhGia, @NgayPhatHanh, @TrangThai
                                           );
                                           SELECT SCOPE_IDENTITY();";

                            SqlCommand cmd = new SqlCommand(query, conn, transaction);
                            cmd.Parameters.AddRange(new SqlParameter[]
                            {
                                new SqlParameter("@MyAnimeListID", anime.MyAnimeListID),
                                new SqlParameter("@TenAnime", anime.TenAnime),
                                new SqlParameter("@TenAnimeJapanese", (object)anime.TenAnimeJapanese ?? DBNull.Value),
                                new SqlParameter("@MoTa", (object)anime.MoTa ?? DBNull.Value),
                                new SqlParameter("@HinhAnh", (object)anime.HinhAnh ?? DBNull.Value),
                                new SqlParameter("@Kieu", (object)anime.Kieu ?? DBNull.Value),
                                new SqlParameter("@TapPhim", anime.TapPhim),
                                new SqlParameter("@DanhGia", anime.DanhGia),
                                new SqlParameter("@NgayPhatHanh", anime.NgayPhatHanh),
                                new SqlParameter("@TrangThai", (object)anime.TrangThai ?? DBNull.Value)
                            });

                            // Lấy ID của anime vừa thêm
                            int animeId = Convert.ToInt32(cmd.ExecuteScalar());
                            anime.AnimeID = animeId;

                            // 2. Thêm thể loại cho anime
                            if (anime.TheLoai != null && anime.TheLoai.Count > 0)
                            {
                                foreach (string genre in anime.TheLoai)
                                {
                                    InsertAnimeGenre(animeId, genre, conn, transaction);
                                }
                            }

                            // 3. Thêm studios cho anime
                            if (anime.Studios != null && anime.Studios.Count > 0)
                                foreach (string studio in anime.Studios)
                                {
                                    InsertAnimeStudio(animeId, studio, conn, transaction);
                                }

                            // 4. Thêm tập phim cho anime
                            if (anime.DanhSachTapPhim != null && anime.DanhSachTapPhim.Count > 0)
                            {
                                foreach (Episode episode in anime.DanhSachTapPhim)
                                {
                                    InsertAnimeEpisode(animeId, episode, conn, transaction);
                                }
                            }

                            // Commit transaction khi tất cả thành công
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            // Rollback nếu có lỗi
                            transaction.Rollback();
                            Console.WriteLine("Error inserting anime: " + ex.Message);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting anime: " + ex.Message);
                return false;
            }
        }

        // Phương thức hỗ trợ để chuyển đổi từ DataRow sang đối tượng Anime
        private Anime ConvertDataRowToAnime(DataRow row)
        {
            return new Anime
            {
                AnimeID = Convert.ToInt32(row["AnimeID"]),
                MyAnimeListID = Convert.ToInt32(row["MyAnimeListID"]),
                TenAnime = row["TenAnime"].ToString(),
                TenAnimeJapanese = row["TenAnimeJapanese"] != DBNull.Value ? row["TenAnimeJapanese"].ToString() : null,
                MoTa = row["MoTa"] != DBNull.Value ? row["MoTa"].ToString() : null,
                HinhAnh = row["HinhAnh"] != DBNull.Value ? row["HinhAnh"].ToString() : null,
                Kieu = row["Kieu"] != DBNull.Value ? row["Kieu"].ToString() : null,
                TapPhim = Convert.ToInt32(row["TapPhim"]),
                DanhGia = Convert.ToSingle(row["DanhGia"]),
                NgayPhatHanh = row["NgayPhatHanh"] != DBNull.Value ? Convert.ToDateTime(row["NgayPhatHanh"]) : DateTime.MinValue,
                TrangThai = row["TrangThai"] != DBNull.Value ? row["TrangThai"].ToString() : null,
                TheLoai = new List<string>(),
                Studios = new List<string>(),
                DanhSachTapPhim = new List<Episode>()
            };
        }
        // Lấy danh sách thể loại cho anime
        private List<string> GetGenresForAnime(int animeId)
        {
            string query = @"
                SELECT g.TenTheLoai 
                FROM AnimeTheLoai ag
                JOIN TheLoai g ON ag.TheLoaiID = g.TheLoaiID
                WHERE ag.AnimeID = @AnimeID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AnimeID", animeId)
            };

            DataTable data = DatabaseConnection.ExecuteQuery(query, parameters);
            List<string> genres = new List<string>();

            foreach (DataRow row in data.Rows)
            {
                genres.Add(row["TenTheLoai"].ToString());
            }

            return genres;
        }
        // Lấy danh sách studios cho anime
        private List<string> GetStudiosForAnime(int animeId)
        {
            string query = @"
                SELECT g.TenStudio 
                FROM AnimeStudios ag
                JOIN Studios g ON ag.StudioID = g.StudioID
                WHERE ag.AnimeID = @AnimeID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AnimeID", animeId)
            };

            DataTable data = DatabaseConnection.ExecuteQuery(query, parameters);
            List<string> studios = new List<string>();

            foreach (DataRow row in data.Rows)
            {
                studios.Add(row["TenStudio"].ToString());
            }

            return studios;
        }
        // Lấy danh sách tập phim cho anime
        private List<Episode> GetEpisodesForAnime(int animeId)
        {
            string query = "SELECT * FROM Episodes WHERE AnimeID = @AnimeID ORDER BY SoTap";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AnimeID", animeId)
            };

            DataTable data = DatabaseConnection.ExecuteQuery(query, parameters);
            List<Episode> episodes = new List<Episode>();

            foreach (DataRow row in data.Rows)
            {
                Episode episode = new Episode
                {
                    EpisodeID = Convert.ToInt32(row["EpisodeID"]),
                    AnimeID = Convert.ToInt32(row["AnimeID"]),
                    SoTap = Convert.ToInt32(row["SoTap"]),
                    TenTap = row["TenTap"] != DBNull.Value ? row["TenTap"].ToString() : null,
                    LinkPhim = row["LinkPhim"] != DBNull.Value ? row["LinkPhim"].ToString() : null,
                    ThoiLuong = Convert.ToInt32(row["ThoiLuong"])
                };

                episodes.Add(episode);
            }

            return episodes;
        }
        // Thêm thể loại cho anime
        private void InsertAnimeGenre(int animeId, string genre, SqlConnection conn, SqlTransaction transaction)
        {
            // Get the genre ID from the TheLoai table
            string getGenreIdQuery = "SELECT TheLoaiID FROM TheLoai WHERE TenTheLoai = @TenTheLoai";
            SqlCommand getGenreIdCmd = new SqlCommand(getGenreIdQuery, conn, transaction);
            getGenreIdCmd.Parameters.Add(new SqlParameter("@TenTheLoai", genre));
            object result = getGenreIdCmd.ExecuteScalar();

            if (result == null)
            {
                // Insert the genre into TheLoai table if it does not exist
                string insertGenreQuery = "INSERT INTO TheLoai (TenTheLoai) VALUES (@TenTheLoai); SELECT SCOPE_IDENTITY();";
                SqlCommand insertGenreCmd = new SqlCommand(insertGenreQuery, conn, transaction);
                insertGenreCmd.Parameters.Add(new SqlParameter("@TenTheLoai", genre));
                result = insertGenreCmd.ExecuteScalar();
            }

            int genreId = Convert.ToInt32(result);

            // Insert into AnimeTheLoai table
            string query = "INSERT INTO AnimeTheLoai (AnimeID, TheLoaiID) VALUES (@AnimeID, @TheLoaiID)";
            SqlCommand cmd = new SqlCommand(query, conn, transaction);
            cmd.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@AnimeID", animeId),
                new SqlParameter("@TheLoaiID", genreId)
            });

            cmd.ExecuteNonQuery();
        }
        // Thêm studio cho anime
        private void InsertAnimeStudio(int animeId, string studio, SqlConnection conn, SqlTransaction transaction)
        {
            // Get the studio ID from the Studio table
            string getStudioIdQuery = "SELECT StudioID FROM Studios WHERE TenStudio = @TenStudio";
            SqlCommand getStudioIdCmd = new SqlCommand(getStudioIdQuery, conn, transaction);
            getStudioIdCmd.Parameters.Add(new SqlParameter("@TenStudio", studio));
            object result = getStudioIdCmd.ExecuteScalar();

            if (result == null)
            {
                // Insert the studio into Studio table if it does not exist
                string insertStudioQuery = "INSERT INTO Studios (TenStudio) VALUES (@TenStudio); SELECT SCOPE_IDENTITY();";
                SqlCommand insertStudioCmd = new SqlCommand(insertStudioQuery, conn, transaction);
                insertStudioCmd.Parameters.Add(new SqlParameter("@TenStudio", studio));
                result = insertStudioCmd.ExecuteScalar();
            }

            int studioId = Convert.ToInt32(result);

            // Insert into AnimeStudios table
            string query = "INSERT INTO AnimeStudios (AnimeID, StudioID) VALUES (@AnimeID, @StudioID)";
            SqlCommand cmd = new SqlCommand(query, conn, transaction);
            cmd.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@AnimeID", animeId),
                new SqlParameter("@StudioID", studioId)
            });

            cmd.ExecuteNonQuery();
        }
        // Thêm tập phim cho anime
        private void InsertAnimeEpisode(int animeId, Episode episode, SqlConnection conn, SqlTransaction transaction)
        {
            string query = @"INSERT INTO Episodes (
                            AnimeID, SoTap, TenTap, 
                            LinkPhim, ThoiLuong
                           ) VALUES (
                            @AnimeID, @SoTap, @TenTap, 
                            @LinkPhim, @ThoiLuong
                           )";

            SqlCommand cmd = new SqlCommand(query, conn, transaction);
            cmd.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@AnimeID", animeId),
                new SqlParameter("@SoTap", episode.SoTap),
                new SqlParameter("@TenTap", (object)episode.TenTap ?? DBNull.Value),
                new SqlParameter("@LinkPhim", (object)episode.LinkPhim ?? DBNull.Value),
                new SqlParameter("@ThoiLuong", (object)episode.ThoiLuong ?? DBNull.Value)
            });

            cmd.ExecuteNonQuery();
        }
        // Cập nhật thông tin anime
        public bool CapNhatAnime(Anime anime)
        {
            try
            {
                // Bắt đầu transaction để đảm bảo tính toàn vẹn dữ liệu
                using (SqlConnection conn = DatabaseConnection.KetNoi())
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Cập nhật thông tin anime cơ bản
                            string query = @"UPDATE Anime SET 
                                            MyAnimeListID = @MyAnimeListID,
                                            TenAnime = @TenAnime, 
                                            TenAnimeJapanese = @TenAnimeJapanese,
                                            MoTa = @MoTa,
                                            HinhAnh = @HinhAnh,
                                            Kieu = @Kieu,
                                            TapPhim = @TapPhim,
                                            DanhGia = @DanhGia,
                                            NgayPhatHanh = @NgayPhatHanh,
                                            TrangThai = @TrangThai
                                            WHERE AnimeID = @AnimeID";

                            SqlCommand cmd = new SqlCommand(query, conn, transaction);
                            cmd.Parameters.AddRange(new SqlParameter[]
                            {
                                new SqlParameter("@AnimeID", anime.AnimeID),
                                new SqlParameter("@MyAnimeListID", anime.MyAnimeListID),
                                new SqlParameter("@TenAnime", anime.TenAnime),
                                new SqlParameter("@TenAnimeJapanese", (object)anime.TenAnimeJapanese ?? DBNull.Value),
                                new SqlParameter("@MoTa", (object)anime.MoTa ?? DBNull.Value),
                                new SqlParameter("@HinhAnh", (object)anime.HinhAnh ?? DBNull.Value),
                                new SqlParameter("@Kieu", (object)anime.Kieu ?? DBNull.Value),
                                new SqlParameter("@TapPhim", anime.TapPhim),
                                new SqlParameter("@DanhGia", anime.DanhGia),
                                new SqlParameter("@NgayPhatHanh", anime.NgayPhatHanh),
                                new SqlParameter("@TrangThai", (object)anime.TrangThai ?? DBNull.Value)
                            });

                            cmd.ExecuteNonQuery();

                            // 2. Xóa và cập nhật lại thể loại cho anime
                            DeleteAnimeGenres(anime.AnimeID, conn, transaction);
                            if (anime.TheLoai != null && anime.TheLoai.Count > 0)
                            {
                                foreach (string genre in anime.TheLoai)
                                {
                                    InsertAnimeGenre(anime.AnimeID, genre, conn, transaction);
                                }
                            }

                            // 3. Xóa và cập nhật lại studios cho anime
                            DeleteAnimeStudios(anime.AnimeID, conn, transaction);
                            if (anime.Studios != null && anime.Studios.Count > 0)
                            {
                                foreach (string studio in anime.Studios)
                                {
                                    InsertAnimeStudio(anime.AnimeID, studio, conn, transaction);
                                }
                            }

                            // 4. Xóa và cập nhật lại tập phim cho anime
                            DeleteAnimeEpisodes(anime.AnimeID, conn, transaction);
                            if (anime.DanhSachTapPhim != null && anime.DanhSachTapPhim.Count > 0)
                            {
                                foreach (Episode episode in anime.DanhSachTapPhim)
                                {
                                    InsertAnimeEpisode(anime.AnimeID, episode, conn, transaction);
                                }
                            }

                            // Commit transaction khi tất cả thành công
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            // Rollback nếu có lỗi
                            transaction.Rollback();
                            Console.WriteLine("Error updating anime: " + ex.Message);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating anime: " + ex.Message);
                return false;
            }
        }
        // Xóa anime
        public bool XoaAnime(int animeId)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.KetNoi())
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Delete all genres related to the anime
                            DeleteAnimeGenres(animeId, conn, transaction);

                            // 2. Delete all studios related to the anime
                            DeleteAnimeStudios(animeId, conn, transaction);

                            // 3. Delete all episodes related to the anime
                            DeleteAnimeEpisodes(animeId, conn, transaction);

                            // 4. Delete anime from the user's watchlist (if the table exists)
                            try
                            {
                                string deleteWatchlistQuery = "DELETE FROM UserWatchlist WHERE AnimeID = @AnimeID";
                                SqlCommand deleteWatchlistCmd = new SqlCommand(deleteWatchlistQuery, conn, transaction);
                                deleteWatchlistCmd.Parameters.Add(new SqlParameter("@AnimeID", animeId));
                                deleteWatchlistCmd.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                Console.WriteLine($"Warning: Could not delete from UserWatchlist. {ex.Message}");
                            }

                            // 5. Delete the anime itself
                            string deleteAnimeQuery = "DELETE FROM Anime WHERE AnimeID = @AnimeID";
                            SqlCommand deleteAnimeCmd = new SqlCommand(deleteAnimeQuery, conn, transaction);
                            deleteAnimeCmd.Parameters.Add(new SqlParameter("@AnimeID", animeId));
                            int rowsAffected = deleteAnimeCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                transaction.Commit();
                                return true;
                            }
                            else
                            {
                                transaction.Rollback();
                                Console.WriteLine($"No rows affected for AnimeID: {animeId}");
                                return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"Error deleting anime: {ex.Message}");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting anime: {ex.Message}");
                return false;
            }
        }
        // Lấy tất cả anime từ database
        public List<Anime> GetAllAnimes()
        {
            string query = "SELECT * FROM Anime";
            DataTable data = DatabaseConnection.ExecuteQuery(query);
            List<Anime> animes = new List<Anime>();

            foreach (DataRow row in data.Rows)
            {
                Anime anime = ConvertDataRowToAnime(row);
                // Lấy thể loại cho anime
                anime.TheLoai = GetGenresForAnime(anime.AnimeID);
                // Lấy studios cho anime
                anime.Studios = GetStudiosForAnime(anime.AnimeID);
                // Lấy danh sách tập phim
                anime.DanhSachTapPhim = GetEpisodesForAnime(anime.AnimeID);

                animes.Add(anime);
            }

            return animes;
        }
        // Xóa tất cả thể loại của anime
        private void DeleteAnimeGenres(int animeId, SqlConnection conn, SqlTransaction transaction)
        {
            string query = "DELETE FROM AnimeTheLoai WHERE AnimeID = @AnimeID";
            SqlCommand cmd = new SqlCommand(query, conn, transaction);
            cmd.Parameters.Add(new SqlParameter("@AnimeID", animeId));
            cmd.ExecuteNonQuery();
        }
        // Xóa tất cả studios của anime
        private void DeleteAnimeStudios(int animeId, SqlConnection conn, SqlTransaction transaction)
        {
            string query = "DELETE FROM AnimeStudios WHERE AnimeID = @AnimeID";
            SqlCommand cmd = new SqlCommand(query, conn, transaction);
            cmd.Parameters.Add(new SqlParameter("@AnimeID", animeId));
            cmd.ExecuteNonQuery();
        }
        // Xóa tất cả tập phim của anime
        private void DeleteAnimeEpisodes(int animeId, SqlConnection conn, SqlTransaction transaction)
        {
            string query = "DELETE FROM Episodes WHERE AnimeID = @AnimeID";
            SqlCommand cmd = new SqlCommand(query, conn, transaction);
            cmd.Parameters.Add(new SqlParameter("@AnimeID", animeId));
            cmd.ExecuteNonQuery();
        }
        //CheckLap
        public bool AnimeExists(int myAnimeListID)
        {
            try
            {
                using (SqlConnection connection = DatabaseConnection.KetNoi())
                {
                    connection.Open();

                    string query = "SELECT COUNT(1) FROM Anime WHERE MyAnimeListID = @MyAnimeListID";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MyAnimeListID", myAnimeListID);

                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking anime existence: {ex.Message}");
                return false;
            }
        }

        public List<Anime> TimKiemAnime(string keyword)
        {
            try
            {
                // SQL query to search for anime by name, Japanese name, or MyAnimeListID
                string query = @"SELECT * FROM Anime 
                         WHERE TenAnime LIKE @Keyword 
                         OR TenAnimeJapanese LIKE @Keyword 
                         OR CAST(MyAnimeListID AS NVARCHAR) LIKE @Keyword";

                // Define the parameter for the query
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@Keyword", $"%{keyword}%")
                };

                // Execute the query and get the result as a DataTable
                DataTable data = DatabaseConnection.ExecuteQuery(query, parameters);
                List<Anime> animes = new List<Anime>();

                // Convert each DataRow to an Anime object
                foreach (DataRow row in data.Rows)
                {
                    Anime anime = ConvertDataRowToAnime(row);

                    // Fetch related genres, studios, and episodes for the anime
                    anime.TheLoai = GetGenresForAnime(anime.AnimeID);
                    anime.Studios = GetStudiosForAnime(anime.AnimeID);
                    anime.DanhSachTapPhim = GetEpisodesForAnime(anime.AnimeID);

                    animes.Add(anime);
                }

                return animes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching anime: {ex.Message}");
                return new List<Anime>();
            }
        }
    }
}