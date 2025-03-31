using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimeApp.DAL.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AnimeApp.DAL.SQLServer
{
    public class UserDAO
    {
        public User LayTenNguoiDung(string username)
        {
            string query = "SELECT * FROM Users WHERE TenDangNhap = @TenDangNhap";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TenDangNhap",username)
            };
            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);
            if(dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new User
                {
                    UserID = Convert.ToInt32(row["UserID"]),
                    TenDangNhap = row["TenDangNhap"].ToString(),
                    MatKhau = row["MatKhau"].ToString(),
                    Email = row["Email"].ToString(),
                    VaiTro = Convert.ToBoolean(row["VaiTro"]),
                    NgayTao = Convert.ToDateTime(row["NgayTao"])
                };
            }
            return null;
        }
        public bool ThemNguoiDung (User user)
        {
            string query = @"INSERT INTO Users (TenDangNhap, MatKhau, Email, VaiTro, NgayTao) 
                             VALUES (@TenDangNhap, @MatKhau, @Email, @VaiTro,@NgayTao)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter ("@TenDangNhap", user.TenDangNhap),
                new SqlParameter ("@MatKhau", user.MatKhau),
                new SqlParameter ("@email", user.Email),
                new SqlParameter ("@VaiTro", user.VaiTro),
                new SqlParameter ("@NgayTao", DateTime.Now)
            };

            try
            {
                DatabaseConnection.ExecuteNonQuery(query, parameters);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public List<User> LayTatCaNguoiDung()
        {
            string query = "SELECT * FROM Users";
            DataTable dataTable =  DatabaseConnection.ExecuteQuery(query);
            List<User> users = new List<User>();
            foreach (DataRow row in dataTable.Rows)
            {
                users.Add(new User
                {
                    UserID = Convert.ToInt32(row["UserID"]),
                    TenDangNhap = row["TenDangNhap"].ToString(),
                    MatKhau = row["MatKhau"].ToString(),
                    Email = row["email"].ToString(),
                    VaiTro = Convert.ToBoolean(row["VaiTro"]),
                    NgayTao = Convert.ToDateTime(row["NgayTao"])
                });
            }
            return users;
        }
        public bool CapNhatNguoiDung(User user)
        {
            string query = @"UPDATE Users SET TenDangNhap = @TenDangNhap, MatKhau =@MatKhau,
                             Email = @Email, VaiTro = @VaiTro WHERE UserID = @UserID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter ("@TenDangNhap", user.TenDangNhap),
                new SqlParameter ("@MatKhau", user.MatKhau),
                new SqlParameter ("@email", user.Email),
                new SqlParameter ("@VaiTro", user.VaiTro),
                new SqlParameter ("@NgayTao", DateTime.Now)
            };

            try
            {
                DatabaseConnection.ExecuteNonQuery(query, parameters);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool XoaNguoiDung(int userID)
        {
            string query = "DELETE FROM Users WHERE UserID = @UserID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID",userID)
            };

            try
            {
                DatabaseConnection.ExecuteNonQuery(query, parameters);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
