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
    public partial class MainForm : Form
    {
        private readonly AnimeService _animeService;
        private readonly UserService _userService;
        private readonly WatchlistService _watchlistService;
        private User _currentUser;
        public MainForm(User user)
        {
            InitializeComponent();
            
        }
        
        
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        
        
    }
}
