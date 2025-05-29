using Guna.UI2.WinForms;
using QLBVBM.BUS;
using QLBVBM.DTO;

namespace QLBVBM.GUI
{
    public partial class UC_TraCuuChuyenBay : UserControl
    {
        private BUS_SanBay busSanBay = new BUS_SanBay();
        private BUS_ChuyenBay busChuyenBay = new BUS_ChuyenBay();
        private BUS_HangGhe busHangGhe = new BUS_HangGhe();
        private ToolTip toolTip = new ToolTip();
        private readonly Guna2TextBox[] numericTextBoxes;

        public UC_TraCuuChuyenBay()
        {
            InitializeComponent();
            numericTextBoxes =
            [
                 txtThoiGianBayTu, txtThoiGianBayDen,
                 txtThoiGianDungSBTG1_Tu, txtThoiGianDungSBTG1_Den,
                 txtThoiGianDungSBTG2_Tu, txtThoiGianDungSBTG2_Den,
                 txtDonGiaQuyDinhHangVeTu, txtDonGiaQuyDinhHangVeDen,
                 txtSLGheHangVeTu, txtSLGheHangVeDen,
                 txtSLGheConLaiHangVeTu, txtSLGheConLaiHangVeDen,
                 txtDonGiaVeTu, txtDonGiaVeDen,
                 txtSoCMNDHanhKhach, txtSoDienThoaiHanhKhach
            ];
            SetResponsive();
        }

