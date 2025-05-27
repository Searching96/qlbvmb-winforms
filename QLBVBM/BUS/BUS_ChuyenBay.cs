using QLBVBM.DAL;
using QLBVBM.DTO;
using System.Diagnostics;
using System.Transactions;

namespace QLBVBM.BUS
{
    public class BUS_ChuyenBay
    {
        private DAL_ChuyenBay DAL_ChuyenBay = new DAL_ChuyenBay();
        private BUS_ThamSo BUS_ThamSo = new BUS_ThamSo();
        private BUS_CTChuyenBay BUS_CTChuyenBay = new BUS_CTChuyenBay();
        private BUS_HangVeCB BUS_HangVeCB = new BUS_HangVeCB();

        public List<DTO_ChuyenBay>? LayTatCaChuyenBayConTrongDuaVaoSanBayDi(string maSanBayDi)
        {
            return DAL_ChuyenBay.LayTatCaChuyenBayConTrongDuaVaoSanBayDi(maSanBayDi);
        }

        public List<DTO_ChuyenBay>? LayTatCaChuyenBayConTrongDuaVaoSanBayDen(string maSanBayDen)
        {
            return DAL_ChuyenBay.LayTatCaChuyenBayConTrongDuaVaoSanBayDen(maSanBayDen);
        }

        public List<DTO_ChuyenBay>? LayTatCaChuyenBayConTrongDuaVaoNgayBay(DateTime ngayBay)
        {
            return DAL_ChuyenBay.LayTatCaChuyenBayConTrongDuaVaoNgayBay(ngayBay);
        }

        public List<DTO_ChuyenBay> LayTatCaChuyenBayConGheTrong()
        {
            return DAL_ChuyenBay.LayTatCaChuyenBayConGheTrong();
        }

        public DTO_ChuyenBay? TimChuyenBayTheoMa(string maChuyenBay)
        {
            return DAL_ChuyenBay.TimChuyenBayTheoMa(maChuyenBay);
        }

