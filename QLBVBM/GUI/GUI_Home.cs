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
    public partial class GUI_Home: Form
    {
        private Guna2Panel navPanel;
        private Guna2Panel mainPanel;

        public GUI_Home()
        {
            InitializeComponent();
            InitializePanels();
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
            navPanel.Width = 200;
            navPanel.FillColor = Color.FromArgb(45, 45, 60);

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
                ("Tra cứu chuyến bay", () => new UC_TraCuuChuyenBay())
            };

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

                navPanel.Controls.Add(btn);
                navPanel.Controls.SetChildIndex(btn, 0); // Đặt nút ở đầu panel
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
                Height = 50,
                FillColor = Color.FromArgb(60, 60, 80),
                HoverState = { FillColor = Color.FromArgb(75, 75, 100) },
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.White,
                TextAlign = HorizontalAlignment.Left,
                ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton,
                CheckedState = { FillColor = Color.FromArgb(90, 90, 120) }
            };
        }
    }
}
