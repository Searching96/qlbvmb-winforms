using QLBVBM.DAL;
using QLBVBM.DTO;
using System.Diagnostics;
using System.Transactions;

namespace QLBVBM.BUS
{
    public class BUS_VeChuyenBay
    {
        private BUS_HangVeCB BUS_HangVeCB = new BUS_HangVeCB();
        private DAL_VeChuyenBay DAL_VeChuyenBay = new DAL_VeChuyenBay();
        //private BUS_HanhKhach BUS_HanhKhach = new BUS_HanhKhach();

        public bool ThemVeChuyenBay(DTO_VeChuyenBay veChuyenBay)
        {
            return DAL_VeChuyenBay.ThemVeChuyenBay(veChuyenBay);
        }

        public bool DatVeChuyenBay(DTO_VeChuyenBay veChuyenBay)
        {
            return DAL_VeChuyenBay.DatVeChuyenBay(veChuyenBay);
        }

        public string PhatSinhMaVeChuyenBay()
        {
            DTO_VeChuyenBay veChuyenBayCuoi = DAL_VeChuyenBay.LayVeChuyenBayCuoi();
            if (veChuyenBayCuoi != null)
            {
                string maVeChuyenBayCuoi = veChuyenBayCuoi.MaVe;
                int lastNumber = int.Parse(maVeChuyenBayCuoi.Substring(2));
                return "V" + (lastNumber + 1).ToString("D5");
            }
            return "V00001";
        }

        public bool ThemVeChuyenBayVaHangVe(DTO_VeChuyenBay veChuyenBay, DTO_HangVeCB hangVeCB)
        {
            using (var transaction = new TransactionScope())
            {
                try
                {
                    if (!ThemVeChuyenBay(veChuyenBay))
                    {
                        transaction.Dispose();
                        return false;
                    }

                    // Update the number of seats sold
                    if (!BUS_HangVeCB.CapNhatSoLuongVeDaBan(hangVeCB.MaChuyenBay, hangVeCB.MaHangGhe))
                    {
                        transaction.Dispose();
                        return false;
                    }

                    transaction.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error: {ex.Message}");
                    transaction.Dispose();
                    return false;
                }
            }
        }

        public bool DatVeChuyenBayVaHangVe(DTO_VeChuyenBay veChuyenBay, DTO_HangVeCB hangVeCB)
        {
            using (var transaction = new TransactionScope())
            {
                try
                {
                    if (!DatVeChuyenBay(veChuyenBay))
                    {
                        transaction.Dispose();
                        return false;
                    }

                    // Update the number of seats booked
                    if (!BUS_HangVeCB.CapNhatSoLuongVeDaDat(hangVeCB.MaChuyenBay, hangVeCB.MaHangGhe))
                    {
                        transaction.Dispose();
                        return false;
                    }

                    transaction.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error: {ex.Message}");
                    transaction.Dispose();
                    return false;
                }
            }
        }

        public List<DTO_VeChuyenBay> LayVeThanhToanTheoChuyenBay(List<DTO_ChuyenBay> dsChuyenBay)
        {
            List<DTO_VeChuyenBay> dsVeChuyenBay = new List<DTO_VeChuyenBay>();
            foreach (DTO_ChuyenBay chuyenBay in dsChuyenBay)
            {
                foreach (DTO_VeChuyenBay veChuyenBay in DAL_VeChuyenBay.LayDanhSachVeDaThanhToan(chuyenBay.MaChuyenBay))
                {
                    dsVeChuyenBay.Add(veChuyenBay);
                };
            }
            return dsVeChuyenBay;
        }
    }
}
