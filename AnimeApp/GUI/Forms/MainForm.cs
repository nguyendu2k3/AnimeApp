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
    public partial class MainForm : Form
    {
        private readonly AnimeService _animeService;
        private readonly UserService _userService;
        private readonly WatchlistService _watchlistService;
        private User _currentUser;

        public MainForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            _animeService = new AnimeService();
            _userService = new UserService();
            _watchlistService = new WatchlistService();

            LoadTopAnime();
            LoadAnimeNews();
        }
        private async void LoadTopAnime()
        {
            var animes = await _animeService.GetTopAnime();
            var topAnimes = animes.Take(4).ToList(); // Lấy tối thiểu 4 anime
            for (int i = 0; i < topAnimes.Count; i++)
            {
                var anime = topAnimes[i];
                var pictureBox = this.Controls.Find($"picAnime{i + 1}", true).FirstOrDefault() as PictureBox;
                var titleLabel = this.Controls.Find($"lblTenAnime{i + 1}", true).FirstOrDefault() as Label;
                var statusLabel = this.Controls.Find($"lblTrangThai{i + 1}", true).FirstOrDefault() as Label;

                if (pictureBox != null)
                {
                    pictureBox.ImageLocation = anime.HinhAnh;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                if (titleLabel != null)
                {
                    titleLabel.Text = anime.TenAnime;
                }

                if (statusLabel != null)
                {
                    statusLabel.Text = anime.TrangThai;
                }
            }
        }
        private async void LoadAnimeNews()
        {
            var animes = await _animeService.GetAnimeNews();
            var topAnimes = animes.Take(4).ToList(); // Lấy tối thiểu 4 anime
            for (int i = 0; i < topAnimes.Count; i++)
            {
                var anime = topAnimes[i];
                var pictureBox = this.Controls.Find($"pictureBox{i + 1}", true).FirstOrDefault() as PictureBox;
                var titleLabel = this.Controls.Find($"lblAnimeNew{i + 1}", true).FirstOrDefault() as Label;
                var statusLabel = this.Controls.Find($"lblTrangThaiNew{i + 1}", true).FirstOrDefault() as Label;
                if (pictureBox != null)
                {
                    pictureBox.ImageLocation = anime.HinhAnh;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (titleLabel != null)
                {
                    titleLabel.Text = anime.TenAnime;
                }
                if (statusLabel != null)
                {
                    statusLabel.Text = "Tập" + anime.TapPhim.ToString();
                }
            }
        }
    }
}
