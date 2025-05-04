using Guna.UI2.WinForms;
using QLBVBM.BUS;
using QLBVBM.DTO;

namespace QLBVBM.GUI
{
    public partial class GUI_TraCuuChuyenBay : Form
    {
        private BUS_SanBay busSanBay = new BUS_SanBay();
        private BUS_ChuyenBay busChuyenBay = new BUS_ChuyenBay();
        private BUS_HangGhe busHangGhe = new BUS_HangGhe();
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
                    var dsHangGhe = LayDanhSachHangGhe();
                    var dsSanBay = LayDanhSachSanBay();
                    this.Invoke((MethodInvoker)delegate
                    {
                        var dsSanBayDi = new List<DTO_SanBay>(dsSanBay);
                        var dsSanBayDen = new List<DTO_SanBay>(dsSanBay);
                        var dsSanBayTG1 = new List<DTO_SanBay>(dsSanBay);
                        var dsSanBayTG2 = new List<DTO_SanBay>(dsSanBay);

                        LoadDanhSachSanBayToComboBox(cbbTenSanBayDi, dsSanBayDi);
                        LoadDanhSachSanBayToComboBox(cbbTenSanBayDen, dsSanBayDen);
                        LoadDanhSachSanBayToComboBox(cbbTenSanBayTG1, dsSanBayTG1);
                        LoadDanhSachSanBayToComboBox(cbbTenSanBayTG2, dsSanBayTG2);

                        if (cbbTenSanBayDi.Items.Count > 0) cbbTenSanBayDi.SelectedIndex = 0;
                        if (cbbTenSanBayDen.Items.Count > 0) cbbTenSanBayDen.SelectedIndex = 0;
                        if (cbbTenSanBayTG1.Items.Count > 0) cbbTenSanBayTG1.SelectedIndex = 0;
                        if (cbbTenSanBayTG2.Items.Count > 0) cbbTenSanBayTG2.SelectedIndex = 0;

                        var dsHangGhe_Ten = new List<DTO_HangGhe>(dsHangGhe);
                        var dsHangGhe_DonGia = new List<DTO_HangGhe>(dsHangGhe);
                        var dsHangGhe_SLGhe = new List<DTO_HangGhe>(dsHangGhe);
                        var dsHangGhe_SLGheDaBan = new List<DTO_HangGhe>(dsHangGhe);
                        var dsHangGhe_SLGheDaDat = new List<DTO_HangGhe>(dsHangGhe);

                        LoadDanhSachHangGheToComboBox(cbbTenHangGhe, dsHangGhe_Ten);
                        LoadDanhSachHangGheToComboBox(cbbHangVe_DonGia, dsHangGhe_DonGia);
                        LoadDanhSachHangGheToComboBox(cbbHangVe_SLGhe, dsHangGhe_SLGhe);
                        LoadDanhSachHangGheToComboBox(cbbHangVe_SLGheDaBan, dsHangGhe_SLGheDaBan);
                        LoadDanhSachHangGheToComboBox(cbbHangVe_SLGheDaDat, dsHangGhe_SLGheDaDat);

                        if (cbbTenHangGhe.Items.Count > 0) cbbTenHangGhe.SelectedIndex = 0;
                        if (cbbHangVe_DonGia.Items.Count > 0) cbbHangVe_DonGia.SelectedIndex = 0;
                        if (cbbHangVe_SLGhe.Items.Count > 0) cbbHangVe_SLGhe.SelectedIndex = 0;
                        if (cbbHangVe_SLGheDaBan.Items.Count > 0) cbbHangVe_SLGheDaBan.SelectedIndex = 0;
                        if (cbbHangVe_SLGheDaDat.Items.Count > 0) cbbHangVe_SLGheDaDat.SelectedIndex = 0;

                        LoadTrangThaiOptions();
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
                control.Anchor = AnchorStyles.Top;
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
        private List<DTO_HangGhe> LayDanhSachHangGhe()
        {
            List<DTO_HangGhe> dsHangGhe = busHangGhe.LayDanhSachHangGhe();
            dsHangGhe.Insert(0, new DTO_HangGhe { MaHangGhe = "ALL", TenHangGhe = "Tất cả" });
            return dsHangGhe;
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
        public void LoadDanhSachHangGheToComboBox(Guna2ComboBox cbb, List<DTO_HangGhe> dsHangGhe)
        {
            if (dsHangGhe != null && dsHangGhe.Count > 0)
            {
                cbb.DataSource = dsHangGhe;
                cbb.DisplayMember = "TenHangGhe";
                cbb.ValueMember = "MaHangGhe";

                cbb.SelectedIndexChanged += (s, e) =>
                {
                    if (cbb.SelectedItem is DTO_HangGhe selectedHangGhe)
                    {
                        toolTip.SetToolTip(cbb, selectedHangGhe.MaHangGhe);
                    }
                };
            }
        }

        private void LoadTrangThaiOptions()
        {
            List<string> trangThaiOptions = new List<string> { "Tất cả", "Đã thanh toán", "Chưa thanh toán", "Đã huỷ" };
            cbbTrangThaiVe.DataSource = trangThaiOptions;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
