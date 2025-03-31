using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.DAL.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public bool VaiTro { get; set; } // "Admin" hoặc "User"
        public DateTime NgayTao { get; set; }

    }
}
