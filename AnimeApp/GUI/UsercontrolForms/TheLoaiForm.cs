using AnimeApp.BLL;
using AnimeApp.DAL.API;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AnimeApp.GUI.Forms
{
    public partial class TheLoaiForm : Form
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
        private int viTriBatDauX = 15;
        private int viTriBatDauY = 171;




        private MyAnimeListAPI _animeApi;

        public TheLoaiForm(User user)
        {
            InitializeComponent();
            _animeApi = new MyAnimeListAPI();
            _currentUser = user;
            _animeService = new AnimeService();
            _userService = new UserService();
            _watchlistService = new WatchlistService();

        }
        private async void TheLoaiForm_Load(object sender, EventArgs e)
        {
            this.cmbTrangThai.SelectedIndex = 0;

            this.cbTheLoai.Items.Add("Tất cả");
            this.cbTheLoai.SelectedIndex = 0;
            GetGenres();

            
            this.cbMua.SelectedIndex = 0;

            this.cbNamPhatHanh.Items.Add("Tất cả");
            for (int year = DateTime.Now.Year; year >= 2000; year--)
            {
                cbNamPhatHanh.Items.Add(year.ToString());
            }
            this.cbNamPhatHanh.SelectedIndex = 0;

            await LayDanhSachAnimeVaTaoPanel(1);

        }
        private async void GetGenres()
        {
            // Load genres from API
            var genres = await _animeApi.GetAllAnimeGenres();
            this.cbTheLoai.Items.AddRange(genres.ToArray());
        }


        

        private async Task LayDanhSachAnimeVaTaoPanel(int pageNumber)
        {
            try
            {
                foreach (var panel in danhSachPanelAnime)
                {
                    this.containerPanel.Controls.Remove(panel);
                }
                danhSachPanelAnime.Clear();

                var animeList = await _animeApi.GetTopAnimeBatch(pageNumber, 1);
                int soLuongAnime = animeList.Count();
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
                            animePanel.Tag = animeList[index].MyAnimeListID;

                            // Cập nhật thông tin anime vào panel
                            UpdateAnimePanel(animePanel, animeList[index]);

                            // Thêm panel vào containerPanel có sẵn trong form
                            this.containerPanel.Controls.Add(animePanel);
                            danhSachPanelAnime.Add(animePanel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách Top Anime: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                this.containerPanel.Controls.Clear();

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
                detailForm.FormClosed += (s, args) =>
                {
                    // Hiển thị lại các panel danh sách anime
                    containerPanel.Visible = true;
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
                containerPanel.Visible = true;
            }
        }

        private async void btnDuyetPhim_Click(object sender, EventArgs e)
        {
            string selectedGenre = cbTheLoai.SelectedItem.ToString();
            string selectedSeason = cbMua.SelectedItem.ToString();
            string selectedYear = cbNamPhatHanh.SelectedItem.ToString();
            string selectedStatus = cmbTrangThai.SelectedItem.ToString();

            await LayDanhSachAnimeTheoDieuKien(selectedGenre, selectedSeason, selectedYear, selectedStatus);
        }

        private async Task LayDanhSachAnimeTheoDieuKien(string genre, string season, string year, string status, int page = 1)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Xóa panel cũ
                foreach (var panel in danhSachPanelAnime)
                {
                    this.containerPanel.Controls.Remove(panel);
                }
                danhSachPanelAnime.Clear();

                // Hiển thị đang tải
               
                Application.DoEvents();

                // Xử lý các giá trị "Tất cả"
                string genreFilter = genre == "Tất cả" ? null : genre;
                string seasonFilter = season == "Tất cả" ? null : season;
                string statusFilter = status == "Tất cả" ? null : status;

                // Xử lý năm
                int yearValue = 0;
                if (year != "Tất cả" && !string.IsNullOrEmpty(year))
                {
                    if (int.TryParse(year, out int parsedYear))
                    {
                        yearValue = parsedYear;
                    }
                }

                // *** QUAN TRỌNG: In thông tin chính xác trước khi gọi API ***
                Console.WriteLine("--------------------------------");
                Console.WriteLine($"Bắt đầu tìm kiếm với các tham số:");
                Console.WriteLine($"- Thể loại: '{genreFilter}'");
                Console.WriteLine($"- Mùa: '{seasonFilter}'");
                Console.WriteLine($"- Năm: {yearValue}");
                Console.WriteLine($"- Trạng thái: '{statusFilter}'");
                Console.WriteLine($"- Trang: {page}");
                Console.WriteLine("--------------------------------");

                // Gọi API tìm kiếm
                var animeList = await _animeApi.SearchAnimeTheoDieuKien(
                    status: statusFilter,
                    genre: genreFilter,
                    season: seasonFilter,
                    year: yearValue,
                    page: page,
                    order_by: "popularity",
                    sort: "desc"
                );

                // Xử lý kết quả trả về
                int soLuongAnime = animeList.Count;
                Console.WriteLine($"Kết quả trả về: {soLuongAnime} anime");

                if (soLuongAnime == 0)
                {
                   
                    if (page > 1)
                    {
                        MessageBox.Show($"Không tìm thấy anime nào ở trang {page}.\nHệ thống sẽ quay lại trang trước.",
                            "Không có kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtTrang.Text = (page - 1).ToString();
                        await LayDanhSachAnimeTheoDieuKien(genre, season, year, status, page - 1);
                    }
                    return;
                }

                // Hiển thị kết quả
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
                            Panel animePanel = TaoPanelAnime($"panelAnime{index}", x, y);
                            animePanel.Tag = animeList[index].MyAnimeListID;

                            // Cập nhật thông tin anime vào panel
                            UpdateAnimePanel(animePanel, animeList[index]);

                            // Thêm panel vào container
                            this.containerPanel.Controls.Add(animePanel);
                            danhSachPanelAnime.Add(animePanel);
                        }
                    }
                }

                // Cập nhật thông tin
                
                txtTrang.Text = page.ToString();

                Console.WriteLine($"Đã tải thành công {soLuongAnime} anime ở trang {page}");
            }
            catch (Exception ex)
            {
               
                MessageBox.Show($"Lỗi khi tải danh sách anime: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"[ERROR] Exception: {ex.Message}");
                Console.WriteLine($"[ERROR] Stack trace: {ex.StackTrace}");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private async void btnTien_Click(object sender, EventArgs e)
        {
            int intPage;
            if (int.TryParse(txtTrang.Text.Trim(), out intPage))
            {
                // Tăng số trang
                intPage++;

                // Cập nhật giá trị mới vào textbox
                txtTrang.Text = intPage.ToString();

                // Tải danh sách anime trang mới
                await LayDanhSachAnimeVaTaoPanel(intPage);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một số hợp lệ trong ô trang.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnLui_Click(object sender, EventArgs e)
        {
            int intPage;
            if (int.TryParse(txtTrang.Text.Trim(), out intPage))
            {
                // Giảm số trang và kiểm tra không cho phép nhỏ hơn 1
                intPage = Math.Max(1, intPage - 1);

                // Cập nhật giá trị mới vào textbox
                txtTrang.Text = intPage.ToString();

                // Tải danh sách anime trang mới
                await LayDanhSachAnimeVaTaoPanel(intPage);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một số hợp lệ trong ô trang.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Đặt lại giá trị mặc định nếu không phải số
                txtTrang.Text = "1";
            }
        }
    }
}
