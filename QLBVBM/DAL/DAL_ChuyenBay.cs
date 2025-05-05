using MySql.Data.MySqlClient;
using QLBVBM.DTO;
using System.Data;

namespace QLBVBM.DAL
{
    public class DAL_ChuyenBay
    {
        private DataHelper dataHelper = new DataHelper();

        public bool ThemChuyenBay(DTO_ChuyenBay chuyenBay)
        {
            string query = "INSERT INTO CHUYENBAY (MaChuyenBay, MaSanBayDi, MaSanBayDen, NgayBay, GioBay, ThoiGianBay) " +
               "VALUES (@MaChuyenBay, @MaSanBayDi, @MaSanBayDen, @NgayBay, @GioBay, @ThoiGianBay)";

            List<MySqlParameter> parameters = new List<MySqlParameter>
                    {
                        new MySqlParameter("@MaChuyenBay", chuyenBay.MaChuyenBay),
                        new MySqlParameter("@MaSanBayDi", chuyenBay.MaSanBayDi),
                        new MySqlParameter("@MaSanBayDen", chuyenBay.MaSanBayDen),
                        new MySqlParameter("@NgayBay", chuyenBay.NgayBay),
                        new MySqlParameter("@GioBay", chuyenBay.GioBay),
                        new MySqlParameter("@ThoiGianBay", chuyenBay.ThoiGianBay),
                    };

            int result = dataHelper.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public DTO_ChuyenBay? LayChuyenBayCuoi()
        {
            string query = "SELECT * FROM CHUYENBAY ORDER BY MaChuyenBay DESC LIMIT 1";
            DataTable dt = dataHelper.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new DTO_ChuyenBay
                {
                    MaChuyenBay = dr["MaChuyenBay"].ToString(),
                };
            }

            return null;
        }

        public List<DTO_ChuyenBay> TraCuuChuyenBay(string maSanBayDi, string maSanBayDen, string ngayBay)
        {
            List<DTO_ChuyenBay> dsChuyenBay = new List<DTO_ChuyenBay>();

            // Only Get Chuyen Bay with available seats
            string query = @"
                SELECT cb.*
                FROM CHUYENBAY cb
                JOIN HANGVECB hv ON cb.MaChuyenBay = hv.MaChuyenBay
                WHERE MaSanBayDi = @MaSanBayDi 
                    AND MaSanBayDen = @MaSanBayDen 
                    AND NgayBay = @NgayBay
                GROUP BY cb.MaChuyenBay
                HAVING SUM(hv.SoLuongGhe - hv.SoLuongGheDaBan) > 0";

            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@MaSanBayDi", maSanBayDi),
                new MySqlParameter("@MaSanBayDen", maSanBayDen),
                new MySqlParameter("@NgayBay", ngayBay)
            };

            DataTable dt = dataHelper.ExecuteQuery(query, parameters);
            foreach (DataRow dr in dt.Rows)
            {
                DTO_ChuyenBay cb = new DTO_ChuyenBay
                {
                    MaChuyenBay = dr["MaChuyenBay"].ToString(),
                    MaSanBayDi = dr["MaSanBayDi"].ToString(),
                    MaSanBayDen = dr["MaSanBayDen"].ToString(),
                    NgayBay = DateTime.Parse(dr["NgayBay"].ToString()),
                    GioBay = DateTime.Parse(dr["GioBay"].ToString()),
                    ThoiGianBay = int.Parse(dr["ThoiGianBay"].ToString())
                };
                dsChuyenBay.Add(cb);
            }

