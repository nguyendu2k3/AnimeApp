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
        // Lấy anime theo MyAnimeListId
        public Anime GetAnimeByMyAnimeListId(int myAnimeListId)
        {
            string query = "SELECT * FROM Animes WHERE MyAnimeListID = @MyAnimeListID";
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
        // Lấy anime theo ID trong database
        public Anime GetAnimeById(int animeId)
        {
            string query = "SELECT * FROM Animes WHERE AnimeID = @AnimeID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AnimeID", animeId)
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
                            string query = @"INSERT INTO Animes (
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
                            {
                                foreach (string studio in anime.Studios)
                                {
                                    InsertAnimeStudio(animeId, studio, conn, transaction);
                                }
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
                            string query = @"UPDATE Animes SET 
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
                // Bắt đầu transaction để đảm bảo tính toàn vẹn dữ liệu
                using (SqlConnection conn = DatabaseConnection.KetNoi())
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Xóa tất cả thể loại liên quan đến anime
                            DeleteAnimeGenres(animeId, conn, transaction);

                            // 2. Xóa tất cả studios liên quan đến anime
                            DeleteAnimeStudios(animeId, conn, transaction);

                            // 3. Xóa tất cả tập phim liên quan đến anime
                            DeleteAnimeEpisodes(animeId, conn, transaction);

                            // 4. Xóa anime khỏi danh sách xem của người dùng
                            string deleteWatchlistQuery = "DELETE FROM UserWatchlist WHERE AnimeID = @AnimeID";
                            SqlCommand deleteWatchlistCmd = new SqlCommand(deleteWatchlistQuery, conn, transaction);
                            deleteWatchlistCmd.Parameters.Add(new SqlParameter("@AnimeID", animeId));
                            deleteWatchlistCmd.ExecuteNonQuery();

                            // 5. Xóa anime
                            string deleteAnimeQuery = "DELETE FROM Animes WHERE AnimeID = @AnimeID";
                            SqlCommand deleteAnimeCmd = new SqlCommand(deleteAnimeQuery, conn, transaction);
                            deleteAnimeCmd.Parameters.Add(new SqlParameter("@AnimeID", animeId));
                            deleteAnimeCmd.ExecuteNonQuery();

                            // Commit transaction khi tất cả thành công
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            // Rollback nếu có lỗi
                            transaction.Rollback();
                            Console.WriteLine("Error deleting anime: " + ex.Message);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting anime: " + ex.Message);
                return false;
            }
        }
        // Lấy tất cả anime từ database
        public List<Anime> GetAllAnimes()
        {
            string query = "SELECT * FROM Animes";
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
            string query = "SELECT TenTheLoai FROM AnimeGenres WHERE AnimeID = @AnimeID";
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
            string query = "SELECT TenStudio FROM AnimeStudios WHERE AnimeID = @AnimeID";
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
            string query = "INSERT INTO AnimeGenres (AnimeID, TenTheLoai) VALUES (@AnimeID, @TenTheLoai)";
            SqlCommand cmd = new SqlCommand(query, conn, transaction);
            cmd.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@AnimeID", animeId),
                new SqlParameter("@TenTheLoai", genre)
            });

            cmd.ExecuteNonQuery();
        }
        // Thêm studio cho anime
        private void InsertAnimeStudio(int animeId, string studio, SqlConnection conn, SqlTransaction transaction)
        {
            string query = "INSERT INTO AnimeStudios (AnimeID, TenStudio) VALUES (@AnimeID, @TenStudio)";
            SqlCommand cmd = new SqlCommand(query, conn, transaction);
            cmd.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@AnimeID", animeId),
                new SqlParameter("@TenStudio", studio)
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
        // Xóa tất cả thể loại của anime
        private void DeleteAnimeGenres(int animeId, SqlConnection conn, SqlTransaction transaction)
        {
            string query = "DELETE FROM AnimeGenres WHERE AnimeID = @AnimeID";
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
    }
}