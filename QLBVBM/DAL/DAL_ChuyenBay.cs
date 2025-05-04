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
                    COALESCE(SUM(hvcb.SoLuongGheDaBan), 0) +COALESCE(SUM(hvcb.SLGheDaDat), 0) AS SoGheDat,
                    COALESCE(SUM(hvcb.SoLuongGhe), 0) -(COALESCE(SUM(hvcb.SoLuongGheDaBan), 0) + COALESCE(SUM(hvcb.SLGheDaDat), 0)) AS SoGheTrong
                FROM CHUYENBAY cb
                JOIN SANBAY sbDi ON cb.MaSanBayDi = sbDi.MaSanBay
                JOIN SANBAY sbDen ON cb.MaSanBayDen = sbDen.MaSanBay
                LEFT JOIN CTCHUYENBAY ct1 ON cb.MaChuyenBay = ct1.MaChuyenBay
                LEFT JOIN CTCHUYENBAY ct2 ON cb.MaChuyenBay = ct2.MaChuyenBay
                LEFT JOIN HANGVECB hvcb ON cb.MaChuyenBay = hvcb.MaChuyenBay
                LEFT JOIN HANGGHE hg ON hvcb.MaHangGhe = hg.MaHangGhe
                LEFT JOIN VECHUYENBAY vcb ON cb.MaChuyenBay = vcb.MaChuyenBay
                                            AND vcb.MaHangGhe = hg.MaHangGhe
                WHERE 1 = 1";

            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(maChuyenBay))
            {
                query += " AND cb.MaChuyenBay LIKE @MaChuyenBay";
                parameters.Add(new MySqlParameter("@MaChuyenBay", $"%{maChuyenBay}%"));
            }
            if (!maSanBayDi.Equals("ALL"))
            {
                query += " AND cb.MaSanBayDi = @MaSanBayDi";
                parameters.Add(new MySqlParameter("@MaSanBayDi", maSanBayDi));
            }
            if (!maSanBayDen.Equals("ALL"))
            {
                query += " AND cb.MaSanBayDen = @MaSanBayDen";
                parameters.Add(new MySqlParameter("@MaSanBayDen", maSanBayDen));
            }
            if (ngayBayTu.HasValue)
            {
                query += " AND cb.NgayBay >= @NgayBayTu";
                parameters.Add(new MySqlParameter("@NgayBayTu", ngayBayTu.Value));
            }
            if (ngayBayDen.HasValue)
            {
                query += " AND cb.NgayBay <= @NgayBayDen";
                parameters.Add(new MySqlParameter("@NgayBayDen", ngayBayDen.Value));
            }
            if (gioBayTu.HasValue)
            {
                query += " AND cb.GioBay >= @GioBayTu";
                parameters.Add(new MySqlParameter("@GioBayTu", gioBayTu.Value));
            }
            if (gioBayDen.HasValue)
            {
                query += " AND cb.GioBay <= @GioBayDen";
                parameters.Add(new MySqlParameter("@GioBayDen", gioBayDen.Value));
            }
            if (!maSanBayTG1.Equals("ALL"))
            {
                query += " AND ct1.MaSanBayTG = @MaSanBayTG1";
                parameters.Add(new MySqlParameter("@MaSanBayTG1", maSanBayTG1));
            }
            if (thoiGianDungSBTG1_Tu.HasValue)
            {
                query += " AND ct1.ThoiGianDung >= @ThoiGianDungSBTG1_Tu";
                parameters.Add(new MySqlParameter("@ThoiGianDungSBTG1_Tu", thoiGianDungSBTG1_Tu.Value));
            }
            if (thoiGianDungSBTG1_Den.HasValue)
            {
                query += " AND ct1.ThoiGianDung <= @ThoiGianDungSBTG1_Den";
                parameters.Add(new MySqlParameter("@ThoiGianDungSBTG1_Den", thoiGianDungSBTG1_Den.Value));
            }
            if (!string.IsNullOrEmpty(ghiChuSanBayTG1))
            {
                query += " AND ct1.GhiChu LIKE @GhiChuSanBayTG1";
                parameters.Add(new MySqlParameter("@GhiChuSanBayTG1", $"%{ghiChuSanBayTG1}%"));
            }
            if (!maSanBayTG2.Equals("ALL"))
            {
                query += " AND ct2.MaSanBayTG = @MaSanBayTG2";
                parameters.Add(new MySqlParameter("@MaSanBayTG2", maSanBayTG2));
            }
            if (thoiGianDungSBTG2_Tu.HasValue)
            {
                query += " AND ct2.ThoiGianDung >= @ThoiGianDungSBTG2_Tu";
                parameters.Add(new MySqlParameter("@ThoiGianDungSBTG2_Tu", thoiGianDungSBTG2_Tu.Value));
            }
            if (thoiGianDungSBTG2_Den.HasValue)
            {
                query += " AND ct2.ThoiGianDung <= @ThoiGianDungSBTG2_Den";
                parameters.Add(new MySqlParameter("@ThoiGianDungSBTG2_Den", thoiGianDungSBTG2_Den.Value));
            }
            if (!string.IsNullOrEmpty(ghiChuSanBayTG2))
            {
                query += " AND ct2.GhiChu LIKE @GhiChuSanBayTG2";
                parameters.Add(new MySqlParameter("@GhiChuSanBayTG2", $"%{ghiChuSanBayTG2}%"));
            }
            if (thoiGianBayTu.HasValue)
            {
                query += " AND cb.ThoiGianBay >= @ThoiGianBayTu";
                parameters.Add(new MySqlParameter("@ThoiGianBayTu", thoiGianBayTu.Value));
            }
            if (thoiGianBayDen.HasValue)
            {
                query += " AND cb.ThoiGianBay <= @ThoiGianBayDen";
                parameters.Add(new MySqlParameter("@ThoiGianBayDen", thoiGianBayDen.Value));
            }
            if (!maHangGhe_Ten.Equals("ALL"))
            {
                query += " AND hg.TenHangGhe = @TenHangGhe";
                parameters.Add(new MySqlParameter("@TenHangGhe", maHangGhe_Ten));
            }
            if (!maHangGhe_DonGia.Equals("ALL"))
            {
                query += " AND hg.DonGia = @DonGiaHangVe";
                parameters.Add(new MySqlParameter("@DonGiaHangVe", maHangGhe_DonGia));
            }
            if (donGiaHangVeTu.HasValue)
            {
                query += " AND hg.DonGia >= @DonGiaHangVeTu";
                parameters.Add(new MySqlParameter("@DonGiaHangVeTu", donGiaHangVeTu.Value));
            }
            if (donGiaHangVeDen.HasValue)
            {
                query += " AND hg.DonGia <= @DonGiaHangVeDen";
                parameters.Add(new MySqlParameter("@DonGiaHangVeDen", donGiaHangVeDen.Value));
            }
            if (!maHangGhe_SLGhe.Equals("ALL"))
            {
                query += " AND hg.SoLuongGhe = @SLGheHangVe";
                parameters.Add(new MySqlParameter("@SLGheHangVe", maHangGhe_SLGhe));
            }
            if (soLuongGheHangVeTu.HasValue)
            {
                query += " AND hg.SoLuongGhe >= @SoLuongGheHangVeTu";
                parameters.Add(new MySqlParameter("@SoLuongGheHangVeTu", soLuongGheHangVeTu.Value));
            }
            if (soLuongGheHangVeDen.HasValue)
            {
                query += " AND hg.SoLuongGhe <= @SoLuongGheHangVeDen";
                parameters.Add(new MySqlParameter("@SoLuongGheHangVeDen", soLuongGheHangVeDen.Value));
            }
            if (!maHangGhe_SLGheDaBan.Equals("ALL"))
            {
                query += " AND hg.SoLuongGheDaBan = @SLGheDaBanHangVe";
                parameters.Add(new MySqlParameter("@SLGheDaBanHangVe", maHangGhe_SLGheDaBan));
            }
            if (soLuongGheHangVeDaBanTu.HasValue)
            {
                query += " AND hg.SoLuongGheDaBan >= @SoLuongGheHangVeDaBanTu";
                parameters.Add(new MySqlParameter("@SoLuongGheHangVeDaBanTu", soLuongGheHangVeDaBanTu.Value));
            }
            if (soLuongGheHangVeDaBanDen.HasValue)
            {
                query += " AND hg.SoLuongGheDaBan <= @SoLuongGheHangVeDaBanDen";
                parameters.Add(new MySqlParameter("@SoLuongGheHangVeDaBanDen", soLuongGheHangVeDaBanDen.Value));
            }
            if (!maHangGhe_SLGheDaDat.Equals("ALL"))
            {
                query += " AND hg.SoLuongGheDaDat = @SLGheDaDatHangVe";
                parameters.Add(new MySqlParameter("@SLGheDaDatHangVe", maHangGhe_SLGheDaDat));
            }
            if (soLuongGheHangVeDaDatTu.HasValue)
            {
                query += " AND hg.SoLuongGheDaDat >= @SoLuongGheHangVeDaDatTu";
                parameters.Add(new MySqlParameter("@SoLuongGheHangVeDaDatTu", soLuongGheHangVeDaDatTu.Value));
            }
            if (soLuongGheHangVeDaDatDen.HasValue)
            {
                query += " AND hg.SoLuongGheDaDat <= @SoLuongGheHangVeDaDatDen";
                parameters.Add(new MySqlParameter("@SoLuongGheHangVeDaDatDen", soLuongGheHangVeDaDatDen.Value));
            }
            if (!string.IsNullOrEmpty(maVeChuyenBay))
            {
                query += " AND vcb.MaVeChuyenBay LIKE @MaVeChuyenBay";
                parameters.Add(new MySqlParameter("@MaVeChuyenBay", $"%{maVeChuyenBay}%"));
            }
            if (trangThaiVe != -1)
            {
                query += " AND vcb.TrangThaiVe = @TrangThaiVe";
                parameters.Add(new MySqlParameter("@TrangThaiVe", trangThaiVe.Value));
            }
            if (!string.IsNullOrEmpty(tenHanhKhach))
            {
                query += " AND vcb.TenHanhKhach LIKE @TenHanhKhach";
                parameters.Add(new MySqlParameter("@TenHanhKhach", $"%{tenHanhKhach}%"));
            }
            if (!string.IsNullOrEmpty(soCMND))
            {
                query += " AND vcb.SoCMND LIKE @SoCMND";
                parameters.Add(new MySqlParameter("@SoCMND", $"%{soCMND}%"));
            }
            if (!string.IsNullOrEmpty(soDT))
            {
                query += " AND vcb.SoDT LIKE @SoDT";
                parameters.Add(new MySqlParameter("@SoDT", $"%{soDT}%"));
            }
            if (thoiDiemThanhToanTu.HasValue)
            {
                query += " AND vcb.ThoiDiemThanhToan >= @ThoiDiemThanhToanTu";
                parameters.Add(new MySqlParameter("@ThoiDiemThanhToanTu", thoiDiemThanhToanTu.Value));
            }
            if (thoiDiemThanhToanDen.HasValue)
            {
                query += " AND vcb.ThoiDiemThanhToan <= @ThoiDiemThanhToanDen";
                parameters.Add(new MySqlParameter("@ThoiDiemThanhToanDen", thoiDiemThanhToanDen.Value));
            }
            query += " GROUP BY cb.MaChuyenBay";
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
