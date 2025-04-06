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
        private string? trangThai;

        public DTO_VeChuyenBay(string? maVe = null, string? maChuyenBay = null, string? maHanhKhach = null, string? maHangGhe = null)
        {
            this.maVe = maVe;
            this.maChuyenBay = maChuyenBay;
            this.maHanhKhach = maHanhKhach;
            this.maHangGhe = maHangGhe;
        }

        public string? MaVe { get => maVe; set => maVe = value; }
        public string? MaChuyenBay { get => maChuyenBay; set => maChuyenBay = value; }
        public string? MaHanhKhach { get => maHanhKhach; set => maHanhKhach = value; }
        public string? MaHangGhe { get => maHangGhe; set => maHangGhe = value; }
    }
}
