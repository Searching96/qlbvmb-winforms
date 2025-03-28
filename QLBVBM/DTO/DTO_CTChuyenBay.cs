using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVBM.DTO
{
    public class DTO_CTChuyenBay
    {
        private string? maChuyenBay;
        private string? maSanBayTG;
        private int? thoiGianDung;
        private string? ghiChu;
        
        public DTO_CTChuyenBay(string? maChuyenBay = null, string? maSanBayTG = null, int? thoiGianDung = null, string? ghiChu = null)
        {
            this.maChuyenBay = maChuyenBay;
            this.maSanBayTG = maSanBayTG;
            this.thoiGianDung = thoiGianDung;
            this.ghiChu = ghiChu;
        }

        public string? MaChuyenBay { get => maChuyenBay; set => maChuyenBay = value; }
        public string? MaSanBayTG { get => maSanBayTG; set => maSanBayTG = value; }
        public int? ThoiGianDung { get => thoiGianDung; set => thoiGianDung = value; }
        public string? GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}
