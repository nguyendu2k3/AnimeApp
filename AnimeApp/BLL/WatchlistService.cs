using System;
using System.Collections.Generic;
using System.Data;
using AnimeApp.DAL.Models;
using AnimeApp.DAL.SQLServer;

namespace AnimeApp.BLL
{
    public class WatchlistService
    {
        // Các trạng thái của watchlist
        public const string TRANG_THAI_DA_XEM = "Đã xem";
        public const string TRANG_THAI_DANG_XEM = "Đang xem";
        public const string TRANG_THAI_CHUA_XEM = "Chưa xem";

        // Kiểm tra xem trạng thái có hợp lệ không
        private bool LaTrangThaiHopLe(string trangThai)
        {
            return trangThai == TRANG_THAI_DA_XEM ||
                   trangThai == TRANG_THAI_DANG_XEM ||
                   trangThai == TRANG_THAI_CHUA_XEM;
        }

        // Thêm anime vào danh sách xem với trạng thái cụ thể
        public bool ThemAnimeVaoDanhSach(int userId, int animeId, string trangThai)
        {
            try
            {
                // Kiểm tra trạng thái hợp lệ
                if (!LaTrangThaiHopLe(trangThai))
                {
                    throw new ArgumentException("Trạng thái không hợp lệ. Trạng thái phải là: daxem, dangxem hoặc chuaxem");
                }

                // Thêm vào danh sách xem
                WatchlistDAO.ThemVaoDanhSachXem(userId, animeId, trangThai);
                return true;
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                Console.WriteLine($"Lỗi khi thêm anime vào danh sách: {ex.Message}");
                return false;
            }
        }

        // Cập nhật trạng thái xem của một anime trong danh sách
        public bool CapNhatTrangThaiAnime(int userId, int animeId, string trangThai)
        {
            try
            {
                // Kiểm tra trạng thái hợp lệ
                if (!LaTrangThaiHopLe(trangThai))
                {
                    throw new ArgumentException("Trạng thái không hợp lệ. Trạng thái phải là: daxem, dangxem hoặc chuaxem");
                }

                // Cập nhật trạng thái
                WatchlistDAO.CapNhatDanhSachXem(userId, animeId, trangThai);
                return true;
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                Console.WriteLine($"Lỗi khi cập nhật trạng thái anime: {ex.Message}");
                return false;
            }
        }

        // Xóa anime khỏi danh sách xem của người dùng
        public bool XoaAnimeKhoiDanhSach(int userId, int animeId)
        {
            try
            {
                WatchlistDAO.XoaKhoiDanhSachXem(userId, animeId);
                return true;
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                Console.WriteLine($"Lỗi khi xóa anime khỏi danh sách: {ex.Message}");
                return false;
            }
        }
        // Kiểm tra xem anime đã có trong danh sách xem của người dùng chưa
        public bool KiemTraAnimeCoTrongDanhSach(int userId, int animeId)
        {
            DataTable danhSach = DAL.SQLServer.WatchlistDAO.LayDanhSachXem(userId);
            foreach (DataRow row in danhSach.Rows)
            {
                if (Convert.ToInt32(row["AnimeId"]) == animeId)
                {
                    return true;
                }
            }
            return false;
        }
        // Lấy toàn bộ danh sách xem của người dùng
        public DataTable LayDanhSachXem(int userId)
        {
            return WatchlistDAO.LayDanhSachXem(userId);
        }

    }
}
