using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVBM.DTO
{
    public class DTO_HangVeTuyenBay
    {
        private string? maSanBayDi;
        private string? maSanBayDen;
        private string? maHangGhe;
        private int? donGiaQuyDinh;

        public DTO_HangVeTuyenBay(string? maSanBayDi = null, string? maSanBayDen = null, string? maHangGhe = null, int? donGiaQuyDinh = null)
        {
            this.maSanBayDi = maSanBayDi;
            this.maSanBayDen = maSanBayDen;
            this.maHangGhe = maHangGhe;
            this.donGiaQuyDinh = donGiaQuyDinh;
        }

        public string? MaSanBayDi { get => maSanBayDi; set => maSanBayDi = value; }
        public string? MaSanBayDen { get => maSanBayDen; set => maSanBayDen = value; }
        public string? MaHangGhe { get => maHangGhe; set => maHangGhe = value; }
        public int? DonGiaQuyDinh { get => donGiaQuyDinh; set => donGiaQuyDinh = value; }
    }
}
