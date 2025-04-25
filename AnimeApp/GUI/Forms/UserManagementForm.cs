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
    public partial class UserManagementForm : Form
    {
        UserService _userService;
        public UserManagementForm()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            label4.Visible = true;
            txtMatKhau.Visible = true;
            btnAdd.Text = "Xác nhận";
            btnAdd.Click -= btnAdd_Click;
            btnAdd.Click += btnXacNhan_Click;

        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAdd.Text == "Xác nhận")
                {
                    string username = txtTenDangNhap.Text;
                    string password = txtMatKhau.Text;
                    string email = txtEmail.Text;
                    if (_userService.DangKyNguoiDung(username, password, email))
                    {
                        MessageBox.Show("Đăng ký thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMatKhau.Visible = false;
                        label4.Visible = false;
                        btnAdd.Text = "Thêm";
                        btnAdd.Click -= btnXacNhan_Click;
                        btnAdd.Click -= btnAdd_Click;
                        LoadUserFromDatabase();
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtUserID.Text, out int userId))
                {
                    User user = new User
                    {
                        UserID = userId,
                        TenDangNhap = txtTenDangNhap.Text,
                        Email = txtEmail.Text,
                        MatKhau = _userService.MaHoaMatKhau(txtMatKhau.Text)
                    };

                    if (_userService.CapNhatNguoiDung(user))
                    {
                        MessageBox.Show("Cập nhật người dùng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUserFromDatabase();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập ID người dùng hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtUserID.Text, out int userId))
                {
                    if (_userService.XoaNguoiDung(userId))
                    {
                        MessageBox.Show("Xóa người dùng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUserFromDatabase();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập ID người dùng hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUserFromDatabase()
        {
            try{
                List<User> users = _userService.LayTatCaNguoiDung();
                dgvUser.DataSource = users.Select(user => new
                {
                    user.UserID,
                    user.TenDangNhap,
             
                    user.Email,
                    
                    user.NgayTao
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.txtTenDangNhap.Clear();
            this.txtEmail.Clear();
            this.txtUserID.Clear();
            this.txtMatKhau.Clear();
            this.txtSearch.Clear();
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            LoadUserFromDatabase();
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Ensure a valid row is clicked
                {
                    DataGridViewRow selectedRow = dgvUser.Rows[e.RowIndex];

                    // Safely retrieve cell values
                    txtUserID.Text = selectedRow.Cells["UserID"]?.Value?.ToString() ?? string.Empty;
                    txtTenDangNhap.Text = selectedRow.Cells["TenDangNhap"]?.Value?.ToString() ?? string.Empty;
                    txtEmail.Text = selectedRow.Cells["Email"]?.Value?.ToString() ?? string.Empty;
                    dtpNgayTao.Text = selectedRow.Cells["NgayTao"]?.Value?.ToString() ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
