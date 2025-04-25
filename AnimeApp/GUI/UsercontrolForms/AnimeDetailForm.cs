using AnimeApp.BLL;
using AnimeApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace AnimeApp.GUI.Forms
{
    public partial class AnimeDetailForm : Form
    {
        private int _animeID;
        private User _currentUser;
        private readonly AnimeService _animeService;
        private readonly WatchlistService _watchlistService;

        public AnimeDetailForm(int animeID, User currentUser)
        {
            _animeID = animeID;
            _currentUser = currentUser;
            _animeService = new AnimeService();
            _watchlistService = new WatchlistService();
            InitializeComponent();
            LoadAnimeDetails(_animeID);
            
        }

        private async void LoadAnimeDetails(int animeId)
        {
            var anime = await _animeService.GetAnimeDetails(animeId);
            if (anime != null)
            {
                // Hiển thị thông tin chi tiết của anime
                picAnimeDetail.ImageLocation = anime.HinhAnh;
                TenAnimeDetail.Text = anime.TenAnime;
                lblTenAnimeJapanDeltail.Text = anime.TenAnimeJapanese;
                SoTap.Text = anime.TapPhim.ToString();
                TheLoai.Text = string.Join(", ", anime.TheLoai);
                TrangThai.Text = anime.TrangThai;
                NgayPhatHanh.Text = anime.NgayPhatHanh.ToString();
                Studio.Text = string.Join(", ", anime.Studios);
                DanhGia.Text = anime.DanhGia.ToString();
                txtMoTa.Text = anime.MoTa;
            }
        }

        

        private void btnThemVaoDanhSach_Click(object sender, EventArgs e)
        {
            
            string defaultWatchStatus = WatchlistService.TRANG_THAI_CHUA_XEM; 

           
            bool result = _watchlistService.ThemAnimeVaoDanhSach(_currentUser.UserID, _animeID, defaultWatchStatus);
            if (result)
            {
                
                MessageBox.Show("Anime đã có trong danh sách xem của bạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CheckAnimeInWatchlist();
            }
            else
            {
                // Thêm anime
                _watchlistService.ThemAnimeVaoDanhSach(_currentUser.UserID, _animeID, defaultWatchStatus);

               
                MessageBox.Show("Anime đã được thêm vào danh sách xem của bạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void CheckAnimeInWatchlist()
        {
            // Check if the anime is in the user's watchlist
            DataTable watchlist = _watchlistService.LayDanhSachXem(_currentUser.UserID);
            bool isAnimeInWatchlist = watchlist.AsEnumerable().Any(row => Convert.ToInt32(row["AnimeId"]) == _animeID);

            if (isAnimeInWatchlist)
            {
                // Change button to "Remove from Watchlist"
                btnThemVaoDanhSach.Text = "Xóa khỏi danh sách";
                btnThemVaoDanhSach.Click -= btnThemVaoDanhSach_Click;
                btnThemVaoDanhSach.Click += btnXoaKhoiDanhSach_Click;
            }
            else
            {
                // Set button to "Add to Watchlist"
                btnThemVaoDanhSach.Text = "Thêm vào danh sách";
                btnThemVaoDanhSach.Click -= btnXoaKhoiDanhSach_Click;
                btnThemVaoDanhSach.Click += btnThemVaoDanhSach_Click;
            }
        }
        private void btnXoaKhoiDanhSach_Click(object sender, EventArgs e)
        {
            // Remove anime from watchlist
            bool result = _watchlistService.XoaAnimeKhoiDanhSach(_currentUser.UserID, _animeID);
            if (result)
            {
                MessageBox.Show("Anime đã được xóa khỏi danh sách xem của bạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CheckAnimeInWatchlist(); // Update the button
            }
            else
            {
                MessageBox.Show("Lỗi khi xóa anime khỏi danh sách xem.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