        private async void GUI_TraCuuChuyenBay_Load(object sender, EventArgs e)
        {
            txtThoiGianBayTu.Tag = "Thời gian bay";
            txtThoiGianBayDen.Tag = "Thời gian bay";

            txtThoiGianDungSBTG1_Tu.Tag = "Thời gian dừng ở sân bay trung gian";
            txtThoiGianDungSBTG1_Den.Tag = "Thời gian dừng ở sân bay trung gian";
            txtThoiGianDungSBTG2_Tu.Tag = "Thời gian dừng sân bay trung gian";
            txtThoiGianDungSBTG2_Den.Tag = "Thời gian dừng sân bay trung gian";

            txtDonGiaQuyDinhHangVeTu.Tag = "Đơn giá quy định của hạng vé";
            txtDonGiaQuyDinhHangVeDen.Tag = "Đơn giá quy định của hạng vé";

            txtSLGheHangVeTu.Tag = "Số lượng ghế của hạng vé";
            txtSLGheHangVeDen.Tag = "Số lượng ghế của hạng vé";

            txtSLGheConLaiHangVeTu.Tag = "Số lượng ghế còn lại của hạng vé";
            txtSLGheConLaiHangVeDen.Tag = "Số lượng ghế còn lại của hạng vé";

            txtDonGiaVeTu.Tag = "Đơn giá vé chuyến bay";
            txtDonGiaVeDen.Tag = "Đơn giá vé chuyến bay";

            txtSoCMNDHanhKhach.Tag = "Số chứng minh nhân dân của hành khách";
            txtSoDienThoaiHanhKhach.Tag = "Số điện thoại của hành khách";

            ConfigureDateTimePicker(dtpNgayBayTu, "dddd, dd/MM/yyyy");
            ConfigureDateTimePicker(dtpNgayBayDen, "dddd, dd/MM/yyyy");
            ConfigureDateTimePicker(dtpGioBayTu, "HH:mm");
            ConfigureDateTimePicker(dtpGioBayDen, "HH:mm");
            foreach (var textBox in numericTextBoxes)
            {
                textBox.KeyPress += RestrictToDigitsOnly;
            }

            ConfigureDataGridView();

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
                        var dsSanBayDi_TuyenBay = new List<DTO_SanBay>(dsSanBay);
                        var dsSanBayDen_TuyenBay = new List<DTO_SanBay>(dsSanBay);

                        LoadDanhSachSanBayToComboBox(cbbTenSanBayDi, dsSanBayDi);
                        LoadDanhSachSanBayToComboBox(cbbTenSanBayDen, dsSanBayDen);
                        LoadDanhSachSanBayToComboBox(cbbTenSanBayTG1, dsSanBayTG1);
                        LoadDanhSachSanBayToComboBox(cbbTenSanBayTG2, dsSanBayTG2);
                        LoadDanhSachSanBayToComboBox(cbbTuyenBay_SBDi, dsSanBayDi_TuyenBay);
                        LoadDanhSachSanBayToComboBox(cbbTuyenBay_SBDen, dsSanBayDen_TuyenBay);

                        if (cbbTenSanBayDi.Items.Count > 0) cbbTenSanBayDi.SelectedIndex = 0;
                        if (cbbTenSanBayDen.Items.Count > 0) cbbTenSanBayDen.SelectedIndex = 0;
                        if (cbbTenSanBayTG1.Items.Count > 0) cbbTenSanBayTG1.SelectedIndex = 0;
                        if (cbbTenSanBayTG2.Items.Count > 0) cbbTenSanBayTG2.SelectedIndex = 0;
                        if (cbbTuyenBay_SBDi.Items.Count > 0) cbbTuyenBay_SBDi.SelectedIndex = 0;
                        if (cbbTuyenBay_SBDen.Items.Count > 0) cbbTuyenBay_SBDen.SelectedIndex = 0;

                        var dsHangGhe_Ten = new List<DTO_HangGhe>(dsHangGhe);
                        var dsHangGhe_DonGia = new List<DTO_HangGhe>(dsHangGhe);
                        var dsHangGhe_SLGhe = new List<DTO_HangGhe>(dsHangGhe);
                        var dsHangGhe_SLGheConLai = new List<DTO_HangGhe>(dsHangGhe);

                        LoadDanhSachHangGheToComboBox(cbbTenHangGhe, dsHangGhe_Ten);
                        LoadDanhSachHangGheToComboBox(cbbHangVe_DonGiaQuyDinh, dsHangGhe_DonGia);
                        LoadDanhSachHangGheToComboBox(cbbHangVe_SLGhe, dsHangGhe_SLGhe);
                        LoadDanhSachHangGheToComboBox(cbbHangVe_SLGheConLai, dsHangGhe_SLGheConLai);


                        if (cbbTenHangGhe.Items.Count > 0) cbbTenHangGhe.SelectedIndex = 0;
                        if (cbbHangVe_DonGiaQuyDinh.Items.Count > 0) cbbHangVe_DonGiaQuyDinh.SelectedIndex = 0;
                        if (cbbHangVe_SLGhe.Items.Count > 0) cbbHangVe_SLGhe.SelectedIndex = 0;
                        if (cbbHangVe_SLGheConLai.Items.Count > 0) cbbHangVe_SLGheConLai.SelectedIndex = 0;


                        LoadTrangThaiOptions();
                    });
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi nạp dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDateTimePicker(Guna2DateTimePicker dtp, string format)
        {
            dtp.Checked = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = " "; // Hiển thị trống khi không chọn
            dtp.Value = DateTime.Now;

            dtp.CheckedChanged += (s, e) =>
            {
                dtp.CustomFormat = dtp.Checked ? format : " ";
            };
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

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            if (!CheckInputData())
            {
                MessageBox.Show("Vui lòng nhập ít nhất 1 thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                foreach (var textBox in numericTextBoxes)
                {
                    if (!string.IsNullOrWhiteSpace(textBox.Text) && !int.TryParse(textBox.Text.Trim(), out _))
                    {
                        string fieldName = textBox.Tag?.ToString() ?? "Trường";
                        MessageBox.Show($"Vui lòng chỉ nhập số nguyên cho mục \"{fieldName}\".", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox.Clear();
                        textBox.Focus();
                        return;
                    }
                }

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
                string maHangGhe_DonGia = cbbHangVe_DonGiaQuyDinh.SelectedValue?.ToString() ?? "ALL";
                int? donGiaHangVeTu = string.IsNullOrWhiteSpace(txtDonGiaQuyDinhHangVeTu.Text) ? null : int.TryParse(txtDonGiaQuyDinhHangVeTu.Text, out result) ? result : null;
                int? donGiaHangVeDen = string.IsNullOrWhiteSpace(txtDonGiaQuyDinhHangVeDen.Text) ? null : int.TryParse(txtDonGiaQuyDinhHangVeDen.Text, out result) ? result : null;
                string maHangGhe_SLGhe = cbbHangVe_SLGhe.SelectedValue?.ToString() ?? "ALL";
                int? soLuongGheHangVeTu = string.IsNullOrWhiteSpace(txtSLGheHangVeTu.Text) ? null : int.TryParse(txtSLGheHangVeTu.Text, out result) ? result : null;
                int? soLuongGheHangVeDen = string.IsNullOrWhiteSpace(txtSLGheHangVeDen.Text) ? null : int.TryParse(txtSLGheHangVeDen.Text, out result) ? result : null;
                string maHangGhe_SLGheConLai = cbbHangVe_SLGheConLai.SelectedValue?.ToString() ?? "ALL";
                int? soLuongGheConLaiHangVeTu = string.IsNullOrWhiteSpace(txtSLGheConLaiHangVeTu.Text) ? null : int.TryParse(txtSLGheConLaiHangVeTu.Text, out result) ? result : null;
                int? soLuongGheConLaiHangVeDen = string.IsNullOrWhiteSpace(txtSLGheConLaiHangVeDen.Text) ? null : int.TryParse(txtSLGheConLaiHangVeDen.Text, out result) ? result : null;
                string maSanBayDi_TuyenBay = cbbTuyenBay_SBDi.SelectedValue?.ToString() ?? "ALL";
                string maSanBayDen_TuyenBay = cbbTuyenBay_SBDen.SelectedValue?.ToString() ?? "ALL";
                string maVeChuyenBay = string.IsNullOrWhiteSpace(txtMaVeChuyenBay.Text) ? null : txtMaVeChuyenBay.Text.Trim();
                int? trangThaiVe = cbbTrangThaiVe.SelectedValue != null && int.TryParse(cbbTrangThaiVe.SelectedValue.ToString(), out result) ? result : -1;
                int? donGiaVeChuyenBayTu = string.IsNullOrWhiteSpace(txtDonGiaVeTu.Text) ? null : int.TryParse(txtDonGiaVeTu.Text, out result) ? result : null;
                int? donGiaVeChuyenBayDen = string.IsNullOrWhiteSpace(txtDonGiaVeDen.Text) ? null : int.TryParse(txtDonGiaVeDen.Text, out result) ? result : null;
                string tenHanhKhach = string.IsNullOrWhiteSpace(txtTenHanhKhach.Text) ? null : txtTenHanhKhach.Text.Trim();
                string soCMND = string.IsNullOrWhiteSpace(txtSoCMNDHanhKhach.Text) ? null : txtSoCMNDHanhKhach.Text.Trim();
                string soDT = string.IsNullOrWhiteSpace(txtSoDienThoaiHanhKhach.Text) ? null : txtSoDienThoaiHanhKhach.Text.Trim();

                var dsChuyenBay = busChuyenBay.TraCuuChuyenBayNangCao(
                    maChuyenBay, maSanBayDi, maSanBayDen, ngayBayTu, ngayBayDen,
                    gioBayTu, gioBayDen, thoiGianBayTu, thoiGianBayDen,
                    maSanBayTG1, ghiChuSanBayTG1, thoiGianDungSBTG1_Tu, thoiGianDungSBTG1_Den,
                    maSanBayTG2, ghiChuSanBayTG2, thoiGianDungSBTG2_Tu, thoiGianDungSBTG2_Den,
                    maHangGhe_Ten, maHangGhe_DonGia, donGiaHangVeTu, donGiaHangVeDen,
                    maSanBayDi_TuyenBay, maSanBayDen_TuyenBay,
                    maHangGhe_SLGhe, soLuongGheHangVeTu, soLuongGheHangVeDen,
                    maHangGhe_SLGheConLai, soLuongGheConLaiHangVeTu, soLuongGheConLaiHangVeDen,
                    maVeChuyenBay, trangThaiVe, donGiaVeChuyenBayTu, donGiaVeChuyenBayDen, tenHanhKhach, soCMND, soDT);
                if (dsChuyenBay != null && dsChuyenBay.Count > 0)
                {
                    dgvDanhSachChuyenBay.DataSource = dsChuyenBay;
                    ConfigureDataGridView();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy chuyến bay nào phù hợp với tiêu chí.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDanhSachChuyenBay.DataSource = null;
                    ConfigureDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tra cứu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            dgvDanhSachChuyenBay.ReadOnly = true;
            dgvDanhSachChuyenBay.Columns.Clear();
            Font headerFont = new Font("Arial", 10, FontStyle.Bold);

            dgvDanhSachChuyenBay.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvDanhSachChuyenBay.GridColor = Color.Gray;
            dgvDanhSachChuyenBay.ColumnHeadersDefaultCellStyle.Font = headerFont;
            dgvDanhSachChuyenBay.EnableHeadersVisualStyles = false;
            dgvDanhSachChuyenBay.ColumnHeadersHeight = 32;
            dgvDanhSachChuyenBay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            DataGridViewTextBoxColumn colSTT = new DataGridViewTextBoxColumn
            {
                Name = "colSTT",
                HeaderText = "STT",
                DataPropertyName = "STT",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            DataGridViewTextBoxColumn colMaChuyenBay = new DataGridViewTextBoxColumn
            {
                Name = "MaChuyenBay",
                HeaderText = "MÃ CHUYẾN BAY",
                DataPropertyName = "MaChuyenBay",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            DataGridViewTextBoxColumn colMaSanBayDi = new DataGridViewTextBoxColumn
            {
                Name = "MaSanBayDi",
                HeaderText = "MÃ SÂN BAY ĐI",
                DataPropertyName = "MaSanBayDi",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            DataGridViewTextBoxColumn colMaSanBayDen = new DataGridViewTextBoxColumn
            {
                Name = "MaSanBayDen",
                HeaderText = "MÃ SÂN BAY ĐẾN",
                DataPropertyName = "MaSanBayDen",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            DataGridViewTextBoxColumn colNgayBay = new DataGridViewTextBoxColumn
            {
                Name = "NgayBay",
                HeaderText = "NGÀY BAY",
                DataPropertyName = "NgayBay",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            colNgayBay.DefaultCellStyle.Format = "dd/MM/yyyy";
            DataGridViewTextBoxColumn colGioBay = new DataGridViewTextBoxColumn
            {
                Name = "GioBay",
                HeaderText = "GIỜ BAY",
                DataPropertyName = "GioBay",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            colGioBay.DefaultCellStyle.Format = "HH:mm";
            DataGridViewTextBoxColumn colThoiGianBay = new DataGridViewTextBoxColumn
            {
                Name = "ThoiGianBay",
                HeaderText = "THỜI GIAN BAY",
                DataPropertyName = "ThoiGianBay",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            DataGridViewTextBoxColumn colSoGheDat = new DataGridViewTextBoxColumn
            {
                Name = "SoGheDat",
                HeaderText = "SỐ GHẾ ĐẶT",
                DataPropertyName = "SoGheDat",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            DataGridViewTextBoxColumn colSoGheTrong = new DataGridViewTextBoxColumn
            {
                Name = "SoGheTrong",
                HeaderText = "SỐ GHẾ TRỐNG",
                DataPropertyName = "SoGheTrong",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            dgvDanhSachChuyenBay.Columns.Add(colSTT);
            dgvDanhSachChuyenBay.Columns.Add(colMaChuyenBay);
            dgvDanhSachChuyenBay.Columns.Add(colMaSanBayDi);
            dgvDanhSachChuyenBay.Columns.Add(colMaSanBayDen);
            dgvDanhSachChuyenBay.Columns.Add(colNgayBay);
            dgvDanhSachChuyenBay.Columns.Add(colGioBay);
            dgvDanhSachChuyenBay.Columns.Add(colThoiGianBay);
            dgvDanhSachChuyenBay.Columns.Add(colSoGheDat);
            dgvDanhSachChuyenBay.Columns.Add(colSoGheTrong);
            dgvDanhSachChuyenBay.ColumnHeadersVisible = true;
            dgvDanhSachChuyenBay.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            foreach (DataGridViewColumn column in dgvDanhSachChuyenBay.Columns)
            {
                if (column.Name != "colSTT")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.HeaderCell.Style.Font = headerFont;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.SortMode = DataGridViewColumnSortMode.Automatic;
                column.Resizable = DataGridViewTriState.False;
            }
            foreach (DataGridViewRow row in dgvDanhSachChuyenBay.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular);
                row.Resizable = DataGridViewTriState.False;
            }

            if (dgvDanhSachChuyenBay.Columns.Contains("colSTT"))
            {
                for (int i = 0; i < dgvDanhSachChuyenBay.Rows.Count; i++)
                {
                    if (!dgvDanhSachChuyenBay.Rows[i].IsNewRow)
                    {
                        dgvDanhSachChuyenBay.Rows[i].Cells["colSTT"].Value = (i + 1).ToString();
                    }
                }
            }
        }

        private void RestrictToDigitsOnly(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool CheckInputData()
        {
            foreach (var textBox in numericTextBoxes)
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    return true;
                }
            }

            var otherTextBoxes = new[]
            {
               txtMaChuyenBay,
               txtGhiChuSBTG1,
               txtGhiChuSBTG2,
               txtMaVeChuyenBay,
               txtTenHanhKhach
           };
            foreach (var textBox in otherTextBoxes)
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    return true;
                }
            }

            var comboBoxes = new[]
            {
               cbbTenSanBayDi,
               cbbTenSanBayDen,
               cbbTenSanBayTG1,
               cbbTenSanBayTG2,
               cbbTuyenBay_SBDi,
               cbbTuyenBay_SBDen,
               cbbTenHangGhe,
               cbbHangVe_DonGiaQuyDinh,
               cbbHangVe_SLGhe,
               cbbHangVe_SLGheConLai,
               cbbTrangThaiVe
           };

            foreach (var comboBox in comboBoxes)
            {
                if (comboBox.SelectedIndex > 0 && comboBox.Text != "ALL")
                {
                    return true;
                }
            }

            var dateTimePickers = new[]
            {
               dtpNgayBayTu,
               dtpNgayBayDen,
               dtpGioBayTu,
               dtpGioBayDen
           };
            foreach (var dtp in dateTimePickers)
            {
                if (dtp.Checked)
                {
                    return true;
                }
            }
            return false;
        }
    }
}