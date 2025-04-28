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
        private string? maHanhKhach;
        private string? maHangGhe;
        private int? trangThaiVe;
        private DateTime? thoiDiemThanhToan;

        public DTO_VeChuyenBay(string? maVe = null, string? maChuyenBay = null, string? maHanhKhach = null, string? maHangGhe = null, int? trangThaiVe = null, DateTime? thoiDiemThanhToan = null)
        {
            this.maVe = maVe;
            this.maChuyenBay = maChuyenBay;
            this.maHanhKhach = maHanhKhach;
            this.maHangGhe = maHangGhe;
            this.trangThaiVe = trangThaiVe;
            this.thoiDiemThanhToan = thoiDiemThanhToan;
        }

        public string? MaVe { get => maVe; set => maVe = value; }
        public string? MaChuyenBay { get => maChuyenBay; set => maChuyenBay = value; }
        public string? MaHanhKhach { get => maHanhKhach; set => maHanhKhach = value; }
        public string? MaHangGhe { get => maHangGhe; set => maHangGhe = value; }
        public int? TrangThaiVe { get => trangThaiVe; set => trangThaiVe = value; }
        public DateTime? ThoiDiemThanhToan { get => thoiDiemThanhToan; set => thoiDiemThanhToan = value; }
    }
}
