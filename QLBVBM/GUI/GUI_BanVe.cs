using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBVBM.DAL;
using QLBVBM.DTO;
using QLBVBM.BUS;
using Guna.UI2.WinForms;

namespace QLBVBM.GUI
{
    public partial class GUI_BanVe : Form
    {
        private BUS_SanBay busSanBay = new BUS_SanBay();
        private BUS_ChuyenBay busChuyenBay = new BUS_ChuyenBay();
        private BUS_ValidateThongTinHanhKhach busValidationTTHK = new BUS_ValidateThongTinHanhKhach();
        private BUS_DonGiaHangGhe busDonGiaHangGhe = new BUS_DonGiaHangGhe();
        private BUS_VeChuyenBay busVeChuyenBay = new BUS_VeChuyenBay();
        private ErrorProvider errorProvider = new ErrorProvider();
        private ToolTip toolTip = new ToolTip();

        public GUI_BanVe()
        {
            InitializeComponent();
            SetResponsive();
            LoadDanhSachSanBayToComboBox(cbbSanBayDi, LayDanhSachSanBay());
            LoadDanhSachSanBayToComboBox(cbbSanBayDen, LayDanhSachSanBay());
        }

        #region non-logic code block

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
        #endregion

        private List<DTO_SanBay> LayDanhSachSanBay()
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

        private void btnTimChuyenBay_Click(object sender, EventArgs e)
        {
            string maSanBayDi = cbbSanBayDi.SelectedValue.ToString();
            string maSanBayDen = cbbSanBayDen.SelectedValue.ToString();
            string ngayBay = dtpNgayBay.Value.ToString("yyyy-MM-dd");

            if (string.IsNullOrWhiteSpace(maSanBayDi) || string.IsNullOrWhiteSpace(maSanBayDen))
            {
                MessageBox.Show("Vui lòng chọn sân bay đi và sân bay đến.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (maSanBayDi == maSanBayDen)
            {
                MessageBox.Show("Sân bay đi và sân bay đến không được giống nhau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<DTO_ChuyenBay> dsChuyenBay = busChuyenBay.TraCuuChuyenBay(maSanBayDi, maSanBayDen, ngayBay);
            if (dsChuyenBay != null && dsChuyenBay.Count > 0)
            {
                LoadMaChuyenBay(cbbMaChuyenBay, dsChuyenBay);
            }
            else
            {
                MessageBox.Show("Không tìm thấy chuyến bay nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearCombobox(cbbMaChuyenBay);
                ClearCombobox(cbbHangVe);
            }
        }

        private void cbbMaChuyenBay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMaChuyenBay.SelectedIndex == -1)
            {
                txtGioBay.Text = "";
            }
            else
            {
                DTO_ChuyenBay selectedChuyenBay = (DTO_ChuyenBay)cbbMaChuyenBay.SelectedItem;
                if (selectedChuyenBay != null)
                {
                    txtGioBay.Text = selectedChuyenBay.GioBay?.ToString("HH:mm");
                    // Load danh sách hạng vé
                    //List<DTO_HangVeCB> dsHangVe = busHangVeCB.TraCuuHangVe(selectedChuyenBay?.MaChuyenBay);
                    List<DTO_DonGiaHangGhe> dsHangGhe = busDonGiaHangGhe.LayDanhSachTenHangGheChuyenBay(selectedChuyenBay?.MaChuyenBay);
                    LoadDanhSachHangVeCB(dsHangGhe);
                }
            }
        }

        public void LoadDanhSachHangVeCB(List<DTO_DonGiaHangGhe> dsHangVeCB)
        {
            if (dsHangVeCB != null)
            {
                cbbHangVe.Enabled = true; // turn on the combobox
                cbbHangVe.DataSource = dsHangVeCB;
                cbbHangVe.DisplayMember = "TenHangGhe";
                cbbHangVe.ValueMember = "MaHangGhe";
                // Add tooltip to display MaHangGhe
                ToolTip toolTip = new ToolTip();
                cbbHangVe.SelectedIndexChanged += (s, e) =>
                {
                    if (cbbHangVe.SelectedItem is DTO_DonGiaHangGhe selectedHangVe)
                    {
                        toolTip.SetToolTip(cbbHangVe, selectedHangVe.MaHangGhe);
                    }
                };
            }
            else
            {
                ClearCombobox(cbbHangVe);
            }
        }

        private void cbbHangVe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbHangVe.SelectedIndex == -1)
            {
                txtGiaTien.Text = "";
            }
            else
            {
                if (cbbHangVe.SelectedItem is DTO_DonGiaHangGhe selectedHangVe)
                {
                    txtGiaTien.Text = selectedHangVe.DonGia.ToString() ?? "";
                }
            }
        }

        private void txtCMND_TextChanged(object sender, EventArgs e)
        {
            if (!busValidationTTHK.ValidateCMND(txtCMND.Text))
            {
                errorProvider.SetError(txtCMND, "CMND không hợp lệ");
            }
            else
            {
                errorProvider.SetError(txtCMND, string.Empty);
            }
        }

        private void txtTenHanhKhach_TextChanged(object sender, EventArgs e)
        {
            if (!busValidationTTHK.ValidateHoTen(txtTenHanhKhach.Text))
            {
                errorProvider.SetError(txtTenHanhKhach, "Tên hành khách không hợp lệ");
            }
            else
            {
                errorProvider.SetError(txtTenHanhKhach, string.Empty);
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if (!busValidationTTHK.ValidateSDT(txtSDT.Text))
            {
                errorProvider.SetError(txtSDT, "Số điện thoại không hợp lệ");
            }
            else
            {
                errorProvider.SetError(txtSDT, string.Empty);
            }
        }

        private bool HasErrors()
        {
            // Check for errors in form controls
            if (string.IsNullOrWhiteSpace(txtTenHanhKhach.Text) ||
                string.IsNullOrWhiteSpace(txtCMND.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                cbbMaChuyenBay.SelectedIndex == -1 ||
                cbbHangVe.SelectedIndex == -1 ||
                !busValidationTTHK.ValidateSDT(txtSDT.Text) ||
                !busValidationTTHK.ValidateCMND(txtCMND.Text) ||
                !busValidationTTHK.ValidateHoTen(txtTenHanhKhach.Text))
            {
                return true;
            }

            foreach (Control control in this.Controls)
            {
                if (errorProvider.GetError(control) != string.Empty)
                    return true;
            }

            return false;
        }


        private void btnLuuVe_Click(object sender, EventArgs e)
        {
            if (HasErrors())
            {
                MessageBox.Show("Vui lòng sửa các lỗi trước khi tiếp tục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DTO_VeChuyenBay veChuyenBay = new DTO_VeChuyenBay
            {
                MaVe = busVeChuyenBay.PhatSinhMaVeChuyenBay(),
                MaChuyenBay = cbbMaChuyenBay.SelectedValue.ToString(),
                MaHangGhe = cbbHangVe.SelectedValue.ToString(),
                TenHanhKhach = txtTenHanhKhach.Text,
                SoCMND = txtCMND.Text,
                SoDT = txtSDT.Text,
            };

            DTO_HangVeCB hangVeCB = new DTO_HangVeCB
            {
                MaChuyenBay = cbbMaChuyenBay.SelectedValue.ToString(),
                MaHangGhe = cbbHangVe.SelectedValue.ToString()
            };

            
            bool success = busVeChuyenBay.ThemVeChuyenBayVaHangVe(veChuyenBay, hangVeCB);

            MessageBox.Show(success ? "Thêm vé thành công" : "Lỗi khi thêm vé",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }


        private void btnInVe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In vé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
