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
    public partial class GUI_TiepNhanLichChuyenBay : Form
    {
        private BUS_SanBay BUS_SanBay = new BUS_SanBay();
        private BUS_ChuyenBay BUS_ChuyenBay = new BUS_ChuyenBay();

        public GUI_TiepNhanLichChuyenBay()
        {
            InitializeComponent();
            SetupDgvColumns(dgvDSSanBayTG, 2, BUS_SanBay.LayDanhSachSanBay());
            PhatSinhMaChuyenBay();
            LoadSanBayToComboBox(cbbSanBayDi);
            LoadSanBayToComboBox(cbbSanBayDen);
        }

        private void LoadSanBayToComboBox(ComboBox cbb)
        {
            List<DTO_SanBay> dsSanBay = BUS_SanBay.LayDanhSachSanBay();
            if (dsSanBay != null && dsSanBay.Count > 0)
            {
                cbb.DataSource = dsSanBay;
                cbb.DisplayMember = "TenSanBay";
                cbb.ValueMember = "MaSanBay";
            }
        }

        private void PhatSinhMaChuyenBay()
        {
            DTO_ChuyenBay chuyenBayCuoi = BUS_ChuyenBay.LayChuyenBayCuoi();
            if (chuyenBayCuoi != null)
            {
                string maChuyenBayCuoi = chuyenBayCuoi.MaChuyenBay;
                int lastNumber = int.Parse(maChuyenBayCuoi.Substring(2));
                string maChuyenBayMoi = "CB" + (lastNumber + 1) .ToString("D5");
                txtMaChuyenBay.Text = maChuyenBayMoi;
            }
            else
            {
                txtMaChuyenBay.Text = "CB00001";
            }
        }


        private void SetupDgvColumns(DataGridView dgv, int rowCount, List<DTO_SanBay> dsSanBay)
        {
            dgv.Columns.Clear();
            dgv.RowHeadersVisible = false;

            DataGridViewTextBoxColumn colSTT = new DataGridViewTextBoxColumn
            {
                Name = "STT",
                HeaderText = "STT",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 50,
                ReadOnly = true
            };
            dgv.Columns.Add(colSTT);

            DataGridViewComboBoxColumn colTenSanBay = new DataGridViewComboBoxColumn
            {
                Name = "TenSanBay",
                HeaderText = "Tên sân bay",
                DataSource = dsSanBay,
                DisplayMember = "TenSanBay",
                ValueMember = "MaSanBay"
            };
            dgv.Columns.Add(colTenSanBay);

            DataGridViewTextBoxColumn colThoiGianDung = new DataGridViewTextBoxColumn
            {
                Name = "ThoiGianDung",
                HeaderText = "Thời gian dừng",
            };
            dgv.Columns.Add(colThoiGianDung);

            DataGridViewTextBoxColumn colGhiChu = new DataGridViewTextBoxColumn
            {
                Name = "GhiChu",
                HeaderText = "Ghi chú"
            };
            dgv.Columns.Add(colGhiChu);

            dgv.Rows.Clear();
            for (int i = 0; i < rowCount; i++)
            {
                dgv.Rows.Add(i + 1, "", "", "");
            }
        }
    }
}
