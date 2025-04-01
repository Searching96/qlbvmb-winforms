using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVBM.DTO
{
    public class DTO_HangGhe
    {
        private string? maHangGhe;
        private string? tenHangGhe;

        public DTO_HangGhe(string? maHangGhe = null, string? tenHangGhe = null)
        {
            this.maHangGhe = maHangGhe;
            this.tenHangGhe = tenHangGhe;
        }

        public string? MaHangGhe { get => maHangGhe; set => maHangGhe = value; }
        public string? TenHangGhe { get => tenHangGhe; set => tenHangGhe = value; }
    }
}
