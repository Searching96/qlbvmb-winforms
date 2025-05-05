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
            var bus_VeChuyenBay = new BUS_VeChuyenBay();
            cbbTrangThaiVe.DataSource = new BindingSource(bus_VeChuyenBay.GetTrangThaiOptions(), null);
            cbbTrangThaiVe.DisplayMember = "Value";
            cbbTrangThaiVe.ValueMember = "Key";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Collect input from form controls  
                string maChuyenBay = string.IsNullOrWhiteSpace(txtMaChuyenBay.Text) ? null : txtMaChuyenBay.Text.Trim();
                string maSanBayDi = cbbTenSanBayDi.SelectedValue?.ToString() ?? "ALL";
                string maSanBayDen = cbbTenSanBayDen.SelectedValue?.ToString() ?? "ALL";
                DateTime? ngayBayTu = dtpNgayBayTu.Checked ? dtpNgayBayTu.Value : null;
                DateTime? ngayBayDen = dtpNgayBayDen.Checked ? dtpNgayBayDen.Value : null;
                DateTime? gioBayTu = dtpGioBayTu.Checked ? dtpGioBayTu.Value : null;
                DateTime? gioBayDen = dtpGioBayDen.Checked ? dtpGioBayDen.Value : null;
                int? thoiGianBayTu = string.IsNullOrWhiteSpace(txtThoiGianBayTu.Text) ? null : int.TryParse(txtThoiGianBayTu.Text, out int result) ? result : null;
                int? thoiGianBayDen = string.IsNullOrWhiteSpace(txtThoiGianBayDen.Text) ? null : int.TryParse(txtThoiGianBayDen.Text, out result) ? result : null;
                string maSanBayTG1 = cbbTenSanBayTG1.SelectedValue?.ToString() ?? "ALL";
                string ghiChuSanBayTG1 = string.IsNullOrWhiteSpace(txtGhiChuSBTG1.Text) ? null : txtGhiChuSBTG1.Text.Trim();
                int? thoiGianDungSBTG1_Tu = string.IsNullOrWhiteSpace(txtThoiGianDungSBTG1_Tu.Text) ? null : int.TryParse(txtThoiGianDungSBTG1_Tu.Text, out result) ? result : null;
                int? thoiGianDungSBTG1_Den = string.IsNullOrWhiteSpace(txtThoiGianDungSBTG1_Den.Text) ? null : int.TryParse(txtThoiGianDungSBTG1_Den.Text, out result) ? result : null;
                string maSanBayTG2 = cbbTenSanBayTG2.SelectedValue?.ToString() ?? "ALL";
                string ghiChuSanBayTG2 = string.IsNullOrWhiteSpace(txtGhiChuSBTG2.Text) ? null : txtGhiChuSBTG2.Text.Trim();
                int? thoiGianDungSBTG2_Tu = string.IsNullOrWhiteSpace(txtThoiGianDungSBTG2_Tu.Text) ? null : int.TryParse(txtThoiGianDungSBTG2_Tu.Text, out result) ? result : null;
                int? thoiGianDungSBTG2_Den = string.IsNullOrWhiteSpace(txtThoiGianDungSBTG2_Den.Text) ? null : int.TryParse(txtThoiGianDungSBTG2_Den.Text, out result) ? result : null;
                string maHangGhe_Ten = cbbTenHangGhe.SelectedValue?.ToString() ?? "ALL";
                string maHangGhe_DonGia = cbbHangVe_DonGia.SelectedValue?.ToString() ?? "ALL";
                int? donGiaHangVeTu = string.IsNullOrWhiteSpace(txtDonGiaHangVeTu.Text) ? null : int.TryParse(txtDonGiaHangVeTu.Text, out result) ? result : null;
                int? donGiaHangVeDen = string.IsNullOrWhiteSpace(txtDonGiaHangVeDen.Text) ? null : int.TryParse(txtDonGiaHangVeDen.Text, out result) ? result : null;
                string maHangGhe_SLGhe = cbbHangVe_SLGhe.SelectedValue?.ToString() ?? "ALL";
                int? soLuongGheHangVeTu = string.IsNullOrWhiteSpace(txtSLGheHangVeTu.Text) ? null : int.TryParse(txtSLGheHangVeTu.Text, out result) ? result : null;
                int? soLuongGheHangVeDen = string.IsNullOrWhiteSpace(txtSLGheHangVeDen.Text) ? null : int.TryParse(txtSLGheHangVeDen.Text, out result) ? result : null;
                string maHangGhe_SLGheDaBan = cbbHangVe_SLGheDaBan.SelectedValue?.ToString() ?? "ALL";
                int? soLuongGheHangVeDaBanTu = string.IsNullOrWhiteSpace(txtSLGheDaBanHangVeTu.Text) ? null : int.TryParse(txtSLGheDaBanHangVeTu.Text, out result) ? result : null;
                int? soLuongGheHangVeDaBanDen = string.IsNullOrWhiteSpace(txtSLGheDaBanHangVeDen.Text) ? null : int.TryParse(txtSLGheDaBanHangVeDen.Text, out result) ? result : null;
                string maHangGhe_SLGheDaDat = cbbHangVe_SLGheDaDat.SelectedValue?.ToString() ?? "ALL";
                int? soLuongGheHangVeDaDatTu = string.IsNullOrWhiteSpace(txtSLGheDaDatHangVeTu.Text) ? null : int.TryParse(txtSLGheDaDatHangVeTu.Text, out result) ? result : null;
                int? soLuongGheHangVeDaDatDen = string.IsNullOrWhiteSpace(txtSLGheDaDatHangVeDen.Text) ? null : int.TryParse(txtSLGheDaDatHangVeDen.Text, out result) ? result : null;
                string maVeChuyenBay = string.IsNullOrWhiteSpace(txtMaVeChuyenBay.Text) ? null : txtMaVeChuyenBay.Text.Trim();
                int? trangThaiVe = cbbTrangThaiVe.SelectedValue != null && int.TryParse(cbbTrangThaiVe.SelectedValue.ToString(), out result) ? result : -1;
                string tenHanhKhach = string.IsNullOrWhiteSpace(txtTenHanhKhach.Text) ? null : txtTenHanhKhach.Text.Trim();
                string soCMND = string.IsNullOrWhiteSpace(txtSoCMNDHanhKhach.Text) ? null : txtSoCMNDHanhKhach.Text.Trim();
                string soDT = string.IsNullOrWhiteSpace(txtSoDienThoaiHanhKhach.Text) ? null : txtSoDienThoaiHanhKhach.Text.Trim();
                DateTime? thoiDiemThanhToanTu = dtpThoiDiemThanhToanVeTu.Checked ? dtpThoiDiemThanhToanVeTu.Value : null;
                DateTime? thoiDiemThanhToanDen = dtpThoiDiemThanhToanVeDen.Checked ? dtpThoiDiemThanhToanVeDen.Value : null;

                // Call the search method  
                var dsChuyenBay = busChuyenBay.TraCuuChuyenBayNangCao(
                    maChuyenBay, maSanBayDi, maSanBayDen, ngayBayTu, ngayBayDen,
                    gioBayTu, gioBayDen, thoiGianBayTu, thoiGianBayDen,
                    maSanBayTG1, ghiChuSanBayTG1, thoiGianDungSBTG1_Tu, thoiGianDungSBTG1_Den,
                    maSanBayTG2, ghiChuSanBayTG2, thoiGianDungSBTG2_Tu, thoiGianDungSBTG2_Den,
                    maHangGhe_Ten, maHangGhe_DonGia, donGiaHangVeTu, donGiaHangVeDen,
                    maHangGhe_SLGhe, soLuongGheHangVeTu, soLuongGheHangVeDen,
                    maHangGhe_SLGheDaBan, soLuongGheHangVeDaBanTu, soLuongGheHangVeDaBanDen,
                    maHangGhe_SLGheDaDat, soLuongGheHangVeDaDatTu, soLuongGheHangVeDaDatDen,
                    maVeChuyenBay, trangThaiVe, tenHanhKhach, soCMND, soDT,
                    thoiDiemThanhToanTu, thoiDiemThanhToanDen);

                // Bind data to DataGridView  
                if (dsChuyenBay != null && dsChuyenBay.Count > 0)
                {
                    dgvDanhSachChuyenBay.DataSource = dsChuyenBay;
                    ConfigureDataGridView();
                }
                else
                {
                    dgvDanhSachChuyenBay.DataSource = null;
                    MessageBox.Show("Không tìm thấy chuyến bay nào phù hợp với tiêu chí.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tra cứu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            dgvDanhSachChuyenBay.Columns.Clear();
            Font headerFont = new Font("Arial", 11, FontStyle.Bold);

            // Set the header row color to grey
            dgvDanhSachChuyenBay.ColumnHeadersDefaultCellStyle.BackColor = Color.LightCyan;
            dgvDanhSachChuyenBay.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvDanhSachChuyenBay.ColumnHeadersDefaultCellStyle.Font = headerFont;
            dgvDanhSachChuyenBay.EnableHeadersVisualStyles = false;
            dgvDanhSachChuyenBay.ColumnHeadersHeight = 32;
            dgvDanhSachChuyenBay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Add MaSanBay column
            DataGridViewTextBoxColumn colMaChuyenBay = new DataGridViewTextBoxColumn
            {
                Name = "MaChuyenBay",
                HeaderText = "Mã chuyến bay",
                DataPropertyName = "MaChuyenBay",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            colMaChuyenBay.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colMaChuyenBay.HeaderCell.Style.Font = headerFont;
            dgvDanhSachChuyenBay.Columns.Add(colMaChuyenBay);

            // Add other columns
            DataGridViewTextBoxColumn colMaSanBayDi = new DataGridViewTextBoxColumn
            {
                Name = "MaSanBayDi",
                HeaderText = "Sân bay đi",
                DataPropertyName = "MaSanBayDi",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            colMaSanBayDi.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colMaSanBayDi.HeaderCell.Style.Font = headerFont;
            dgvDanhSachChuyenBay.Columns.Add(colMaSanBayDi);

            DataGridViewTextBoxColumn colMaSanBayDen = new DataGridViewTextBoxColumn
            {
                Name = "MaSanBayDen",
                HeaderText = "Sân bay đến",
                DataPropertyName = "MaSanBayDen",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            colMaSanBayDen.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colMaSanBayDen.HeaderCell.Style.Font = headerFont;
            dgvDanhSachChuyenBay.Columns.Add(colMaSanBayDen);

            DataGridViewTextBoxColumn colNgayBay = new DataGridViewTextBoxColumn
            {
                Name = "NgayBay",
                HeaderText = "Ngày bay",
                DataPropertyName = "NgayBay",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            colNgayBay.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colNgayBay.HeaderCell.Style.Font = headerFont;
            dgvDanhSachChuyenBay.Columns.Add(colNgayBay);

            DataGridViewTextBoxColumn colGioBay = new DataGridViewTextBoxColumn
            {
                Name = "GioBay",
                HeaderText = "Giờ bay",
                DataPropertyName = "GioBay",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            colGioBay.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colGioBay.HeaderCell.Style.Font = headerFont;
            dgvDanhSachChuyenBay.Columns.Add(colGioBay);

            DataGridViewTextBoxColumn colThoiGianBay = new DataGridViewTextBoxColumn
            {
                Name = "ThoiGianBay",
                HeaderText = "Thời gian bay (phút)",
                DataPropertyName = "ThoiGianBay",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            colThoiGianBay.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colThoiGianBay.HeaderCell.Style.Font = headerFont;
            dgvDanhSachChuyenBay.Columns.Add(colThoiGianBay);

            DataGridViewTextBoxColumn colSoGheDat = new DataGridViewTextBoxColumn
            {
                Name = "SoGheDat",
                HeaderText = "Số ghế đặt",
                DataPropertyName = "SoGheDat",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            colSoGheDat.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colSoGheDat.HeaderCell.Style.Font = headerFont;
            dgvDanhSachChuyenBay.Columns.Add(colSoGheDat);

            DataGridViewTextBoxColumn colSoGheTrong = new DataGridViewTextBoxColumn
            {
                Name = "SoGheTrong",
                HeaderText = "Số ghế trống",
                DataPropertyName = "SoGheTrong",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            colSoGheTrong.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colSoGheTrong.HeaderCell.Style.Font = headerFont;
            dgvDanhSachChuyenBay.Columns.Add(colSoGheTrong);


            //dgvDanhSachChuyenBay.Columns["MaChuyenBay"].HeaderText = "Mã Chuyến Bay";
            //dgvDanhSachChuyenBay.Columns["MaSanBayDi"].HeaderText = "Sân Bay Đi";
            //dgvDanhSachChuyenBay.Columns["MaSanBayDen"].HeaderText = "Sân Bay Đến";
            //dgvDanhSachChuyenBay.Columns["NgayBay"].HeaderText = "Ngày Bay";
            //dgvDanhSachChuyenBay.Columns["GioBay"].HeaderText = "Giờ Bay";
            //dgvDanhSachChuyenBay.Columns["ThoiGianBay"].HeaderText = "Thời Gian Bay (phút)";
            //dgvDanhSachChuyenBay.Columns["SoGheDat"].HeaderText = "Số Ghế Đặt";
            //dgvDanhSachChuyenBay.Columns["SoGheTrong"].HeaderText = "Số Ghế Trống";
            dgvDanhSachChuyenBay.ColumnHeadersVisible = true;
            dgvDanhSachChuyenBay.ReadOnly = true;

            // Adjust column widths
            foreach (DataGridViewColumn column in dgvDanhSachChuyenBay.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            // Set the default cell style
            dgvDanhSachChuyenBay.DefaultCellStyle.BackColor = Color.White;
            foreach (DataGridViewRow row in dgvDanhSachChuyenBay.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular);
            }
        }
    }
}