            return dsChuyenBay;
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
            string maHangGhe_DonGia = null, int? donGiaHangVeTu = null, int? donGiaHangVeDen = null,
            string maHangGhe_SLGhe = null, int? soLuongGheHangVeTu = null, int? soLuongGheHangVeDen = null,
            string maHangGhe_SLGheDaBan = null, int? soLuongGheHangVeDaBanTu = null, int? soLuongGheHangVeDaBanDen = null,
            string maHangGhe_SLGheDaDat = null, int? soLuongGheHangVeDaDatTu = null, int? soLuongGheHangVeDaDatDen = null,
            string maVeChuyenBay = null, int? trangThaiVe = null,
            string tenHanhKhach = null, string soCMND = null, string soDT = null,
            DateTime? thoiDiemThanhToanTu = null, DateTime? thoiDiemThanhToanDen = null)
        {
            List<DTO_ChuyenBay> dsChuyenBay = new List<DTO_ChuyenBay>();
            string query = @"
                SELECT
                    cb.MaChuyenBay,
                    cb.MaSanBayDi,
                    cb.MaSanBayDen,
                    cb.NgayBay,
                    cb.GioBay,
                    cb.ThoiGianBay,
                    COALESCE(SUM(hvcb.SoLuongGhe), 0) AS TongSoGhe,
                    COALESCE(SUM(hvcb.SoLuongGheDaBan), 0) + COALESCE(SUM(hvcb.SLGheDaDat), 0) AS SoGheDat,
                    COALESCE(SUM(hvcb.SoLuongGhe), 0) - (COALESCE(SUM(hvcb.SoLuongGheDaBan), 0) + COALESCE(SUM(hvcb.SLGheDaDat), 0)) AS SoGheTrong
                FROM CHUYENBAY cb
                JOIN SANBAY sbDi ON cb.MaSanBayDi = sbDi.MaSanBay
                JOIN SANBAY sbDen ON cb.MaSanBayDen = sbDen.MaSanBay
                LEFT JOIN CTCHUYENBAY ct1 ON cb.MaChuyenBay = ct1.MaChuyenBay
                LEFT JOIN CTCHUYENBAY ct2 ON cb.MaChuyenBay = ct2.MaChuyenBay
                LEFT JOIN HANGVECB hvcb ON cb.MaChuyenBay = hvcb.MaChuyenBay
                LEFT JOIN HANGGHE hg ON hvcb.MaHangGhe = hg.MaHangGhe
                LEFT JOIN VECHUYENBAY vcb ON cb.MaChuyenBay = vcb.MaChuyenBay
                                            AND vcb.MaHangGhe = hg.MaHangGhe
                WHERE 1 = 0";

            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(maChuyenBay))
            {
                query += " OR cb.MaChuyenBay LIKE @MaChuyenBay";
                parameters.Add(new MySqlParameter("@MaChuyenBay", $"%{maChuyenBay}%"));
            }
            if (!string.IsNullOrEmpty(maSanBayDi) && !maSanBayDi.Equals("ALL"))
            {
                query += " OR cb.MaSanBayDi = @MaSanBayDi";
                parameters.Add(new MySqlParameter("@MaSanBayDi", maSanBayDi));
            }
            if (!string.IsNullOrEmpty(maSanBayDen) && !maSanBayDen.Equals("ALL"))
            {
                query += " OR cb.MaSanBayDen = @MaSanBayDen";
                parameters.Add(new MySqlParameter("@MaSanBayDen", maSanBayDen));
            }
            if (ngayBayTu.HasValue || ngayBayDen.HasValue)
            {
                List<string> ngayBayConditions = new List<string>();
                if (ngayBayTu.HasValue)
                {
                    ngayBayConditions.Add("cb.NgayBay >= @NgayBayTu");
                    parameters.Add(new MySqlParameter("@NgayBayTu", ngayBayTu.Value));
                }
                if (ngayBayDen.HasValue)
                {
                    ngayBayConditions.Add("cb.NgayBay <= @NgayBayDen");
                    parameters.Add(new MySqlParameter("@NgayBayDen", ngayBayDen.Value));
                }
                if (ngayBayConditions.Count > 0)
                {
                    query += " OR " + (ngayBayConditions.Count > 1 ? "(" + string.Join(" AND ", ngayBayConditions) + ")" : ngayBayConditions[0]);
                }
            }
            if (gioBayTu.HasValue || gioBayDen.HasValue)
            {
                List<string> gioBayConditions = new List<string>();
                if (gioBayTu.HasValue)
                {
                    gioBayConditions.Add("cb.GioBay >= @GioBayTu");
                    parameters.Add(new MySqlParameter("@GioBayTu", gioBayTu.Value));
                }
                if (gioBayDen.HasValue)
                {
                    gioBayConditions.Add("cb.GioBay <= @GioBayDen");
                    parameters.Add(new MySqlParameter("@GioBayDen", gioBayDen.Value));
                }
                if (gioBayConditions.Count > 0)
                {
                    query += " OR " + (gioBayConditions.Count > 1 ? "(" + string.Join(" AND ", gioBayConditions) + ")" : gioBayConditions[0]);
                }
            }
            if (thoiGianBayTu.HasValue || thoiGianBayDen.HasValue)
            {
                List<string> thoiGianBayConditions = new List<string>();
                if (thoiGianBayTu.HasValue)
                {
                    thoiGianBayConditions.Add("cb.ThoiGianBay >= @ThoiGianBayTu");
                    parameters.Add(new MySqlParameter("@ThoiGianBayTu", thoiGianBayTu.Value));
                }
                if (thoiGianBayDen.HasValue)
                {
                    thoiGianBayConditions.Add("cb.ThoiGianBay <= @ThoiGianBayDen");
                    parameters.Add(new MySqlParameter("@ThoiGianBayDen", thoiGianBayDen.Value));
                }
                if (thoiGianBayConditions.Count > 0)
                {
                    query += " OR " + (thoiGianBayConditions.Count > 1 ? "(" + string.Join(" AND ", thoiGianBayConditions) + ")" : thoiGianBayConditions[0]);
                }
            }
            if (!string.IsNullOrEmpty(maSanBayTG1) && !maSanBayTG1.Equals("ALL"))
            {
                query += " OR ct1.MaSanBayTG = @MaSanBayTG1";
                parameters.Add(new MySqlParameter("@MaSanBayTG1", maSanBayTG1));
            }
            if (!string.IsNullOrEmpty(ghiChuSanBayTG1))
            {
                query += " OR ct1.GhiChu LIKE @GhiChuSanBayTG1";
                parameters.Add(new MySqlParameter("@GhiChuSanBayTG1", $"%{ghiChuSanBayTG1}%"));
            }
            if (thoiGianDungSBTG1_Tu.HasValue || thoiGianDungSBTG1_Den.HasValue)
            {
                List<string> thoiGianDungSBTG1Conditions = new List<string>();
                if (thoiGianDungSBTG1_Tu.HasValue)
                {
                    thoiGianDungSBTG1Conditions.Add("ct1.ThoiGianDung >= @ThoiGianDungSBTG1_Tu");
                    parameters.Add(new MySqlParameter("@ThoiGianDungSBTG1_Tu", thoiGianDungSBTG1_Tu.Value));
                }
                if (thoiGianDungSBTG1_Den.HasValue)
                {
                    thoiGianDungSBTG1Conditions.Add("ct1.ThoiGianDung <= @ThoiGianDungSBTG1_Den");
                    parameters.Add(new MySqlParameter("@ThoiGianDungSBTG1_Den", thoiGianDungSBTG1_Den.Value));
                }
                if (thoiGianDungSBTG1Conditions.Count > 0)
                {
                    query += " OR " + (thoiGianDungSBTG1Conditions.Count > 1 ? "(" + string.Join(" AND ", thoiGianDungSBTG1Conditions) + ")" : thoiGianDungSBTG1Conditions[0]);
                }
            }
            if (!string.IsNullOrEmpty(maSanBayTG2) && !maSanBayTG2.Equals("ALL"))
            {
                query += " OR ct2.MaSanBayTG = @MaSanBayTG2";
                parameters.Add(new MySqlParameter("@MaSanBayTG2", maSanBayTG2));
            }
            if (!string.IsNullOrEmpty(ghiChuSanBayTG2))
            {
                query += " OR ct2.GhiChu LIKE @GhiChuSanBayTG2";
                parameters.Add(new MySqlParameter("@GhiChuSanBayTG2", $"%{ghiChuSanBayTG2}%"));
            }
            if (thoiGianDungSBTG2_Tu.HasValue || thoiGianDungSBTG2_Den.HasValue)
            {
                List<string> thoiGianDungSBTG2Conditions = new List<string>();
                if (thoiGianDungSBTG2_Tu.HasValue)
                {
                    thoiGianDungSBTG2Conditions.Add("ct2.ThoiGianDung >= @ThoiGianDungSBTG2_Tu");
                    parameters.Add(new MySqlParameter("@ThoiGianDungSBTG2_Tu", thoiGianDungSBTG2_Tu.Value));
                }
                if (thoiGianDungSBTG2_Den.HasValue)
                {
                    thoiGianDungSBTG2Conditions.Add("ct2.ThoiGianDung <= @ThoiGianDungSBTG2_Den");
                    parameters.Add(new MySqlParameter("@ThoiGianDungSBTG2_Den", thoiGianDungSBTG2_Den.Value));
                }
                if (thoiGianDungSBTG2Conditions.Count > 0)
                {
                    query += " OR " + (thoiGianDungSBTG2Conditions.Count > 1 ? "(" + string.Join(" AND ", thoiGianDungSBTG2Conditions) + ")" : thoiGianDungSBTG2Conditions[0]);
                }
            }
            if (!string.IsNullOrEmpty(maHangGhe_Ten) && !maHangGhe_Ten.Equals("ALL"))
            {
                query += " OR hg.TenHangGhe = @TenHangGhe";
                parameters.Add(new MySqlParameter("@TenHangGhe", maHangGhe_Ten));
            }
            if (donGiaHangVeTu.HasValue || donGiaHangVeDen.HasValue)
            {
                List<string> donGiaHangVeConditions = new List<string>();
                if (donGiaHangVeTu.HasValue)
                {
                    donGiaHangVeConditions.Add("hvcb.DonGia >= @DonGiaHangVeTu");
                    parameters.Add(new MySqlParameter("@DonGiaHangVeTu", donGiaHangVeTu.Value));
                }
                if (donGiaHangVeDen.HasValue)
                {
                    donGiaHangVeConditions.Add("hvcb.DonGia <= @DonGiaHangVeDen");
                    parameters.Add(new MySqlParameter("@DonGiaHangVeDen", donGiaHangVeDen.Value));
                }
                if (donGiaHangVeConditions.Count > 0)
                {
                    query += " OR " + (donGiaHangVeConditions.Count > 1 ? "(" + string.Join(" AND ", donGiaHangVeConditions) + ")" : donGiaHangVeConditions[0]);
                }
            }
            if (!string.IsNullOrEmpty(maHangGhe_DonGia) && !maHangGhe_DonGia.Equals("ALL"))
            {
                query += " OR hvcb.DonGia = @DonGiaHangVe";
                parameters.Add(new MySqlParameter("@DonGiaHangVe", maHangGhe_DonGia));
            }
            if (soLuongGheHangVeTu.HasValue || soLuongGheHangVeDen.HasValue)
            {
                List<string> soLuongGheHangVeConditions = new List<string>();
                if (soLuongGheHangVeTu.HasValue)
                {
                    soLuongGheHangVeConditions.Add("hvcb.SoLuongGhe >= @SoLuongGheHangVeTu");
                    parameters.Add(new MySqlParameter("@SoLuongGheHangVeTu", soLuongGheHangVeTu.Value));
                }
                if (soLuongGheHangVeDen.HasValue)
                {
                    soLuongGheHangVeConditions.Add("hvcb.SoLuongGhe <= @SoLuongGheHangVeDen");
                    parameters.Add(new MySqlParameter("@SoLuongGheHangVeDen", soLuongGheHangVeDen.Value));
                }
                if (soLuongGheHangVeConditions.Count > 0)
                {
                    query += " OR " + (soLuongGheHangVeConditions.Count > 1 ? "(" + string.Join(" AND ", soLuongGheHangVeConditions) + ")" : soLuongGheHangVeConditions[0]);
                }
            }
            if (!string.IsNullOrEmpty(maHangGhe_SLGhe) && !maHangGhe_SLGhe.Equals("ALL"))
            {
                query += " OR hvcb.SoLuongGhe = @SLGheHangVe";
                parameters.Add(new MySqlParameter("@SLGheHangVe", maHangGhe_SLGhe));
            }
            if (soLuongGheHangVeDaBanTu.HasValue || soLuongGheHangVeDaBanDen.HasValue)
            {
                List<string> soLuongGheDaBanConditions = new List<string>();
                if (soLuongGheHangVeDaBanTu.HasValue)
                {
                    soLuongGheDaBanConditions.Add("hvcb.SoLuongGheDaBan >= @SoLuongGheHangVeDaBanTu");
                    parameters.Add(new MySqlParameter("@SoLuongGheHangVeDaBanTu", soLuongGheHangVeDaBanTu.Value));
                }
                if (soLuongGheHangVeDaBanDen.HasValue)
                {
                    soLuongGheDaBanConditions.Add("hvcb.SoLuongGheDaBan <= @SoLuongGheHangVeDaBanDen");
                    parameters.Add(new MySqlParameter("@SoLuongGheHangVeDaBanDen", soLuongGheHangVeDaBanDen.Value));
                }
                if (soLuongGheDaBanConditions.Count > 0)
                {
                    query += " OR " + (soLuongGheDaBanConditions.Count > 1 ? "(" + string.Join(" AND ", soLuongGheDaBanConditions) + ")" : soLuongGheDaBanConditions[0]);
                }
            }
            if (!string.IsNullOrEmpty(maHangGhe_SLGheDaBan) && !maHangGhe_SLGheDaBan.Equals("ALL"))
            {
                query += " OR hvcb.SoLuongGheDaBan = @SLGheDaBanHangVe";
                parameters.Add(new MySqlParameter("@SLGheDaBanHangVe", maHangGhe_SLGheDaBan));
            }
            if (soLuongGheHangVeDaDatTu.HasValue || soLuongGheHangVeDaDatDen.HasValue)
            {
                List<string> soLuongGheDaDatConditions = new List<string>();
                if (soLuongGheHangVeDaDatTu.HasValue)
                {
                    soLuongGheDaDatConditions.Add("hvcb.SLGheDaDat >= @SoLuongGheHangVeDaDatTu");
                    parameters.Add(new MySqlParameter("@SoLuongGheHangVeDaDatTu", soLuongGheHangVeDaDatTu.Value));
                }
                if (soLuongGheHangVeDaDatDen.HasValue)
                {
                    soLuongGheDaDatConditions.Add("hvcb.SLGheDaDat <= @SoLuongGheHangVeDaDatDen");
                    parameters.Add(new MySqlParameter("@SoLuongGheHangVeDaDatDen", soLuongGheHangVeDaDatDen.Value));
                }
                if (soLuongGheDaDatConditions.Count > 0)
                {
                    query += " OR " + (soLuongGheDaDatConditions.Count > 1 ? "(" + string.Join(" AND ", soLuongGheDaDatConditions) + ")" : soLuongGheDaDatConditions[0]);
                }
            }
            if (!string.IsNullOrEmpty(maHangGhe_SLGheDaDat) && !maHangGhe_SLGheDaDat.Equals("ALL"))
            {
                query += " OR hvcb.SLGheDaDat = @SLGheDaDatHangVe";
                parameters.Add(new MySqlParameter("@SLGheDaDatHangVe", maHangGhe_SLGheDaDat));
            }
            if (!string.IsNullOrEmpty(maVeChuyenBay))
            {
                query += " OR vcb.MaVeChuyenBay LIKE @MaVeChuyenBay";
                parameters.Add(new MySqlParameter("@MaVeChuyenBay", $"%{maVeChuyenBay}%"));
            }
            if (trangThaiVe.HasValue && trangThaiVe != -1)
            {
                query += " OR vcb.TrangThaiVe = @TrangThaiVe";
                parameters.Add(new MySqlParameter("@TrangThaiVe", trangThaiVe.Value));
            }
            if (!string.IsNullOrEmpty(tenHanhKhach))
            {
                query += " OR vcb.TenHanhKhach LIKE @TenHanhKhach";
                parameters.Add(new MySqlParameter("@TenHanhKhach", $"%{tenHanhKhach}%"));
            }
            if (!string.IsNullOrEmpty(soCMND))
            {
                query += " OR vcb.CMND LIKE @SoCMND";
                parameters.Add(new MySqlParameter("@SoCMND", $"%{soCMND}%"));
            }
            if (!string.IsNullOrEmpty(soDT))
            {
                query += " OR vcb.SoDienThoai LIKE @SoDT";
                parameters.Add(new MySqlParameter("@SoDT", $"%{soDT}%"));
            }
            if (thoiDiemThanhToanTu.HasValue || thoiDiemThanhToanDen.HasValue)
            {
                List<string> thoiDiemThanhToanConditions = new List<string>();
                if (thoiDiemThanhToanTu.HasValue)
                {
                    thoiDiemThanhToanConditions.Add("vcb.ThoiDiemThanhToan >= @ThoiDiemThanhToanTu");
                    parameters.Add(new MySqlParameter("@ThoiDiemThanhToanTu", thoiDiemThanhToanTu.Value));
                }
                if (thoiDiemThanhToanDen.HasValue)
                {
                    thoiDiemThanhToanConditions.Add("vcb.ThoiDiemThanhToan <= @ThoiDiemThanhToanDen");
                    parameters.Add(new MySqlParameter("@ThoiDiemThanhToanDen", thoiDiemThanhToanDen.Value));
                }
                if (thoiDiemThanhToanConditions.Count > 0)
                {
                    query += " OR " + (thoiDiemThanhToanConditions.Count > 1 ? "(" + string.Join(" AND ", thoiDiemThanhToanConditions) + ")" : thoiDiemThanhToanConditions[0]);
                }
            }

