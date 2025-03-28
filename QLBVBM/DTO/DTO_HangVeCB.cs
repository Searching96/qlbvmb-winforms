using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVBM.DTO
{
    public class DTO_HangVeCB
    {
        private string? maHangGhe;
        private string? maChuyenBay;
        private int? soLuongGhe;

        public DTO_HangVeCB(string? maHangGhe = null, string? maChuyenBay = null, int? soLuongGhe = null)
        {
            this.maHangGhe = maHangGhe;
            this.maChuyenBay = maChuyenBay;
            this.soLuongGhe = soLuongGhe;
        }

        public string? MaHangGhe { get => maHangGhe; set => maHangGhe = value; }
        public string? MaChuyenBay { get => maChuyenBay; set => maChuyenBay = value; }
        public int? SoLuongGhe { get => soLuongGhe; set => soLuongGhe = value; }
    }
}
