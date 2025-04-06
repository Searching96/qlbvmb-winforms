using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBVBM.DAL;
using QLBVBM.DTO;
using System.Transactions;
using System.Text.RegularExpressions;

namespace QLBVBM.BUS
{
    public class BUS_HanhKhach
    {
        private DAL_HanhKhach dalHanhKhach = new DAL_HanhKhach();

        public bool ThemHanhKhach(DTO_HanhKhach hanhKhach)
        {
            return dalHanhKhach.ThemHanhKhach(hanhKhach);
        }

        public DTO_HanhKhach? LayHanhKhachCuoi()
        {
            return dalHanhKhach.LayHanhKhachCuoi();
        }

        public List<DTO_HanhKhach> LayDanhSachHanhKhach()
        {
            return dalHanhKhach.LayDanhSachHanhKhach();
        }

        public DTO_HanhKhach? TimHanhKhachTheoCMND(string CMND)
        {
            return dalHanhKhach.TimHanhKhachTheoCMND(CMND);
        }
        
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

        public string PhatSinhMaHanhKhach()
        {
            DTO_HanhKhach hanhKhachCuoi = LayHanhKhachCuoi();
            if (hanhKhachCuoi != null)
            {
                string maHanhKhachCuoi = hanhKhachCuoi.MaHanhKhach;
                int lastNumber = int.Parse(maHanhKhachCuoi.Substring(2));
                return "HK" + (lastNumber + 1).ToString("D5");
            }
            else
            {
                return "HK00001";
            }
        }
    }
}
