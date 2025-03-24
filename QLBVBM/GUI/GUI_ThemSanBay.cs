using QLBVBM.BUS;
using QLBVBM.DTO;
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
    public partial class GUI_ThemSanBay : Form
    {
        private BUS_SanBay busSanBay = new BUS_SanBay();

        public GUI_ThemSanBay()
        {
            InitializeComponent();
        }

        private void LoadDanhSachSanBay()
        {
            var dsSanBay = busSanBay.LayDanhSachSanBay();
            if (dsSanBay != null && dsSanBay.Count > 0)
            {
                dgvSanBay.DataSource = dsSanBay;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu sân bay.");
            }
        }

        private void GUI_ThemSanBay_Load(object sender, EventArgs e)
        {
            LoadDanhSachSanBay();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DTO_SanBay newSanBay = new DTO_SanBay
            {
                MaSanBay = txtMaSanBay.Text,
                TenSanBay = txtTenSanBay.Text
            };

            if (busSanBay.ThemSanBay(newSanBay))
            {
                MessageBox.Show("Thêm sân bay thành công");
                LoadDanhSachSanBay();
            }
            else
            {
                MessageBox.Show("Thêm sân bay thất bại");
            }
        }
    }
}
