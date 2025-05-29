using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBVBM.GUI
{
    public partial class GUI_Home: Form
    {
        private Guna.UI2.WinForms.Guna2Panel navPanel;
        private Guna.UI2.WinForms.Guna2Panel mainPanel;

        public GUI_Home()
        {
            InitializeComponent();
            InitializePanels();
        }

        private void InitializePanels()
        {
            // Tạo panel nội dung chính (hiển thị UC)
            mainPanel = new Guna.UI2.WinForms.Guna2Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.FillColor = Color.White;

            // Tạo panel NavBar bên trái
            navPanel = new Guna.UI2.WinForms.Guna2Panel();
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
            Guna.UI2.WinForms.Guna2Button btnTiepNhanChuyenBay = new Guna.UI2.WinForms.Guna2Button();
            btnTiepNhanChuyenBay.Text = "Tiếp nhận lịch chuyến bay";
            btnTiepNhanChuyenBay.ImageOffset = new Point(10, 0);
            btnTiepNhanChuyenBay.ImageSize = new Size(24, 24);
            btnTiepNhanChuyenBay.TextOffset = new Point(15, 0);
            btnTiepNhanChuyenBay.Dock = DockStyle.Top;
            btnTiepNhanChuyenBay.Height = 50;
            btnTiepNhanChuyenBay.FillColor = Color.FromArgb(60, 60, 80);
            btnTiepNhanChuyenBay.HoverState.FillColor = Color.FromArgb(75, 75, 100);
            btnTiepNhanChuyenBay.Font = new Font("Segoe UI", 10);
            btnTiepNhanChuyenBay.ForeColor = Color.White;
            btnTiepNhanChuyenBay.TextAlign = HorizontalAlignment.Left;
            btnTiepNhanChuyenBay.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnTiepNhanChuyenBay.CheckedState.FillColor = Color.FromArgb(90, 90, 120);

            // Xử lý click để hiện UC
            btnTiepNhanChuyenBay.Click += (s, e) =>
            {
                mainPanel.Controls.Clear();
                var uc = new UC_TiepNhanLichChuyenBay();
                uc.Dock = DockStyle.Fill;
                mainPanel.Controls.Add(uc);
            };

            navPanel.Controls.Add(btnTiepNhanChuyenBay);
        }
    }
}
