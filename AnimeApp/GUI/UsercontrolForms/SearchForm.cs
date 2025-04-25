using AnimeApp.BLL;
using AnimeApp.DAL.API;
using AnimeApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimeApp.GUI.Forms
{
    public partial class SearchForm : Form
    {
        private readonly AnimeService _animeService;
        private readonly UserService _userService;
        private readonly WatchlistService _watchlistService;
        private readonly User _currentUser;
        private readonly string _searchKey;

        private List<Panel> _animePanels = new List<Panel>();
        private const int PanelsPerRow = 5;
        private const int PanelWidth = 150;
        private const int PanelHeight = 290;
        private const int HorizontalSpacing = 15;
        private const int VerticalSpacing = 15;
        private const int StartX = 12;
        private const int StartY = 40;

        private Panel _containerPanel;
        private Form _currentChildForm;
        private MyAnimeListAPI _animeApi;

        public SearchForm(string searchKey, User user)
        {
            InitializeComponent();
            _searchKey = searchKey;
            _animeApi = new MyAnimeListAPI();
            _currentUser = user ?? throw new ArgumentNullException(nameof(user));
            _animeService = new AnimeService();
            _userService = new UserService();
            _watchlistService = new WatchlistService();

            BackColor = Color.FromArgb(35, 37, 49);
            AutoScroll = true;

            _containerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            Controls.Add(_containerPanel);
        }

        private async void SearchForm_Load(object sender, EventArgs e)
        {
            lbKetQuaTimKiem.Text = $"Kết quả tìm kiếm cho: {_searchKey}";
            await LoadAnimeSearchResults();
        }

        private async Task LoadAnimeSearchResults(int page = 1)
        {
            try
            {
                foreach (var panel in _animePanels)
                {
                    _containerPanel.Controls.Remove(panel);
                    panel.Dispose();
                }
                _animePanels.Clear();

                var animeList = await _animeApi.SearchAnime(_searchKey, page);
                if (!animeList.Any())
                {
                    MessageBox.Show("No anime found for the search query.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                for (int i = 0; i < animeList.Count; i++)
                {
                    var anime = animeList[i];
                    int row = i / PanelsPerRow;
                    int col = i % PanelsPerRow;
                    int x = StartX + col * (PanelWidth + HorizontalSpacing);
                    int y = StartY + row * (PanelHeight + VerticalSpacing);

                    var panel = CreateAnimePanel(anime, x, y);
                    _animePanels.Add(panel);
                    _containerPanel.Controls.Add(panel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading anime: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreateAnimePanel(Anime anime, int x, int y)
        {
            var panel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(x, y),
                Name = $"panelAnime_{anime.MyAnimeListID}",
                Size = new Size(PanelWidth, PanelHeight),
                BackColor = Color.FromArgb(40, 40, 40),
                Tag = anime.MyAnimeListID
            };

            var picAnime = new PictureBox
            {
                Location = new Point(-1, -1),
                Name = $"picAnime_{anime.MyAnimeListID}",
                Size = new Size(150, 230),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.FromArgb(50, 50, 50),
                Tag = anime.MyAnimeListID
            };
            if (!string.IsNullOrEmpty(anime.HinhAnh))
            {
                picAnime.LoadAsync(anime.HinhAnh);
            }
            picAnime.Click += PicAnime_Click;

            var lblTitle = new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(0, 232),
                Name = $"lblTitle_{anime.MyAnimeListID}",
                Size = new Size(148, 20),
                Text = anime.TenAnime ?? "Unknown",
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblStatus = new Label
            {
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.LightGreen,
                Location = new Point(0, 262),
                Name = $"lblStatus_{anime.MyAnimeListID}",
                Size = new Size(148, 19),
                Text = anime.TrangThai ?? "Unknown",
                TextAlign = ContentAlignment.MiddleCenter
            };

            panel.Controls.Add(picAnime);
            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblStatus);
            panel.Click += Panel_Click;

            return panel;
        }

        private void PicAnime_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pic && pic.Tag != null)
            {
                int animeId = Convert.ToInt32(pic.Tag);
                OpenAnimeDetailForm(animeId);
            }
        }

        private void Panel_Click(object sender, EventArgs e)
        {
            if (sender is Panel panel && panel.Tag != null)
            {
                int animeId = Convert.ToInt32(panel.Tag);
                OpenAnimeDetailForm(animeId);
            }
        }

        private void OpenAnimeDetailForm(int animeId)
        {
            lbKetQuaTimKiem.Visible = false;
            OpenChildForm(new AnimeDetailForm(animeId, _currentUser));
        }

        private void OpenChildForm(Form childForm)
        {
            _currentChildForm?.Close();
            _currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            _containerPanel.Controls.Add(childForm);
            _containerPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}