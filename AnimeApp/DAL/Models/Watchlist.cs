using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.DAL.Models
{
    public class Watchlist
    {
        public int WatchlistID { get; set; }
        public int UserID { get; set; }
        public int AnimeID { get; set; }
        public string TrangThai { get; set; } // PlanToWatch, Watching, Completed
    }
}
