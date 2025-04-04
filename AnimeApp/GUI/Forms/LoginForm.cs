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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AnimeApp.GUI.Forms
{
    public partial class Title : Form
    {
        private readonly UserService _userService;
        private bool _isLoginMode = true;
        public Title()
        {
            InitializeComponent();
            _userService = new UserService();

            // Set up event handlers
            //btnLogin.Click += BtnLogin_Click;
            //lnkSwitchMode.Click += LnkSwitchMode_Click;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form_KeyDown);
            // Set initial UI
            UpdateUI();
        }
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnLogin.PerformClick();
            }
        }
        private void UpdateUI()
        {
            if (_isLoginMode)
            {
                lblTitle.Text = "Đăng nhập";
                btnLogin.Text = "Đăng nhập";
                lnkSwitchMode.Text = "Chưa có tài khoản? Đăng ký";
                txtEmail.Visible = false;
                lblEmail.Visible = false;
                txtXacNhan.Visible = false;
                lblXacNhan.Visible = false;
            }
            else
            {
                lblTitle.Text = "Đăng ký";
                btnLogin.Text = "Đăng ký";
                lnkSwitchMode.Text = "Đã có tài khoản? Đăng nhập";
                txtEmail.Visible = true;
                lblEmail.Visible = true;
                txtXacNhan.Visible = true;
                lblXacNhan.Visible = true;
            }
            this.Controls.Add(lblTitle);
        }
        private void DangNhap(string username, string password)
        {
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
                    //Lưu thông tin người dùng hiện tại
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
        private void DangKy(string username, string password, string email, string xacNhan)
        {
            if  (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) ||
                 string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(xacNhan))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != xacNhan)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool success = _userService.DangKyNguoiDung(username, password, email);

            if (success)
            {
                MessageBox.Show("Đăng ký thành công. Vui lòng đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _isLoginMode = true;
                UpdateUI();
                txtPassword.Clear();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.", "Lỗi đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string email = txtEmail.Text.Trim();
            string xacNhan = txtXacNhan.Text;
            if (_isLoginMode)
            {
                DangNhap(username, password);   
            }
            else
            {
                DangKy(username, password, email, xacNhan);
            }
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _isLoginMode = !_isLoginMode;
            UpdateUI();
        }   

       
    }
}