using QLBVBM.DAL;
using QLBVBM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVBM.BUS
{
    public class BUS_ChuyenBay
    {
        private DAL_ChuyenBay DAL_ChuyenBay = new DAL_ChuyenBay();
        private DAL_ThamSo DAL_ThamSo = new DAL_ThamSo();

        public DTO_ChuyenBay LayChuyenBayCuoi()
        {
            return DAL_ChuyenBay.LayChuyenBayCuoi();
        }

        public bool ThemChuyenBay(DTO_ChuyenBay chuyenBay)
        {
            return DAL_ChuyenBay.ThemChuyenBay(chuyenBay);
        }

        public bool ValidateThoiGianBay(string txtThoiGianBay)
        {
            int thoiGianBayToiThieu = DAL_ThamSo.LayThoiGianBayToiThieu();
            if (string.IsNullOrWhiteSpace(txtThoiGianBay)
                || !int.TryParse(txtThoiGianBay, out int thoiGianBay)
                || thoiGianBay < thoiGianBayToiThieu)
            {
                return false;
            }
            return true;
        }

        public bool ValidateSoLuongGhe(string txtSoLuongGhe)
        {
            if (string.IsNullOrWhiteSpace(txtSoLuongGhe)
                || !int.TryParse(txtSoLuongGhe, out int soLuongGhe)
                || soLuongGhe < 0)
            {
                return false;
            }
            return true;
        }

        public bool ValidateThoiGianDung(string txtThoiGianDung)
        {
            int thoiGianDungToiThieu = DAL_ThamSo.LayThoiGianDungToiThieu();
            int thoiGianDungToiDa = DAL_ThamSo.LayThoiGianDungToiDa();
            if (!int.TryParse(txtThoiGianDung, out int thoiGianDung)
                || thoiGianDung < thoiGianDungToiThieu || thoiGianDung > thoiGianDungToiDa)
            {
                return false;
            }
            return true;
        }

        public string PhatSinhMaChuyenBay()
        {
            DTO_ChuyenBay chuyenBayCuoi = LayChuyenBayCuoi();
            if (chuyenBayCuoi != null)
            {
                string maChuyenBayCuoi = chuyenBayCuoi.MaChuyenBay;
                int lastNumber = int.Parse(maChuyenBayCuoi.Substring(2));
                return "CB" + (lastNumber + 1).ToString("D5");
            }
            else
            {
                return "CB00001";
            }
        }

        internal bool CheckDuplicateAirports(List<string> selectedAirports)
        {
            Dictionary<string, int> dictSanBay = new Dictionary<string, int>();

            foreach (string sanBay in selectedAirports)
            {
                if (!string.IsNullOrWhiteSpace(sanBay))
                {
                    if (dictSanBay.ContainsKey(sanBay))
                        dictSanBay[sanBay]++;
                    else
                        dictSanBay[sanBay] = 1;
                }
            }

            foreach (var count in dictSanBay.Values)
                if (count > 1)
                    return true;

            return false;
        }
    }
}
