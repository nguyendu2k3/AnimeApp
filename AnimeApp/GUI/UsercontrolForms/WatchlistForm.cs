using AnimeApp.BLL;
using AnimeApp.DAL.Models;
using AnimeApp.DAL.SQLServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics; // Thêm để debug

namespace AnimeApp.GUI.Forms
{
    public partial class WatchlistForm : Form
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

        public WatchlistForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            _animeService = new AnimeService();
            _userService = new UserService();
            _watchlistService = new WatchlistService();

            // Thiết lập thuộc tính form
            this.BackColor = Color.FromArgb(35, 37, 49);
            this.AutoScroll = true;

            // Tạo panel container
            containerPanel = new Panel();
            containerPanel.Dock = DockStyle.Fill;
            containerPanel.AutoScroll = true;
            this.Controls.Add(containerPanel);

            // Debug message
            Debug.WriteLine("WatchlistForm đã được khởi tạo");

            // Thêm sự kiện Load để đảm bảo form đã được khởi tạo hoàn toàn
            this.Load += WatchlistForm_Load;
        }

        private void WatchlistForm_Load(object sender, EventArgs e)
        {
            this.lblThuVien.Text="Tủ phim của " + _currentUser.TenDangNhap ;
            // Gọi phương thức để load dữ liệu khi form đã load xong
            LayDanhSachAnimeVaTaoPanel();
        }

        // Lay danh sach anime va tao panel
        private void LayDanhSachAnimeVaTaoPanel()
        {
            try
            {
                Debug.WriteLine("Bắt đầu LayDanhSachAnimeVaTaoPanel");

                // Xóa tất cả panel cũ trong container
                containerPanel.Controls.Clear();
                danhSachPanelAnime.Clear();

                // Fetch the watchlist from the database
                DataTable watchlist = _watchlistService.LayDanhSachXem(_currentUser.UserID);
                Debug.WriteLine($"Số lượng anime trong watchlist: {watchlist?.Rows.Count ?? 0}");

                // Nếu watchlist trống, hiển thị thông báo
                if (watchlist == null || watchlist.Rows.Count == 0)
                {
                    Label lblEmpty = new Label();
                    lblEmpty.Text = "Danh sách xem của bạn đang trống!";
                    lblEmpty.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                    lblEmpty.ForeColor = Color.White;
                    lblEmpty.Location = new Point(20, 20);
                    lblEmpty.AutoSize = true;
                    containerPanel.Controls.Add(lblEmpty);
                    return;
                }

                // Create panels for each anime in the watchlist
                int panelCount = 0;
                foreach (DataRow row in watchlist.Rows)
                {
                    // Lấy thông tin từ Watchlist
                    int animeId = Convert.ToInt32(row["AnimeId"]);
                    string watchStatus = row["TrangThai"].ToString();
                    Debug.WriteLine($"Đang xử lý Anime ID: {animeId}, Trạng thái: {watchStatus}");

                    // Fetch anime details using AnimeService
                    Anime anime = _animeService.GetAnimeDetails(animeId).Result;

                    if (anime == null)
                    {
                        Debug.WriteLine($"Không tìm thấy anime với ID: {animeId}");
                        continue;
                    }

                    Debug.WriteLine($"Đã lấy thông tin anime: {anime.TenAnime}");

                    // Calculate the position for the new panel
                    int hang = panelCount / soLuongPanelMoiHang;
                    int cot = panelCount % soLuongPanelMoiHang;
                    int x = viTriBatDauX + cot * (chieuRongPanel + khoangCachNgang);
                    int y = viTriBatDauY + hang * (chieuCaoPanel + khoangCachDoc);

                    // Tạo tên duy nhất cho panel
                    string panelName = $"anime_{animeId}";

                    // Create the panel
                    Panel animePanel = TaoPanelAnime(panelName, x, y);
                    animePanel.Tag = animeId; // Lưu AnimeID vào Tag
                    danhSachPanelAnime.Add(animePanel);

                    Debug.WriteLine($"Đã tạo panel cho anime: {anime.TenAnime} tại vị trí X={x}, Y={y}");

                    // Cập nhật panel với thông tin anime
                    UpdateAnimePanel(animePanel, anime, watchStatus);

                    // Thêm panel vào container
                    containerPanel.Controls.Add(animePanel);

                    panelCount++;
                }

                // Điều chỉnh kích thước của containerPanel
                int soHang = (int)Math.Ceiling((double)danhSachPanelAnime.Count / soLuongPanelMoiHang);
                int containerHeight = viTriBatDauY + (soHang * chieuCaoPanel) + ((soHang - 1) * khoangCachDoc) + 50;
                int containerWidth = viTriBatDauX + (soLuongPanelMoiHang * chieuRongPanel) + ((soLuongPanelMoiHang - 1) * khoangCachNgang) + 40;

                containerPanel.MinimumSize = new Size(containerWidth, containerHeight);
                Debug.WriteLine($"Đã đặt kích thước container: {containerWidth}x{containerHeight}, Tổng số panel: {panelCount}");

                // Refresh các control
                containerPanel.PerformLayout();
                containerPanel.Refresh();
                this.PerformLayout();
                this.Refresh();

                Debug.WriteLine("Hoàn thành LayDanhSachAnimeVaTaoPanel");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi trong LayDanhSachAnimeVaTaoPanel: {ex.Message}");
                Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                MessageBox.Show($"Đã xảy ra lỗi khi tải danh sách xem: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateAnimePanel(Panel panel, Anime anime, string watchStatus)
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
                    lblTrangThai.Text = watchStatus;
                    Debug.WriteLine($"Đã đặt trạng thái: {watchStatus}");
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
                MoFormChiTietAnime(animeId);
            }
        }

        private void Panel_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null && panel.Tag != null)
            {
                int animeId = Convert.ToInt32(panel.Tag);
                MoFormChiTietAnime(animeId);
            }
        }

        private void MoFormChiTietAnime(int animeId)
        {
            this.lblThuVien.Visible = false;
            OpenChildForm(new AnimeDetailForm(animeId, _currentUser));
            
        }
        private Form currrentFormChil;
        private void OpenChildForm(Form childForm)
        {
            if (currrentFormChil != null)
                currrentFormChil.Close();
            currrentFormChil = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            containerPanel.Controls.Add(childForm);
            containerPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}