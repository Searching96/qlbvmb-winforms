using Guna.UI2.WinForms;
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
    public partial class GUI_TimChuyenBay : Form
    {
        private BUS_SanBay busSanBay = new BUS_SanBay();
        private BUS_ChuyenBay busChuyenBay = new BUS_ChuyenBay();

        public GUI_TimChuyenBay()
        {
            InitializeComponent();
            SetResponsive();
            LoadDanhSachSanBayToComboBox(cbbSanBayDi, LayDanhSachSanBay());
            LoadDanhSachSanBayToComboBox(cbbSanBayDen, LayDanhSachSanBay());
        }

        public void SetResponsive()
        {
            foreach (Control control in this.Controls)
            {
                control.Anchor = AnchorStyles.None;
            }
        }

        public void ClearCombobox(Guna2ComboBox cbb) // clear the combobox and set it to disabled
        {
            cbb.DataSource = null;
            cbb.Items.Clear();
            cbb.Enabled = false;
            cbb.Text = "";
            cbb.SelectedIndex = -1;
        }

        public List<DTO_SanBay> LayDanhSachSanBay()
        {
            List<DTO_SanBay> dsSanBay = busSanBay.LayDanhSachSanBay();
            dsSanBay.Insert(0, new DTO_SanBay { MaSanBay = "", TenSanBay = "" });
            return dsSanBay;
        }

        public void LoadDanhSachSanBayToComboBox(Guna2ComboBox cbb, List<DTO_SanBay> dsSanBay)
        {
            if (dsSanBay != null && dsSanBay.Count > 1) // since we add an empty item at index 0
            {
                cbb.DataSource = dsSanBay;
                cbb.DisplayMember = "TenSanBay";
                cbb.ValueMember = "MaSanBay";

                // Add tooltip to display MaSanBay
                ToolTip toolTip = new ToolTip();
                cbb.SelectedIndexChanged += (s, e) =>
                {
                    if (cbb.SelectedItem is DTO_SanBay selectedSanBay)
                    {
                        toolTip.SetToolTip(cbb, selectedSanBay.MaSanBay);
                    }
                };
            }
        }

        private void FlightInfo_Changed(object sender, EventArgs e)
        {
            bool isDateSelected = dtpNgayBay.Value.Date > DateTime.Today.Date;

            if (cbbSanBayDi.SelectedIndex != -1
                && cbbSanBayDen.SelectedIndex != -1
                && isDateSelected)
            {
                cbbDSChuyenBay.Enabled = true;

                // Load Flight Info
                string maSanBayDi = cbbSanBayDi.SelectedValue.ToString();
                string maSanBayDen = cbbSanBayDen.SelectedValue.ToString();
                string ngayBay = dtpNgayBay.Value.ToString("yyyy-MM-dd");

                if (string.IsNullOrWhiteSpace(maSanBayDi) || string.IsNullOrWhiteSpace(maSanBayDen))
                {
                    //MessageBox.Show("Vui lòng chọn sân bay đi và sân bay đến.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (maSanBayDi == maSanBayDen)
                {
                    //MessageBox.Show("Sân bay đi và sân bay đến không được giống nhau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<DTO_ChuyenBay> dsChuyenBay = busChuyenBay.TraCuuChuyenBay(maSanBayDi, maSanBayDen, ngayBay);
                
                if (dsChuyenBay != null && dsChuyenBay.Count > 0)
                {
                    LoadMaChuyenBay(cbbDSChuyenBay, dsChuyenBay);
                }
                else
                {
                    //MessageBox.Show("Không tìm thấy chuyến bay nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearCombobox(cbbDSChuyenBay);
                }
            }
            else
            {
                cbbDSChuyenBay.Enabled = false;
                ClearCombobox(cbbDSChuyenBay);
            }
        }

        public void LoadMaChuyenBay(Guna2ComboBox cbb, List<DTO_ChuyenBay> dsChuyenBay)
        {
            if (dsChuyenBay != null && dsChuyenBay.Count > 0)
            {
                cbb.Enabled = true; // turn on the combobox
                cbb.DataSource = dsChuyenBay;
                cbb.DisplayMember = "MaChuyenBay";
                cbb.ValueMember = "MaChuyenBay";
                // Add tooltip to display MaChuyenBay
                ToolTip toolTip = new ToolTip();
                cbb.SelectedIndexChanged += (s, e) =>
                {
                    if (cbb.SelectedItem is DTO_ChuyenBay selectedChuyenBay)
                    {
                        toolTip.SetToolTip(cbb, selectedChuyenBay.GioBay.ToString());
                    }
                };
            }
        }
    }
}
