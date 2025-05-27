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
    public partial class GUI_ThayDoiQuyDinh : Form
    {
        public BUS_ThamSo busThamSo = new BUS_ThamSo();
        public BUS_SanBay busSanBay = new BUS_SanBay();
        public BUS_HangVeTuyenBay BUS_HangVeTuyenBay = new BUS_HangVeTuyenBay();

        public GUI_ThayDoiQuyDinh()
        {
            InitializeComponent();
            SetResponsive();
            LoadThamSo();
            LoadDanhSachSanBayToComboBox(cbbSanBayDi, LayDanhSachSanBay());
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
                cbb.SelectedItem = dsSanBay[0];
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

        private void cbbSanBayDi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSanBayDi.SelectedIndex != -1)
            {
                string maSanBayDi = cbbSanBayDi.SelectedValue.ToString() ?? string.Empty;
                List<DTO_SanBay> danhSachSanBayDen = BUS_HangVeTuyenBay.LaySanBayDenTheoSanBayDi(maSanBayDi);
                if (danhSachSanBayDen == null || danhSachSanBayDen.Count == 0)
                {
                    cbbSanBayDen.DataSource = null;
                    return;
                }
                LoadDanhSachSanBayToComboBox(cbbSanBayDen, danhSachSanBayDen);
            }
        }

        private void btnThayDoiQuyDinh_Click(object sender, EventArgs e)
        {
            if (HasErrors())
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng tham số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
                MessageBox.Show("Cập nhật tham số thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadThamSo();
            }
            else
            {
                MessageBox.Show("Cập nhật tham số thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
