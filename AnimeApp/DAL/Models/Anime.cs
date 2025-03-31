using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.DAL.Models
{
    public class Anime
    {
        public int AnimeID { get; set; }
        public int MyAnimeListID { get; set; }
        public string TenAnime { get; set; }
        public string TenAnimeJapanese { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }
        public string Kieu { get; set; } // TV, Movie, OVA,...
        public int TapPhim { get; set; }
        public float DanhGia { get; set; }
        public DateTime NgayPhatHanh { get; set; }
        public string TrangThai { get; set; } // Airing, Finished, etc.
        public List<string> TheLoai { get; set; }
        public List<string> Studios { get; set; }
        public List<Episode> DanhSachTapPhim { get; set; }
    }
}
