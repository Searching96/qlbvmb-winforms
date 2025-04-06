using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVBM.DTO
{
    public class DTO_DonGiaHangGhe
    {
        private string? maHangGhe;
        private string? tenHangGhe;
        private string? maChuyenBay;
        private int? donGia;

        public DTO_DonGiaHangGhe(string? maHangGhe = null, string? tenHangGhe = null, string? maChuyenBay = null, int? donGia = null)
        {
            this.maHangGhe = maHangGhe;
            this.tenHangGhe = tenHangGhe;
            this.maChuyenBay = maChuyenBay;
            this.donGia = donGia;
        }

        public string? MaHangGhe { get => maHangGhe; set => maHangGhe = value; }
        public string? TenHangGhe { get => tenHangGhe; set => tenHangGhe = value; }
        public string? MaChuyenBay { get => maChuyenBay; set => maChuyenBay = value; }
        public int? DonGia { get => donGia; set => donGia = value; }
    }
}
