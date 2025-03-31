using AnimeApp.BLL;
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
    public partial class LoginForm : Form
    {
        private readonly UserService _userService;
        private bool _isLoginMode = true;
        public LoginForm()
        {
            InitializeComponent();
            _userService = new UserService();

        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var user = _userService.XacThucNguoiDung(username, password);
                if (user != null)
                {
                    // Lưu thông tin người dùng hiện tại
                    //Program.CurrentUser = user;

                    if (user.VaiTro)
                    {
                        // Mở form Admin
                        AdminForm adminForm = new AdminForm();
                        this.Hide();
                        adminForm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        // Mở form User
                        this.Hide();
                        MainForm mainForm = new MainForm(user);
                        mainForm.FormClosed += (s, args) => this.Close();
                        mainForm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            this.Hide();
            registerForm.ShowDialog();
            this.Show();
        }
    }
}