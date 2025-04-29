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
    public partial class GUI_Ve : Form
    {
        private BUS_SanBay busSanBay = new BUS_SanBay();
        private BUS_HangGhe busHangGhe = new BUS_HangGhe();

        public GUI_Ve(DTO_ChuyenBay cb, DTO_HanhKhach hk, DTO_DonGiaHangGhe dghg)
        {
            InitializeComponent();
            LoadData(cb, hk, dghg);
        }

        public string GetTenSanBay(string maSanBay)
        {
            return busSanBay.LayTenSanBay(maSanBay);
        }

        public string GetTenHangGhe(string maHangGhe)
        {
            return busHangGhe.LayTenHangGhe(maHangGhe);
        }

        public void LoadData(DTO_ChuyenBay cb, DTO_HanhKhach hk, DTO_DonGiaHangGhe dghg)
        {
            // flight info
            txtMaChuyenBay.Text = cb.MaChuyenBay;
            txtNgayBay.Text = cb.NgayBay?.ToString("dd/MM/yyyy");
            txtGioBay.Text = cb.GioBay?.ToString("HH:mm");
            txtSanBayDi.Text = GetTenSanBay(cb.MaSanBayDi);
            txtSanBayDen.Text = GetTenSanBay(cb.MaSanBayDen);

            // passenger info
            txtTenHanhKhach.Text = hk.HoTen;
            txtCMND.Text = hk.SoCMND;
            txtSDT.Text = hk.SoDT;

            // seat info
            txtHangGhe.Text = GetTenHangGhe(dghg.MaHangGhe);
            txtGiaVe.Text = dghg.DonGia.ToString();
        }
    }
}
