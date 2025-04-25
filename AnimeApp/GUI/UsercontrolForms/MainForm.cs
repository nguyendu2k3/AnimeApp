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
            OpenChildForm(new HomeForm(_currentUser));     
        }
        private Form currrentFormChil;
        private void OpenChildForm(Form childForm)
        {
            if (currrentFormChil != null)
                currrentFormChil.Close();
            currrentFormChil = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            Main_panel.Controls.Add(childForm);
            Main_panel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
           OpenChildForm(new HomeForm(_currentUser));

        }

        private void btnThuVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new WatchlistForm(_currentUser));
        }

        private void btnTheLoai_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TheLoaiForm(_currentUser));
        }

        private void btnDangAnime_Click(object sender, EventArgs e)
        {

        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UserInfoForm(_currentUser));
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchKey = txtTimKiem.Text.Trim();
            OpenChildForm(new SearchForm(searchKey, _currentUser));
        }
    }
}
