using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVBM.DTO
{
    public class DTO_HanhKhach
    {
        private string? maHanhKhach;
        private string? hoTen;
        private string? CMND;
        private string? SDT;

        public DTO_HanhKhach(string? maHanhKhach = null, string? hoTen = null, string? CMND = null, string? SDT = null)
        {
            this.maHanhKhach = maHanhKhach;
            this.hoTen = hoTen;
            this.CMND = CMND;
            this.SDT = SDT;
        }

        public string? MaHanhKhach { get => maHanhKhach; set => maHanhKhach = value; }
        public string? HoTen { get => hoTen; set => hoTen = value; }
        public string? SoCMND { get => CMND; set => CMND = value; }
        public string? SoDT { get => SDT; set => SDT = value; }
    }
}
