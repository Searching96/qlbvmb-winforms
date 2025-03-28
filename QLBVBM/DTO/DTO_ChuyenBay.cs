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
        private DateTime? ngayGioBay;
        private int? thoiGianBay;

        public DTO_ChuyenBay(string? maChuyenBay = null, string? maSanBayDi = null, string? maSanBayDen = null, DateTime? ngayGioBay = null, int? thoiGianBay = null)
        {
            this.maChuyenBay = maChuyenBay;
            this.maSanBayDi = maSanBayDi;
            this.maSanBayDen = maSanBayDen;
            this.ngayGioBay = ngayGioBay;
            this.thoiGianBay = thoiGianBay;
        }

        public string? MaChuyenBay { get => maChuyenBay; set => maChuyenBay = value; }
        public string? MaSanBayDi { get => maSanBayDi; set => maSanBayDi = value; }
        public string? MaSanBayDen { get => maSanBayDen; set => maSanBayDen = value; }
        public DateTime? NgayGioBay { get => ngayGioBay; set => ngayGioBay = value; }
        public int? ThoiGianBay { get => thoiGianBay; set => thoiGianBay = value; }
    }
}
