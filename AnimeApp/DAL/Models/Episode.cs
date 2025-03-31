using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.DAL.Models
{
    public class Episode
    {
        public int EpisodeID { get; set; }
        public int AnimeID { get; set; }
        public int SoTap { get; set; }
        
        public string TenTap { get; set; }
        public string LinkPhim { get; set; }
        public int ThoiLuong { get; set; } // in minutes
    }
}
