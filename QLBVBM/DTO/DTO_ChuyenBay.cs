using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVBM.DTO
{
    public class DTO_ChuyenBay
    {
        private string? maChuyenBay;
        private string? maSanBayDi;
        private string? maSanBayDen;
        private DateTime? ngayBay;
        private DateTime? gioBay;
        private int? thoiGianBay;

        public DTO_ChuyenBay(string? maChuyenBay = null, string? maSanBayDi = null, string? maSanBayDen = null, 
            DateTime? ngayBay = null, DateTime? gioBay = null, int? thoiGianBay = null)
        {
            this.maChuyenBay = maChuyenBay;
            this.maSanBayDi = maSanBayDi;
            this.maSanBayDen = maSanBayDen;
            this.ngayBay = ngayBay;
            this.gioBay = gioBay;
            this.thoiGianBay = thoiGianBay;
        }

        public string? MaChuyenBay { get => maChuyenBay; set => maChuyenBay = value; }
        public string? MaSanBayDi { get => maSanBayDi; set => maSanBayDi = value; }
        public string? MaSanBayDen { get => maSanBayDen; set => maSanBayDen = value; }
        public DateTime? NgayBay { get => ngayBay; set => ngayBay = value; }
        public DateTime? GioBay { get => gioBay; set => gioBay = value; }
        public int? ThoiGianBay { get => thoiGianBay; set => thoiGianBay = value; }
    }
}
