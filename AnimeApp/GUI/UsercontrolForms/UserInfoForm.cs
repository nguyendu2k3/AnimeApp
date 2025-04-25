using AnimeApp.BLL;
using AnimeApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimeApp.GUI.Forms
{
    public partial class UserInfoForm : Form
    {

        private readonly AnimeService _animeService;
        private readonly UserService _userService;
        private readonly WatchlistService _watchlistService;
        private User _currentUser;
        public UserInfoForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            _animeService = new AnimeService();
            _userService = new UserService();
            _watchlistService = new WatchlistService();
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            txtEmail.Enabled = true;
            txtPassword.Visible = true;
            txtConfirmPassword.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            btnDoiMK.Text = "Xác nhận";
            btnDoiMK.Click -= btnDoiMK_Click;
            btnDoiMK.Click += btnXacNhan_Click;


        }
        // In btnXacNhan_Click method
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                // Encrypt the password before updating
                string hashedPassword = _userService.MaHoaMatKhau(txtPassword.Text);

                // Update the password in the _currentUser object
                _currentUser.MatKhau = hashedPassword;

                bool result = _userService.CapNhatNguoiDung(_currentUser);
                if (result)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!");
                    txtPassword.Visible = false;
                    txtConfirmPassword.Visible = false;
                    btnDoiMK.Text = "Đổi mật khẩu";
                    btnDoiMK.Click -= btnXacNhan_Click;
                    btnDoiMK.Click += btnDoiMK_Click;
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu không khớp!");
            }
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void UserInfoForm_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = _currentUser.TenDangNhap;
            txtEmail.Text = _currentUser.Email;
        }
    }
}
