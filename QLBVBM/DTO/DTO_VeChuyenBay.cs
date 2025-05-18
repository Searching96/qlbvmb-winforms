using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVBM.DTO
{
    public class DTO_VeChuyenBay
    {
        private string? maVe;
        private string? maChuyenBay;
        private string? maHangGhe;
        private string? tenHanhKhach;
        private string? CMND;
        private string? SDT;
        //private int? trangThaiVe;
        //private DateTime? thoiDiemThanhToan;

        public DTO_VeChuyenBay(string? maVe = null, string? maChuyenBay = null, 
                            string? maHangGhe = null, string? tenHanhKhach = null,
                            string? CMND = null, string? SDT = null)
        {
            this.maVe = maVe;
            this.maChuyenBay = maChuyenBay;
            this.maHangGhe = maHangGhe;
            this.tenHanhKhach = tenHanhKhach;
            this.CMND = CMND;
            this.SDT = SDT;
            //this.trangThaiVe = trangThaiVe;
            //this.thoiDiemThanhToan = thoiDiemThanhToan;
        }

        public string? MaVe { get => maVe; set => maVe = value; }
        public string? MaChuyenBay { get => maChuyenBay; set => maChuyenBay = value; }
        public string? MaHangGhe { get => maHangGhe; set => maHangGhe = value; }
        public string? TenHanhKhach { get => tenHanhKhach; set => tenHanhKhach = value; }
        public string? SoCMND { get => CMND; set => CMND = value; }
        public string? SoDT { get => SDT; set => SDT = value; }
        //public int? TrangThaiVe { get => trangThaiVe; set => trangThaiVe = value; }
        //public DateTime? ThoiDiemThanhToan { get => thoiDiemThanhToan; set => thoiDiemThanhToan = value; }
    }
}