            query += " GROUP BY cb.MaChuyenBay, cb.MaSanBayDi, cb.MaSanBayDen, cb.NgayBay, cb.GioBay, cb.ThoiGianBay";
            query += " ORDER BY cb.NgayBay, cb.GioBay";

            DataTable dt = dataHelper.ExecuteQuery(query, parameters);
            foreach (DataRow dr in dt.Rows)
            {
                DTO_ChuyenBay cb = new DTO_ChuyenBay
                {
                    MaChuyenBay = dr["MaChuyenBay"].ToString(),
                    MaSanBayDi = dr["MaSanBayDi"].ToString(),
                    MaSanBayDen = dr["MaSanBayDen"].ToString(),
                    NgayBay = DateTime.TryParse(dr["NgayBay"].ToString(), out DateTime ngayBay) ? ngayBay : null,
                    GioBay = DateTime.TryParse(dr["GioBay"].ToString(), out DateTime gioBay) ? gioBay : null,
                    ThoiGianBay = int.TryParse(dr["ThoiGianBay"].ToString(), out int thoiGianBay) ? thoiGianBay : null,
                    SoGheDat = int.TryParse(dr["SoGheDat"].ToString(), out int soGheDat) ? soGheDat : 0,
                    SoGheTrong = int.TryParse(dr["SoGheTrong"].ToString(), out int soGheTrong) ? soGheTrong : 0
                };
                dsChuyenBay.Add(cb);
            }
            return dsChuyenBay;
        }
    }
}
