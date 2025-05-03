using QLBVBM.BUS;
using QLBVBM.DTO;
using QLBVBM.GUI;
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
    public partial class GUI_TraCuuChuyenBay : Form
    {
        private BUS_SanBay busSanBay = new BUS_SanBay();
        private BUS_ChuyenBay busChuyenBay = new BUS_ChuyenBay();
        private BUS_DonGiaHangGhe busDonGiaHangGhe = new BUS_DonGiaHangGhe();
        private ToolTip toolTip = new ToolTip();

        public GUI_TraCuuChuyenBay()
        {
            InitializeComponent();
            SetResponsive();
        }

        private async void GUI_TraCuuChuyenBay_Load(object sender, EventArgs e)
        {
            dtpNgayBayTu.Value = DateTime.Now; 
            dtpNgayBayDen.Value = DateTime.Now; 
            dtpGioBayTu.Value = DateTime.Now; 
            dtpGioBayDen.Value = DateTime.Now; 
            dtpThoiDiemThanhToanVeTu.Value = DateTime.Now;
            dtpThoiDiemThanhToanVeDen.Value = DateTime.Now;

            try
            {
                await Task.Run(() =>
                {
                    var dsSanBay = LayDanhSachSanBay();
                    this.Invoke((MethodInvoker)delegate
                    {
                        LoadDanhSachSanBayToComboBox(cbbTenSanBayDi, dsSanBay);
                        LoadDanhSachSanBayToComboBox(cbbTenSanBayDen, dsSanBay);
                        LoadDanhSachSanBayToComboBox(cbbTenSanBayTG1, dsSanBay);
                        LoadDanhSachSanBayToComboBox(cbbTenSanBayTG2, dsSanBay);

                        if (cbbTenSanBayDi.Items.Count > 0) cbbTenSanBayDi.SelectedIndex = 0;
                        if (cbbTenSanBayDen.Items.Count > 0) cbbTenSanBayDen.SelectedIndex = 0;
                        if (cbbTenSanBayTG1.Items.Count > 0) cbbTenSanBayTG1.SelectedIndex = 0;
                        if (cbbTenSanBayTG2.Items.Count > 0) cbbTenSanBayTG2.SelectedIndex = 0;
                    });
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi nạp dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region non-logic code block
        public void SetResponsive()
        {
            foreach (Control control in this.Controls)
            {
                control.Anchor = AnchorStyles.None;
            }
        }

        public void ClearCombobox(Guna2ComboBox cbb)
        {
            cbb.DataSource = null;
            cbb.Items.Clear();
            cbb.Enabled = false;
            cbb.Text = "";
            cbb.SelectedIndex = -1;
        }
        #endregion

        private List<DTO_SanBay> LayDanhSachSanBay()
        {
            List<DTO_SanBay> dsSanBay = busSanBay.LayDanhSachSanBay();
            dsSanBay.Insert(0, new DTO_SanBay { MaSanBay = "ALL", TenSanBay = "Tất cả" });
            return dsSanBay;
        }

        public void LoadDanhSachSanBayToComboBox(Guna2ComboBox cbb, List<DTO_SanBay> dsSanBay)
        {
            if (dsSanBay != null && dsSanBay.Count > 0)
            {
                cbb.DataSource = dsSanBay;
                cbb.DisplayMember = "TenSanBay";
                cbb.ValueMember = "MaSanBay";

                cbb.SelectedIndexChanged += (s, e) =>
                {
                    if (cbb.SelectedItem is DTO_SanBay selectedSanBay)
                    {
                        toolTip.SetToolTip(cbb, selectedSanBay.MaSanBay);
                    }
                };
            }
        }

    }
}
