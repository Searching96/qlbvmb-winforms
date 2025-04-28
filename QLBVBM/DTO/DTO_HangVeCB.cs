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
        private int? soLuongGheDaBan;
        private int? soLuongGheDaDat;
        private int? donGia;

        public DTO_HangVeCB(string? maHangGhe = null, string? maChuyenBay = null, int? soLuongGhe = null, int? soLuongGheDaBan = null, int? soLuongGheDaDat = null, int? donGia = null)
        {
            this.maHangGhe = maHangGhe;
            this.maChuyenBay = maChuyenBay;
            this.soLuongGhe = soLuongGhe;
            this.soLuongGheDaBan = soLuongGheDaBan;
            this.soLuongGheDaDat = soLuongGheDaDat;
            this.donGia = donGia;
        }

        public string? MaHangGhe { get => maHangGhe; set => maHangGhe = value; }
        public string? MaChuyenBay { get => maChuyenBay; set => maChuyenBay = value; }
        public int? SoLuongGhe { get => soLuongGhe; set => soLuongGhe = value; }
        public int? SoLuongGheDaBan { get => soLuongGheDaBan; set => soLuongGheDaBan = value; }
        public int? DonGia { get => donGia; set => donGia = value; }
        public int? SoLuongGheDaDat { get => soLuongGheDaDat; set => soLuongGheDaDat = value; }
    }
}
