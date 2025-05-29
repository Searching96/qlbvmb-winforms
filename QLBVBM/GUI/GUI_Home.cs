using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace QLBVBM.GUI
{
    public partial class GUI_Home : Form
    {
        private Guna2Panel navPanel;
        private Guna2Panel mainPanel;

        public GUI_Home()
        {
            InitializeComponent();
            InitializePanels();
            AddExitButton();
        }

        private void InitializePanels()
        {
            // Tạo panel nội dung chính (hiển thị UC)
            mainPanel = new Guna2Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.FillColor = Color.White;

            // Tạo panel NavBar bên trái
            navPanel = new Guna2Panel();
            navPanel.Dock = DockStyle.Left;
            navPanel.Width = 270;
            navPanel.FillColor = Color.FromArgb(64, 64, 64);

            // Thêm mainPanel trước -> chiếm phần còn lại bên phải
            this.Controls.Add(mainPanel);

            // Thêm navPanel sau -> dính trái, không bị che
            this.Controls.Add(navPanel);

            InitializeNavBar();
        }

        private void InitializeNavBar()
        {
            // Tạo danh sách các nút (Text, UserControl tương ứng)
            var menuItems = new List<(string Text, Func<UserControl> CreateControl)>
            {
                ("Tiếp nhận lịch chuyến bay", () => new UC_TiepNhanLichChuyenBay()),
                ("Bán vé", () => new UC_BanVe()),
                ("Đặt vé", () => new UC_DatVe()),
                ("Tra cứu chuyến bay", () => new UC_TraCuuChuyenBay()),
                ("Lập báo cáo theo tháng", () => new UC_LapBaoCao()),
                ("Lập báo cáo theo năm", () => new UC_BaoCaoDoanhThuNam()),
                ("Thêm sân bay", () => new UC_ThemSanBay()),
                ("Thêm hạng ghế", () => new UC_ThemHangGhe()),
                ("Thay đổi quy định", () => new UC_ThayDoiQuyDinh())
            };

            // Tạo panel chứa các nút để căn giữa
            var buttonContainer = new Guna2Panel
            {
                Size = new Size(navPanel.Width, menuItems.Count * 65), // 60 (button height) + 5 (margin)
                Location = new Point(0, (navPanel.Height - menuItems.Count * 65) / 2), // Căn giữa theo chiều dọc
                FillColor = Color.Transparent
            };
            navPanel.Controls.Add(buttonContainer);

            Guna2Button firstButton = null;

            // Duyệt qua danh sách và tạo nút
            foreach (var item in menuItems)
            {
                var btn = CreateNavButton(item.Text);
                btn.Click += (s, e) =>
                {
                    mainPanel.Controls.Clear();
                    var uc = item.CreateControl();
                    uc.Dock = DockStyle.Fill;
                    mainPanel.Controls.Add(uc);
                };

                buttonContainer.Controls.Add(btn);
                buttonContainer.Controls.SetChildIndex(btn, 0); // Đặt nút ở đầu panel

                if (firstButton == null)
                    firstButton = btn;
            }

            // Chọn mặc định nút "Tiếp nhận lịch chuyến bay"
            if (firstButton != null)
            {
                firstButton.Checked = true;
                mainPanel.Controls.Clear();
                var uc = menuItems[0].CreateControl();
                uc.Dock = DockStyle.Fill;
                mainPanel.Controls.Add(uc);
            }
        }

        private Guna2Button CreateNavButton(string text)
        {
            return new Guna2Button
            {
                Text = text,
                ImageOffset = new Point(10, 0),
                ImageSize = new Size(24, 24),
                TextOffset = new Point(15, 0),
                Dock = DockStyle.Top,
                Height = 65, // tăng chiều cao nút
                FillColor = Color.FromArgb(80, 80, 80),
                HoverState = { FillColor = Color.FromArgb(100, 100, 100) },
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = HorizontalAlignment.Left,
                ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton,
                CheckedState = { FillColor = Color.FromArgb(120, 120, 140) },
                BorderRadius = 1,
                Margin = new Padding(0, 5, 0, 5) // thêm khoảng cách giữa các nút
            };
        }

        private void AddExitButton()
        {
            // Tạo nút Thoát
            var exitBtn = CreateNavButton("Thoát");

            // Chỉnh màu đỏ cho mát hơn
            exitBtn.FillColor = Color.FromArgb(180, 40, 60);
            exitBtn.HoverState.FillColor = Color.FromArgb(200, 60, 80);
            exitBtn.CheckedState.FillColor = Color.FromArgb(200, 60, 80);

            // Bắt sự kiện đóng form
            exitBtn.Click += (s, e) => this.Close();

            // Đặt dock bottom để luôn nằm cuối
            exitBtn.Dock = DockStyle.Bottom;

            // Thêm vào navPanel
            navPanel.Controls.Add(exitBtn);
        }
    }
}