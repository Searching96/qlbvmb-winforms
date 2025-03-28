using QLBVBM.DAL;
using QLBVBM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace QLBVBM.BUS
{
    public class BUS_ChuyenBay
    {
        private DAL_ChuyenBay DAL_ChuyenBay = new DAL_ChuyenBay();
        private DAL_ThamSo DAL_ThamSo = new DAL_ThamSo();
        private BUS_CTChuyenBay BUS_CTChuyenBay = new BUS_CTChuyenBay();
        private BUS_HangVeCB BUS_HangVeCB = new BUS_HangVeCB();

        public DTO_ChuyenBay LayChuyenBayCuoi()
        {
            return DAL_ChuyenBay.LayChuyenBayCuoi();
        }

        public bool ThemChuyenBay(DTO_ChuyenBay chuyenBay)
        {
            return DAL_ChuyenBay.ThemChuyenBay(chuyenBay);
        }

        public bool ThemChuyenBayVaChiTiet(DTO_ChuyenBay chuyenBay, List<DTO_CTChuyenBay> dsCTChuyenBay, List<DTO_HangVeCB> dsHangVeCB)
        {
            using (var transaction = new TransactionScope())
            {
                try
                {
                    if (!ThemChuyenBay(chuyenBay))
                    {
                        transaction.Dispose();
                        return false;
                    }

                    foreach (var ctChuyenBay in dsCTChuyenBay)
                    {
                        if (!BUS_CTChuyenBay.ThemCTChuyenBay(ctChuyenBay))
                        {
                            transaction.Dispose();
                            return false;
                        }
                    }

                    foreach (var hangVeCB in dsHangVeCB)
                    {
                        if (!BUS_HangVeCB.ThemHangVeCB(hangVeCB))
                        {
                            transaction.Dispose();
                            return false;
                        }
                    }

                    transaction.Complete();
                    return true;
                }
                catch
                {
                    transaction.Dispose();
                    return false;
                }
            }
        }

        public bool ValidateThoiGianBay(string textThoiGianBay)
        {
            int thoiGianBayToiThieu = DAL_ThamSo.LayThoiGianBayToiThieu();
            if (string.IsNullOrWhiteSpace(textThoiGianBay)
                || !int.TryParse(textThoiGianBay, out int thoiGianBay)
                || thoiGianBay < thoiGianBayToiThieu)
            {
                return false;
            }
            return true;
        }

        public bool ValidateSoLuongGhe(string textSoLuongGhe)
        {
            if (string.IsNullOrWhiteSpace(textSoLuongGhe)
                || !int.TryParse(textSoLuongGhe, out int soLuongGhe)
                || soLuongGhe < 0)
            {
                return false;
            }
            return true;
        }

        public bool ValidateThoiGianDung(string textThoiGianDung)
        {
            int thoiGianDungToiThieu = DAL_ThamSo.LayThoiGianDungToiThieu();
            int thoiGianDungToiDa = DAL_ThamSo.LayThoiGianDungToiDa();
            if (!int.TryParse(textThoiGianDung, out int thoiGianDung)
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

        public bool CheckDuplicateAirports(List<string> selectedAirports)
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
