using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVBM.DTO
{
    public class DTO_SanBay
    {
        private string? maSanBay;
        private string? tenSanBay;

        public DTO_SanBay(string? maSanBay = null, string? tenSanBay = null)
        {
            this.maSanBay = maSanBay;
            this.tenSanBay = tenSanBay;
        }

        public string? MaSanBay { get => maSanBay; set => maSanBay = value; }
        public string? TenSanBay { get => tenSanBay; set => tenSanBay = value; }
    }
}
