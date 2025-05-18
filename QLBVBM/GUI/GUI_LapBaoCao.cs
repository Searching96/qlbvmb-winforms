using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBVBM.BUS;
using QLBVBM.DTO;

namespace QLBVBM.GUI
{
    public partial class GUI_LapBaoCao : Form
    {
        private BUS_HangVeCB busHangVeCB = new BUS_HangVeCB();
        private BUS_VeChuyenBay busVeChuyenBay = new BUS_VeChuyenBay();

        public GUI_LapBaoCao()
        {
            InitializeComponent();
            SetResponsive();

        }
        public void SetResponsive()
        {
            foreach (Control control in this.Controls)
            {
                control.Anchor = AnchorStyles.None;
            }
        }
        private void btnLapBaoCaoDoanhThu_Click(object sender, EventArgs e)
        {
            int thang = dtpThangBaoCao.Value.Month;
            int nam = dtpNamBaoCao.Value.Year;

            List<DTO_VeChuyenBay> dsVeChuyenBay = busVeChuyenBay.LayVeThanhToanTheoThangNam(thang, nam);

            if (dsVeChuyenBay != null && dsVeChuyenBay.Count > 0)
            {
                List<DTO_HangVeCB> dsHangVeCB = new List<DTO_HangVeCB>();

                foreach (var ve in dsVeChuyenBay)
                {
                    DTO_HangVeCB hangVe = busHangVeCB.LayHangVeTheoVeChuyenBay(ve.MaChuyenBay, ve.MaHangGhe);
                    if (hangVe != null) dsHangVeCB.Add(hangVe);
                }


                dgvBaoCaoDoanhThu.Rows.Clear();

                //tong doanh thu
                var tongDoanhThu = dsHangVeCB
                    .Sum(h => h.SoLuongGheDaBan * h.DonGia);
                txtTongDoanhThu.Text = string.Format("{0:0,0}", tongDoanhThu);

                //dgv doanh thu
                var dsMaChuyenBay = dsHangVeCB
                    .Select(h => h.MaChuyenBay)
                    .Distinct();

                int stt = 1;
                foreach (var maChuyenBay in dsMaChuyenBay)
                {
                    var dsHangVeCuaChuyenBay = dsHangVeCB
                        .Where(h => h.MaChuyenBay == maChuyenBay)
                        .ToList();

                    var tongSoLuongDaBan = dsHangVeCuaChuyenBay
                        .Sum(h => h.SoLuongGheDaBan);

                    var doanhThu = dsHangVeCuaChuyenBay
                        .Sum(h => h.SoLuongGheDaBan * h.DonGia);

                    decimal tyLe = 0;
                    if (doanhThu > 0 && tongDoanhThu > 0)
                    {
                        tyLe = Math.Round((decimal)doanhThu / (decimal)tongDoanhThu * 100m, 2);
                    }

                    dgvBaoCaoDoanhThu.Rows.Add(
                        stt++,
                        maChuyenBay,
                        tongSoLuongDaBan,
                        tyLe,
                        doanhThu
                    );
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy vé chuyến bay đã thanh toán trong thời gian trên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
