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
    public partial class UC_ThayDoiQuyDinh : UserControl
    {
        public BUS_ThamSo busThamSo = new BUS_ThamSo();
        public BUS_SanBay busSanBay = new BUS_SanBay();
        public BUS_HangVeTuyenBay busHangVeTuyenBay = new BUS_HangVeTuyenBay();

        public UC_ThayDoiQuyDinh()
        {
            InitializeComponent();
            SetResponsive();
            LoadThamSo();
            LoadDanhSachSanBayToComboBox(cbbSanBayDi, LayDanhSachSanBay());
        }

        public void ClearCombobox(Guna2ComboBox cbb) // clear the combobox and set it to disabled
        {
            cbb.DataSource = null;
            cbb.SelectedIndex = -1;
        }

        public void SetResponsive()
        {
            foreach (Control control in this.Controls)
            {
                control.Anchor = AnchorStyles.None;
            }
        }

        public void LoadThamSo()
        {
            txtSoSBTGToiDa.Text = busThamSo.LaySoLuongSanBayToiDa().ToString();
            txtTGBayToiThieu.Text = busThamSo.LayThoiGianBayToiThieu().ToString();
            txtTGDungToiThieu.Text = busThamSo.LayThoiGianDungToiThieu().ToString();
            txtTGDungToiDa.Text = busThamSo.LayThoiGianDungToiDa().ToString();
            txtTGDatTruocVe.Text = busThamSo.LayThoiGianDatVeToiThieu().ToString();
            txtTGHuyDatVe.Text = busThamSo.LayThoiGianHuyDatVeToiThieu().ToString();
        }

        public List<DTO_SanBay> LayDanhSachSanBay()
        {
            List<DTO_SanBay> danhSachSanBay = busSanBay.LayDanhSachSanBay();

            if (danhSachSanBay.Count > 0)
            {
                return danhSachSanBay;
            }

            return new List<DTO_SanBay>();
        }

        public void LoadDanhSachSanBayToComboBox(Guna2ComboBox cbb, List<DTO_SanBay> dsSanBay)
        {
            if (dsSanBay != null && dsSanBay.Count > 0)
            {
                cbb.DataSource = dsSanBay;
                cbb.DisplayMember = "TenSanBay";
                cbb.ValueMember = "MaSanBay";
                cbb.SelectedIndex = -1;
            }
        }

        public void LoadDanhSachHangGheToComboBox(Guna2ComboBox cbb, List<DTO_HangGhe> dsHangGhe)
        {
            if (dsHangGhe != null && dsHangGhe.Count > 0)
            {
                cbb.DataSource = dsHangGhe;
                cbb.DisplayMember = "TenHangGhe";
                cbb.ValueMember = "MaHangGhe";
                cbb.SelectedIndex = -1;
            }
        }

        public bool HasErrors()
        {
            if (!busThamSo.ValidateThamSo(txtSoSBTGToiDa.Text)
                || !busThamSo.ValidateThamSo(txtTGBayToiThieu.Text)
                || !busThamSo.ValidateThamSo(txtTGDungToiThieu.Text)
                || !busThamSo.ValidateThamSo(txtTGDungToiDa.Text)
                || !busThamSo.ValidateThamSo(txtTGDatTruocVe.Text)
                || !busThamSo.ValidateThamSo(txtTGHuyDatVe.Text))
                return true;
            return false;
        }

        public bool ValidateTuyenBay()
        {
            if (cbbSanBayDi.SelectedIndex == -1 && cbbSanBayDen.SelectedIndex == -1 && cbbHangGhe.SelectedIndex == -1 && string.IsNullOrWhiteSpace(txtDonGia.Text))
            {
                return true;
            }

            if (cbbSanBayDi.SelectedIndex == -1 || cbbSanBayDen.SelectedIndex == -1 || cbbHangGhe.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtDonGia.Text))
            {
                return false;
            }
            return true;
        }

        public bool KhongDienTuyen()
        {
            if (cbbSanBayDi.SelectedIndex == -1 && cbbSanBayDen.SelectedIndex == -1 && cbbHangGhe.SelectedIndex == -1 && string.IsNullOrWhiteSpace(txtDonGia.Text))
            {
                return true;
            }
            return false;
        }

        private void cbbSanBayDi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSanBayDi.SelectedIndex != -1)
            {
                string maSanBayDi = cbbSanBayDi.SelectedValue.ToString() ?? string.Empty;
                List<DTO_SanBay> danhSachSanBayDen = busHangVeTuyenBay.LaySanBayDenTheoSanBayDi(maSanBayDi);

                if (danhSachSanBayDen == null || danhSachSanBayDen.Count == 0)
                {
                    ClearCombobox(cbbSanBayDen);
                    return;
                }

                LoadDanhSachSanBayToComboBox(cbbSanBayDen, danhSachSanBayDen);
            }
            else
            {
                ClearCombobox(cbbSanBayDen);
                ClearCombobox(cbbHangGhe);
            }
        }

        private void cbbSanBayDen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSanBayDen.SelectedIndex != -1 && cbbSanBayDi.SelectedIndex != -1)
            {
                string maSanBayDi = cbbSanBayDi.SelectedValue.ToString() ?? string.Empty;
                string maSanBayDen = cbbSanBayDen.SelectedValue.ToString() ?? string.Empty;

                List<DTO_HangGhe> dsHangGhe = busHangVeTuyenBay.LayHangGheTheoTuyenBay(maSanBayDi, maSanBayDen);

                if (dsHangGhe == null || dsHangGhe.Count == 0)
                {
                    ClearCombobox(cbbHangGhe);
                    return;
                }

                LoadDanhSachHangGheToComboBox(cbbHangGhe, dsHangGhe);
            }
            else
            {
                ClearCombobox(cbbHangGhe);
            }
        }

        private void cbbHangGhe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSanBayDen.SelectedIndex != -1
                && cbbSanBayDi.SelectedIndex != -1
                && cbbHangGhe.SelectedIndex != -1)
            {
                string maSanBayDi = cbbSanBayDi.SelectedValue.ToString() ?? string.Empty;
                string maSanBayDen = cbbSanBayDen.SelectedValue.ToString() ?? string.Empty;
                string maHangGhe = cbbHangGhe.SelectedValue.ToString() ?? string.Empty;

                int donGiaQuyDinh = busHangVeTuyenBay.LayDonGiaQuyDinh(maSanBayDi, maSanBayDen, maHangGhe);

                if (donGiaQuyDinh > 0)
                    txtDonGia.Text = donGiaQuyDinh.ToString();
                else txtDonGia.Text = string.Empty;
            }
            else
            {
                txtDonGia.Text = string.Empty;
            }
        }

        private void btnThayDoiQuyDinh_Click(object sender, EventArgs e)
        {
            if (!ValidateTuyenBay())
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin tuyến bay!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (HasErrors())
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng tham số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!KhongDienTuyen())
            {
                string maSanBayDi = cbbSanBayDi.SelectedValue.ToString() ?? string.Empty;
                string maSanBayDen = cbbSanBayDen.SelectedValue.ToString() ?? string.Empty;
                string maHangGhe = cbbHangGhe.SelectedValue.ToString() ?? string.Empty;
                int donGiaQuyDinh = txtDonGia.Text != string.Empty ? int.Parse(txtDonGia.Text) : 0;

                busHangVeTuyenBay.CapNhatDonGiaQuyDinh(maSanBayDi, maSanBayDen, maHangGhe, donGiaQuyDinh);
            }

            DTO_ThamSo thamSoCapNhat = new DTO_ThamSo
            {
                SoSanBayTGToiDa = int.Parse(txtSoSBTGToiDa.Text),
                TgBayToiThieu = int.Parse(txtTGBayToiThieu.Text),
                TgDungToiThieu = int.Parse(txtTGDungToiThieu.Text),
                TgDungToiDa = int.Parse(txtTGDungToiDa.Text),
                TgDatTruocVeToiThieu = int.Parse(txtTGDatTruocVe.Text),
                TgHuyDatTruocVeToiThieu = int.Parse(txtTGHuyDatVe.Text)
            };

            if (busThamSo.CapNhatThamSo(thamSoCapNhat))
            {
                MessageBox.Show("Thay đổi quy định thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadThamSo();
                LoadDanhSachSanBayToComboBox(cbbSanBayDi, LayDanhSachSanBay());
            }
            else
            {
                MessageBox.Show("Thay đổi quy định thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
