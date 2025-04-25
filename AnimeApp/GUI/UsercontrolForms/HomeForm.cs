using AnimeApp.BLL;
using AnimeApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimeApp.GUI.Forms
{
    public partial class HomeForm : Form
    {
        private readonly AnimeService _animeService;
        private readonly UserService _userService;
        private readonly WatchlistService _watchlistService;
        private User _currentUser;

        private List<Panel> danhSachPanelAnime = new List<Panel>();
        private int soLuongPanelMoiHang = 5;
        private int chieuRongPanel = 150;
        private int chieuCaoPanel = 290;
        private int khoangCachNgang = 15;
        private int khoangCachDoc = 15;
        private int viTriBatDauX = 12;
        private int viTriBatDauY = 40;

        // Thêm Panel container để chứa tất cả panel anime
        private Panel containerPanel;
        private Panel contentPanel;
        private Panel topAnimePanel;
        private Panel newAnimePanel;
        public HomeForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            _animeService = new AnimeService();
            _userService = new UserService();
            _watchlistService = new WatchlistService();

            // Tạo panel container
            containerPanel = new Panel();
            containerPanel.Dock = DockStyle.Fill;
            containerPanel.AutoScroll = true;
            this.Controls.Add(containerPanel);

            // Tạo content panel để quản lý nội dung
            contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.AutoScroll = true;
            containerPanel.Controls.Add(contentPanel);
        }
        private void HomeForm_Load(object sender, EventArgs e)
        {
            // Tạo các panel hiển thị top anime và new anime
            InitializePanels();

            // Load dữ liệu anime
            LoadAnimeData();
        }
        private void InitializePanels()
        {
            // Tạo panel chứa Top Anime
            topAnimePanel = new Panel();
            topAnimePanel.AutoSize = true;
            topAnimePanel.Dock = DockStyle.Top;
            topAnimePanel.Padding = new Padding(0, 0, 0, 20);

            // Tạo panel chứa New Anime
            newAnimePanel = new Panel();
            newAnimePanel.AutoSize = true;
            newAnimePanel.Dock = DockStyle.Top;

            // Thêm các panel vào container theo thứ tự ngược lại (để hiển thị theo đúng thứ tự)
            containerPanel.Controls.Add(newAnimePanel);
            containerPanel.Controls.Add(topAnimePanel);
        }
        private async void LoadAnimeData()
        {
            try
            {
                // Tải dữ liệu cho cả Top Anime và New Anime
                await LoadTopAnime();
                await LoadAnimeNews();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu anime: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Lấy danh sách và tạo panel Top Anime
        private async Task LoadTopAnime()
        {
            try
            {
                // Lấy danh sách anime từ API
                var topAnimeList = await _animeService.GetTopAnime();

                // Xóa các panel cũ
                topAnimePanel.Controls.Clear();

                // Tạo tiêu đề
                Label titleLabel = new Label();
                titleLabel.Text = "Top Anime";
                titleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
                titleLabel.ForeColor = Color.White;
                titleLabel.Location = new Point(viTriBatDauX, 10);
                titleLabel.Size = new Size(200, 30);
                titleLabel.AutoSize = true;
                topAnimePanel.Controls.Add(titleLabel);

                // Tạo panel cho từng anime
                int soLuongAnime = Math.Min(topAnimeList.Count, 5); // Giới hạn hiển thị 10 anime
                int soHang = (int)Math.Ceiling((double)soLuongAnime / soLuongPanelMoiHang);

                for (int hang = 0; hang < soHang; hang++)
                {
                    for (int cot = 0; cot < soLuongPanelMoiHang; cot++)
                    {
                        int index = hang * soLuongPanelMoiHang + cot;
                        if (index < soLuongAnime)
                        {
                            int x = viTriBatDauX + cot * (chieuRongPanel + khoangCachNgang);
                            int y = viTriBatDauY + hang * (chieuCaoPanel + khoangCachDoc);

                            Panel animePanel = TaoPanelAnime($"panelTopAnime{index}", x, y);
                            animePanel.Tag = topAnimeList[index].MyAnimeListID;

                          
                           

                            // Cập nhật thông tin anime vào panel
                            UpdateAnimePanel(animePanel, topAnimeList[index]);

                            topAnimePanel.Controls.Add(animePanel);
                            danhSachPanelAnime.Add(animePanel);
                        }
                    }
                }

                // Cập nhật chiều cao panel
                int panelHeight = viTriBatDauY + soHang * (chieuCaoPanel + khoangCachDoc);
                topAnimePanel.Height = panelHeight;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách Top Anime: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task LoadAnimeNews()
        {
            try
            {
                // Lấy danh sách anime từ API
                var newAnimeList = await _animeService.GetAnimeNews();

                // Xóa các panel cũ
                newAnimePanel.Controls.Clear();

                // Tạo tiêu đề
                Label titleLabel = new Label();
                titleLabel.Text = "Mới cập nhật";
                titleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
                titleLabel.ForeColor = Color.White;
                titleLabel.Location = new Point(viTriBatDauX, 10);
                titleLabel.Size = new Size(200, 30);
                titleLabel.AutoSize = true;
                newAnimePanel.Controls.Add(titleLabel);

                // Tạo panel cho từng anime
                int soLuongAnime = newAnimeList.Count; // Giới hạn hiển thị 10 anime
                int soHang = (int)Math.Ceiling((double)soLuongAnime / soLuongPanelMoiHang);

                HashSet<int> displayedAnimeIds = new HashSet<int>();
                int currentIndex = 0;

                for (int hang = 0; hang < soHang; hang++)
                {
                    for (int cot = 0; cot < soLuongPanelMoiHang; cot++)
                    {
                        if (currentIndex >= soLuongAnime)
                        {
                            break;
                        }

                        var anime = newAnimeList[currentIndex];
                        if (displayedAnimeIds.Contains(anime.MyAnimeListID))
                        {
                            currentIndex++;
                            cot--;
                            continue;
                        }

                        int x = viTriBatDauX + cot * (chieuRongPanel + khoangCachNgang);
                        int y = viTriBatDauY + hang * (chieuCaoPanel + khoangCachDoc);

                        Panel animePanel = TaoPanelAnime($"panelNewAnime{currentIndex}", x, y);
                        animePanel.Tag = anime.MyAnimeListID;

                        // Cập nhật thông tin anime vào panel
                        UpdateAnimePanel(animePanel, anime);
                        // Thay đổi trạng thái thành "Tập [số tập]"
                        Label lblTrangThai = animePanel.Controls.OfType<Label>()
                            .FirstOrDefault(lbl => lbl.Name.StartsWith("lblTrangThai"));
                        if (lblTrangThai != null)
                        {
                            lblTrangThai.Text = "Tập " + anime.TapPhim.ToString();
                            lblTrangThai.ForeColor = Color.Orange; // Thay đổi màu sắc để nổi bật
                        }

                        newAnimePanel.Controls.Add(animePanel);
                        danhSachPanelAnime.Add(animePanel);
                        displayedAnimeIds.Add(anime.MyAnimeListID);
                        currentIndex++;
                    }
                }

                // Cập nhật chiều cao panel
                int panelHeight = viTriBatDauY + soHang * (chieuCaoPanel + khoangCachDoc);
                newAnimePanel.Height = panelHeight;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách New Anime: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateAnimePanel(Panel panel, Anime anime)
        {
            try
            {
                // Tìm PictureBox và các Label trong panel
                PictureBox picAnime = panel.Controls.OfType<PictureBox>().FirstOrDefault();
                Label lblTenAnime = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name.StartsWith("lblTenAnime"));
                Label lblTrangThai = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name.StartsWith("lblTrangThai"));

                // Cập nhật thông tin
                if (picAnime != null)
                {
                    picAnime.Tag = anime.MyAnimeListID;
                    try
                    {
                        // Kiểm tra đường dẫn hình ảnh
                        if (!string.IsNullOrEmpty(anime.HinhAnh))
                        {
                            Debug.WriteLine($"Đang tải hình ảnh từ: {anime.HinhAnh}");

                            // Thử tải hình ảnh trực tiếp
                            if (System.IO.File.Exists(anime.HinhAnh))
                            {
                                picAnime.Image = Image.FromFile(anime.HinhAnh);
                            }
                            else
                            {
                                // Nếu là URL, thử tải qua mạng
                                picAnime.LoadAsync(anime.HinhAnh);
                            }
                        }
                        else
                        {
                            Debug.WriteLine("Đường dẫn hình ảnh trống");
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Lỗi khi tải hình ảnh: {ex.Message}");
                        // Đặt hình ảnh mặc định nếu có lỗi
                        // picAnime.Image = Properties.Resources.default_anime;
                    }
                }

                if (lblTenAnime != null)
                {
                    lblTenAnime.Text = anime.TenAnime;
                    Debug.WriteLine($"Đã đặt tên anime: {anime.TenAnime}");
                }

                if (lblTrangThai != null)
                {
                    lblTrangThai.Text = anime.TrangThai;
                    Debug.WriteLine($"Đã đặt trạng thái: {anime.TrangThai}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi khi cập nhật panel anime: {ex.Message}");
            }
        }

        //Tao Panel Anime
        private Panel TaoPanelAnime(string tenPanel, int x, int y)
        {
            // Tạo panel chính
            Panel panel = new Panel();
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Location = new Point(x, y);
            panel.Name = tenPanel;
            panel.Size = new Size(chieuRongPanel, chieuCaoPanel);
            panel.TabIndex = 1;
            panel.BackColor = Color.FromArgb(40, 40, 40);
            panel.Visible = true; // Đảm bảo panel được hiển thị

            // Tạo PictureBox cho hình ảnh anime
            PictureBox picAnime = new PictureBox();
            picAnime.Location = new Point(-1, -1);
            picAnime.Name = $"pic{tenPanel}";
            picAnime.Size = new Size(150, 230);
            picAnime.SizeMode = PictureBoxSizeMode.StretchImage;
            picAnime.TabIndex = 0;
            picAnime.TabStop = false;
            picAnime.BackColor = Color.FromArgb(50, 50, 50);
            picAnime.Visible = true;
            picAnime.Click += PicAnime_Click;

            // Tạo label cho tên anime
            Label lblTenAnime = new Label();
            lblTenAnime.AutoEllipsis = true;
            lblTenAnime.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(163)));
            lblTenAnime.ForeColor = Color.White;
            lblTenAnime.Location = new Point(0, 232);
            lblTenAnime.Name = $"lblTenAnime{tenPanel}";
            lblTenAnime.Size = new Size(148, 20);
            lblTenAnime.TabIndex = 1;
            lblTenAnime.Text = "Loading...";
            lblTenAnime.TextAlign = ContentAlignment.MiddleCenter;
            lblTenAnime.Visible = true;

            // Tạo label cho trạng thái anime
            Label lblTrangThai = new Label();
            lblTrangThai.Font = new Font("Segoe UI", 8F);
            lblTrangThai.ForeColor = Color.LightGreen;
            lblTrangThai.Location = new Point(0, 262);
            lblTrangThai.Name = $"lblTrangThai{tenPanel}";
            lblTrangThai.Size = new Size(148, 19);
            lblTrangThai.TabIndex = 1;
            lblTrangThai.Text = "Loading...";
            lblTrangThai.TextAlign = ContentAlignment.MiddleCenter;
            lblTrangThai.Visible = true;

            // Thêm các control vào panel
            panel.Controls.Add(picAnime);
            panel.Controls.Add(lblTenAnime);
            panel.Controls.Add(lblTrangThai);

            // Thêm sự kiện click cho cả panel
            panel.Click += Panel_Click;

            return panel;
        }

        private void PicAnime_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic != null && pic.Tag != null)
            {
                int animeId = Convert.ToInt32(pic.Tag);
                OpenAnimeDetailForm(animeId);
            }
        }

        private void Panel_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null && panel.Tag != null)
            {
                int animeId = Convert.ToInt32(panel.Tag);
                OpenAnimeDetailForm(animeId);
            }
        }

        private Form currentChildForm;

        private void OpenAnimeDetailForm(int animeId)
        {
            try
            {
                // Đóng form cũ nếu đang mở
                if (currentChildForm != null)
                {
                    currentChildForm.Close();
                    currentChildForm = null;
                }

                // Ẩn các panel hiển thị danh sách anime
                topAnimePanel.Visible = false;
                newAnimePanel.Visible = false;

                // Tạo form chi tiết mới
                AnimeDetailForm detailForm = new AnimeDetailForm(animeId, _currentUser);

                // Thiết lập thuộc tính để embed form vào form cha
                detailForm.TopLevel = false;
                detailForm.FormBorderStyle = FormBorderStyle.None;
                detailForm.Dock = DockStyle.Fill;

                // Thêm form vào container
                containerPanel.Controls.Add(detailForm);

                // Lưu trữ reference đến form hiện tại
                currentChildForm = detailForm;

                // Thêm hàm xử lý khi form detail đóng lại
                detailForm.FormClosed += (s, args) => {
                    // Hiển thị lại các panel danh sách anime
                    topAnimePanel.Visible = true;
                    newAnimePanel.Visible = true;
                    currentChildForm = null;
                };

                // Hiển thị form lên trên cùng
                detailForm.BringToFront();
                detailForm.Show();

                Debug.WriteLine($"Đã mở form chi tiết anime với ID: {animeId}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form chi tiết anime: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Đảm bảo các panel được hiển thị lại nếu có lỗi
                topAnimePanel.Visible = true;
                newAnimePanel.Visible = true;
            }
        }
    }
}
