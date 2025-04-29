using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QLBVBM.BUS
{
    public class BUS_ValidateThongTinHanhKhach
    {
        public bool ValidateCMND(string CMND)
        {
            return CMND.All(char.IsDigit) && CMND.Length <= 20;
        }

        public bool ValidateSDT(string SDT)
        {
            return SDT.All(char.IsDigit) && SDT.Length <= 15;
        }

        public bool ValidateHoTen(string hoTen)
        {
            // Only allow letters and spaces
            string pattern = @"^[A-Za-zÀ-ỹ\s]+$";
            return Regex.IsMatch(hoTen, pattern);
        }
    }
}
