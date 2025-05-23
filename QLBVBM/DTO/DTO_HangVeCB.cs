﻿using System;
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
        private int? soLuongGheConLai;

        public DTO_HangVeCB(string? maHangGhe = null, string? maChuyenBay = null, int? soLuongGhe = null, int? soLuongGheConLai = null)
        {
            this.maHangGhe = maHangGhe;
            this.maChuyenBay = maChuyenBay;
            this.soLuongGhe = soLuongGhe;
            this.soLuongGheConLai = soLuongGheConLai;
        }

        public string? MaHangGhe { get => maHangGhe; set => maHangGhe = value; }
        public string? MaChuyenBay { get => maChuyenBay; set => maChuyenBay = value; }
        public int? SoLuongGhe { get => soLuongGhe; set => soLuongGhe = value; }
        public int? SoLuongGheConLai { get => soLuongGheConLai; set => soLuongGheConLai = value; }
    }
}