        public DTO_ChuyenBay? LayChuyenBayCuoi()
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
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error: {ex.Message}");
                    transaction.Dispose();
                    return false;
                }
            }
        }

        public bool ValidateThoiGianBay(string textThoiGianBay)
        {
            int thoiGianBayToiThieu = BUS_ThamSo.LayThoiGianBayToiThieu();
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
            int thoiGianDungToiThieu = BUS_ThamSo.LayThoiGianDungToiThieu();
            int thoiGianDungToiDa = BUS_ThamSo.LayThoiGianDungToiDa();
            if (string.IsNullOrWhiteSpace(textThoiGianDung)
                || !int.TryParse(textThoiGianDung, out int thoiGianDung)
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

        public bool CheckDuplicateAirports(List<string> selectedAirportIds)
        {
            Dictionary<string, int> dictSanBay = new Dictionary<string, int>();

            foreach (string maSanBay in selectedAirportIds)
            {
                if (!string.IsNullOrWhiteSpace(maSanBay))
                {
                    if (dictSanBay.ContainsKey(maSanBay))
                        dictSanBay[maSanBay]++;
                    else
                        dictSanBay[maSanBay] = 1;
                }
            }

            foreach (var count in dictSanBay.Values)
                if (count > 1)
                    return true;

            return false;
        }

        public bool CheckDuplicateSeatClasses(List<string> selectedSeatClassIds)
        {
            Dictionary<string, int> dictHangGhe = new Dictionary<string, int>();
            foreach (string maHangGhe in selectedSeatClassIds)
            {
                if (!string.IsNullOrWhiteSpace(maHangGhe))
                {
                    if (dictHangGhe.ContainsKey(maHangGhe))
                        dictHangGhe[maHangGhe]++;
                    else
                        dictHangGhe[maHangGhe] = 1;
                }
            }
            foreach (var count in dictHangGhe.Values)
                if (count > 1)
                    return true;
            return false;
        }

        public List<DTO_ChuyenBay> TraCuuChuyenBay(string maSanBayDi, string maSanBayDen, string ngayGioBay)
        {
            return DAL_ChuyenBay.TraCuuChuyenBay(maSanBayDi, maSanBayDen, ngayGioBay);
        }

        public bool KiemTraHanDatVe(DTO_ChuyenBay chuyenBay)
        {
            DateTime thoiGianBay = chuyenBay.NgayBay.Value.Date + chuyenBay.GioBay.Value.TimeOfDay;
            DateTime hanCuoiDatVe = thoiGianBay.AddDays(-BUS_ThamSo.LayThoiGianDatVeToiThieu());
            return DateTime.Now <= hanCuoiDatVe;
        }



        public List<DTO_ChuyenBay> TraCuuChuyenBayNangCao(
           string maChuyenBay = null, string maSanBayDi = null, string maSanBayDen = null,
           DateTime? ngayBayTu = null, DateTime? ngayBayDen = null,
           DateTime? gioBayTu = null, DateTime? gioBayDen = null,
           int? thoiGianBayTu = null, int? thoiGianBayDen = null,
           string maSanBayTG1 = null, string ghiChuSanBayTG1 = null,
           int? thoiGianDungSBTG1_Tu = null, int? thoiGianDungSBTG1_Den = null,
           string maSanBayTG2 = null, string ghiChuSanBayTG2 = null,
           int? thoiGianDungSBTG2_Tu = null, int? thoiGianDungSBTG2_Den = null,
           string maHangGhe_Ten = null,
           string maHangGhe_DonGia = null, int? donGiaHangVeTuyenBayTu = null, int? donGiaHangVeTuyenBayDen = null,
           string maSanBayDi_TuyenBay = null, string maSanBayDen_TuyenBay = null,
           string maHangGhe_SLGhe = null, int? soLuongGheHangVeTu = null, int? soLuongGheHangVeDen = null,
           string maHangGhe_SLGheConLai = null, int? soLuongGheHangVeConLaiTu = null, int? soLuongGheHangVeConLaiDen = null,
           string maVeChuyenBay = null, int? trangThaiVe = null,
           int? donGiaVeChuyenBayTu = null, int? donGiaVeChuyenBayDen = null,
           string tenHanhKhach = null, string soCMND = null, string soDT = null)
        {
            return DAL_ChuyenBay.TraCuuChuyenBayNangCao(maChuyenBay, maSanBayDi, maSanBayDen, ngayBayTu, ngayBayDen,
                    gioBayTu, gioBayDen, thoiGianBayTu, thoiGianBayDen,
                    maSanBayTG1, ghiChuSanBayTG1, thoiGianDungSBTG1_Tu, thoiGianDungSBTG1_Den,
                    maSanBayTG2, ghiChuSanBayTG2, thoiGianDungSBTG2_Tu, thoiGianDungSBTG2_Den,
                    maHangGhe_Ten, maHangGhe_DonGia, donGiaHangVeTuyenBayTu, donGiaHangVeTuyenBayDen,
                    maSanBayDi_TuyenBay, maSanBayDen_TuyenBay,
                    maHangGhe_SLGhe, soLuongGheHangVeTu, soLuongGheHangVeDen,
                    maHangGhe_SLGheConLai, soLuongGheHangVeConLaiTu, soLuongGheHangVeConLaiDen,
                    maVeChuyenBay, trangThaiVe, donGiaVeChuyenBayTu, donGiaVeChuyenBayDen, tenHanhKhach, soCMND, soDT
                    );
        }
        
        public DateTime LayHanCuoiDatVe(DTO_ChuyenBay chuyenBay)
        {
            DateTime thoiGianBay = chuyenBay.NgayBay.Value.Date + chuyenBay.GioBay.Value.TimeOfDay;
            DateTime hanCuoiDatVe = thoiGianBay.AddDays(-BUS_ThamSo.LayThoiGianDatVeToiThieu());
            return hanCuoiDatVe;
        }

        public List<DTO_ChuyenBay>? LayTatCaChuyenBayDuaVaoThangNamBay(int thang, int nam)
        {
            return DAL_ChuyenBay.LayTatCaChuyenBayDuaVaoThangNamBay(thang, nam);
        }
    }
}
