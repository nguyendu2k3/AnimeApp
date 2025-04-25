using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using AnimeApp.DAL.Models;
using AnimeApp.DAL.SQLServer;
namespace AnimeApp.BLL
{
    public class UserService
    {
        private readonly UserDAO _userDAO;
        public UserService()
        {
            _userDAO = new UserDAO();
        }
        public string MaHoaMatKhau(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
       
        public User XacThucNguoiDung(string username, string password)
        {
            User user = _userDAO.LayTenNguoiDung(username);
            if(user != null )
            {
                string maHoaMK = MaHoaMatKhau(password);
                if(user.MatKhau == maHoaMK)
                {
                    return user;
                }

            }
            return null;
        }
        
        public bool DangKyNguoiDung(string username, string password, string email)
        {
            if(_userDAO.LayTenNguoiDung(username) != null)
            {
                return false; //Tên đăng nhập đã tồn tại!
            }
            User newUser = new User
            {
                TenDangNhap = username,
                MatKhau = MaHoaMatKhau(password),
                Email = email,
                VaiTro = false,
                NgayTao = DateTime.Now
            };
            return _userDAO.ThemNguoiDung(newUser);
        }
        public List<User> LayTatCaNguoiDung()
        {
            return _userDAO.LayTatCaNguoiDung();
        }
        public bool CapNhatNguoiDung(User user)
        {
            return _userDAO.CapNhatNguoiDung(user);
        }
        public bool XoaNguoiDung(int userID)
        {
            return _userDAO.XoaNguoiDung(userID);
        }

    }
}
