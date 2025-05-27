using MySql.Data.MySqlClient;
using QLBVBM.DTO;
using System.Data;
using System.Diagnostics;

namespace QLBVBM.DAL
{
    public class DAL_ChuyenBay
    {
        private DataHelper dataHelper = new DataHelper();

        public List<DTO_ChuyenBay>? LayTatCaChuyenBayConTrongDuaVaoSanBayDi(string maSanBayDi)
        {
            List<DTO_ChuyenBay> dsChuyenBay = new List<DTO_ChuyenBay>();
            try
            {
                string query = @"
                    SELECT cb.*
                    FROM CHUYENBAY cb
                    JOIN HANGVECB hv ON cb.MaChuyenBay = hv.MaChuyenBay
                    WHERE MaSanBayDi = @MaSanBayDi  
                    GROUP BY cb.MaChuyenBay
                    HAVING SUM(hv.SLGheConLai) > 0";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@MaSanBayDi", maSanBayDi)
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in LayTatCaChuyenBayConGheTrong (DAL_ChuyenBay.cs): {ex.Message}");
            }
            return dsChuyenBay;
        }

        public List<DTO_ChuyenBay>? LayTatCaChuyenBayConTrongDuaVaoSanBayDen(string maSanBayDen)
        {
            List<DTO_ChuyenBay> dsChuyenBay = new List<DTO_ChuyenBay>();
            try
            {
                string query = @"
                    SELECT cb.*
                    FROM CHUYENBAY cb
                    JOIN HANGVECB hv ON cb.MaChuyenBay = hv.MaChuyenBay
                    WHERE MaSanBayDen = @MaSanBayDen  
                    GROUP BY cb.MaChuyenBay
                    HAVING SUM(hv.SLGheConLai) > 0";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@MaSanBayDen", maSanBayDen)
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in LayTatCaChuyenBayConGheTrong (DAL_ChuyenBay.cs): {ex.Message}");
            }
            return dsChuyenBay;
        }

        public List<DTO_ChuyenBay>? LayTatCaChuyenBayConTrongDuaVaoNgayBay(DateTime ngayBay)
        {
            List<DTO_ChuyenBay> dsChuyenBay = new List<DTO_ChuyenBay>();
            try
            {
                string query = @"
                    SELECT cb.*
                    FROM CHUYENBAY cb
                    JOIN HANGVECB hv ON cb.MaChuyenBay = hv.MaChuyenBay
                    WHERE DATE(cb.NgayBay) = @NgayBay
                    GROUP BY cb.MaChuyenBay
                    HAVING SUM(hv.SLGheConLai) > 0";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@NgayBay", ngayBay.ToString("yyyy-MM-dd"))
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in LayTatCaChuyenBayConTrongDuaVaoNgayBay (DAL_ChuyenBay.cs): {ex.Message}");
            }
            return dsChuyenBay;
        }

        public List<DTO_ChuyenBay> LayTatCaChuyenBayConGheTrong()
        {
            List<DTO_ChuyenBay> dsChuyenBay = new List<DTO_ChuyenBay>();
            try
            {
                string query = @"
                    SELECT cb.*
                    FROM CHUYENBAY cb
                    JOIN HANGVECB hv ON cb.MaChuyenBay = hv.MaChuyenBay
                    GROUP BY cb.MaChuyenBay
                    HAVING SUM(hv.SLGheConLai) > 0";
                DataTable dt = dataHelper.ExecuteQuery(query);
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in LayTatCaChuyenBayConGheTrong (DAL_ChuyenBay.cs): {ex.Message}");
            }
            return dsChuyenBay;
        }

        public DTO_ChuyenBay? TimChuyenBayTheoMa(string maChuyenBay)
        {
            try
            {
                string query = "SELECT * FROM CHUYENBAY WHERE MaChuyenBay = @MaChuyenBay";
                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@MaChuyenBay", maChuyenBay)
                };
                DataTable dt = dataHelper.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    return new DTO_ChuyenBay
                    {
                        MaChuyenBay = dr["MaChuyenBay"].ToString(),
                        MaSanBayDi = dr["MaSanBayDi"].ToString(),
                        MaSanBayDen = dr["MaSanBayDen"].ToString(),
                        NgayBay = DateTime.Parse(dr["NgayBay"].ToString()),
                        GioBay = DateTime.Parse(dr["GioBay"].ToString()),
                        ThoiGianBay = int.Parse(dr["ThoiGianBay"].ToString())
                    };
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in TimChuyenBayTheoMa (DAL_ChuyenBay.cs): {ex.Message}");
            }
            return null;
        }

        public bool ThemChuyenBay(DTO_ChuyenBay chuyenBay)
        {
            try
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
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in ThemChuyenBay (DAL_ChuyenBay.cs): {ex.Message}");
                return false;
            }
        }

        public DTO_ChuyenBay? LayChuyenBayCuoi()
        {
            try
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
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in LayChuyenBayCuoi (DAL_ChuyenBay.cs): {ex.Message}");
                return null;
            }
        }

        public List<DTO_ChuyenBay> TraCuuChuyenBay(string maSanBayDi, string maSanBayDen, string ngayBay)
        {
            List<DTO_ChuyenBay> dsChuyenBay = new List<DTO_ChuyenBay>();
            try
            {
                // Only Get Chuyen Bay with available seats
                string query = @"
                    SELECT cb.*
                    FROM CHUYENBAY cb
                    JOIN HANGVECB hv ON cb.MaChuyenBay = hv.MaChuyenBay
                    WHERE MaSanBayDi = @MaSanBayDi 
                        AND MaSanBayDen = @MaSanBayDen 
                        AND NgayBay = @NgayBay
                    GROUP BY cb.MaChuyenBay
                    HAVING SUM(hv.SLGheConLai) > 0";

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
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in TraCuuChuyenBay (DAL_ChuyenBay.cs): {ex.Message}");
                return new List<DTO_ChuyenBay>();
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
            string maHangGhe_DonGia = null, int? donGiaHangVeTuyenBayTu = null, int? donGiaHangVeTuyenBayDen = null,
            string maSanBayDi_TuyenBay = null, string maSanBayDen_TuyenBay = null,
            string maHangGhe_SLGhe = null, int? soLuongGheHangVeTu = null, int? soLuongGheHangVeDen = null,
            string maHangGhe_SLGheConLai = null, int? soLuongGheHangVeConLaiTu = null, int? soLuongGheHangVeConLaiDen = null,
            string maVeChuyenBay = null, int? trangThaiVe = null,
            int? donGiaVeChuyenBayTu = null, int? donGiaVeChuyenBayDen = null,
            string tenHanhKhach = null, string soCMND = null, string soDT = null
            )
        {
            List<DTO_ChuyenBay> dsChuyenBay = new List<DTO_ChuyenBay>();
            string query = @"
                SELECT
                   cb.MaChuyenBay,
                   cb.MaSanBayDi,
                   cb.MaSanBayDen,
                   cb.NgayBay,
                   cb.GioBay,
                   cb.ThoiGianBay
                FROM CHUYENBAY cb
                JOIN SANBAY sbDi ON cb.MaSanBayDi = sbDi.MaSanBay
                JOIN SANBAY sbDen ON cb.MaSanBayDen = sbDen.MaSanBay
                LEFT JOIN CTCHUYENBAY ct1 ON cb.MaChuyenBay = ct1.MaChuyenBay
                LEFT JOIN CTCHUYENBAY ct2 ON cb.MaChuyenBay = ct2.MaChuyenBay
                LEFT JOIN HANGVECB hvcb ON cb.MaChuyenBay = hvcb.MaChuyenBay
                LEFT JOIN HANGGHE hg ON hvcb.MaHangGhe = hg.MaHangGhe
                LEFT JOIN VECHUYENBAY vcb ON cb.MaChuyenBay = vcb.MaChuyenBay
                                          AND vcb.MaHangGhe = hg.MaHangGhe
                LEFT JOIN HANGVE_TUYENBAY hvtb ON cb.MaSanBayDi = hvtb.MaSanBayDi
                                               AND cb.MaSanBayDen = hvtb.MaSanBayDen
                                               AND hvcb.MaHangGhe = hvtb.MaHangGhe
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
                    query += " OR " + "(" + string.Join(" AND ", ngayBayConditions) + ")";
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
                    query += " OR " + "(" + string.Join(" AND ", gioBayConditions) + ")";
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
                    query += " OR " + "(" + string.Join(" AND ", thoiGianBayConditions) + ")";
                }
            }

            // Xử lý điều kiện ở các trường thông tin liên quan đến sân bay trung gian.
            List<string> sbtgConditions = new List<string>();

            var sbtgMappings = new List<(string alias, string maSB, string ghiChu, int? tu, int? den, string prefix)>
                {
                    ("ct1", maSanBayTG1, ghiChuSanBayTG1, thoiGianDungSBTG1_Tu, thoiGianDungSBTG1_Den, "TG1"),
                    ("ct2", maSanBayTG2, ghiChuSanBayTG2, thoiGianDungSBTG2_Tu, thoiGianDungSBTG2_Den, "TG2")
                };

            foreach (var (alias, maSB, ghiChu, tu, den, prefix) in sbtgMappings)
            {
                bool hasMaSB = !string.IsNullOrEmpty(maSB) && !maSB.Equals("ALL");
                bool hasGhiChu = !string.IsNullOrEmpty(ghiChu);
                bool hasThoiGianDung = tu.HasValue || den.HasValue;

                if (hasMaSB)
                {
                    List<string> subConditions = new List<string>();
                    subConditions.Add($"{alias}.MaSanBayTG = @{prefix}_MaSB");
                    parameters.Add(new MySqlParameter($"@{prefix}_MaSB", maSB));


                    if (hasGhiChu)
                    {
                        subConditions.Add($"{alias}.GhiChu LIKE @{prefix}_GhiChu");
                        parameters.Add(new MySqlParameter($"@{prefix}_GhiChu", $"%{ghiChu}%"));
                    }

                    if (tu.HasValue)
                    {
                        subConditions.Add($"{alias}.ThoiGianDung >= @{prefix}_Tu");
                        parameters.Add(new MySqlParameter($"@{prefix}_Tu", tu.Value));
                    }

                    if (den.HasValue)
                    {
                        subConditions.Add($"{alias}.ThoiGianDung <= @{prefix}_Den");
                        parameters.Add(new MySqlParameter($"@{prefix}_Den", den.Value));
                    }

                    if (subConditions.Count > 0)
                    {
                        sbtgConditions.Add("(" + string.Join(" AND ", subConditions) + ")");
                    }
                }
                else
                {
                    List<string> orGroup = new List<string>();

                    if (hasGhiChu)
                    {
                        orGroup.Add($"{alias}.GhiChu LIKE @{prefix}_GhiChu");
                        parameters.Add(new MySqlParameter($"@{prefix}_GhiChu", $"%{ghiChu}%"));
                    }

                    if (tu.HasValue || den.HasValue)
                    {
                        List<string> timeConditions = new List<string>();
                        if (tu.HasValue)
                        {
                            timeConditions.Add($"{alias}.ThoiGianDung >= @{prefix}_Tu");
                            parameters.Add(new MySqlParameter($"@{prefix}_Tu", tu.Value));
                        }
                        if (den.HasValue)
                        {
                            timeConditions.Add($"{alias}.ThoiGianDung <= @{prefix}_Den");
                            parameters.Add(new MySqlParameter($"@{prefix}_Den", den.Value));
                        }

                        // Nếu có điều kiện thời gian thì gộp bằng AND
                        if (timeConditions.Count > 0)
                        {
                            orGroup.Add("(" + string.Join(" AND ", timeConditions) + ")");
                        }
                    }

                    if (orGroup.Count > 0)
                    {
                        sbtgConditions.Add("(" + string.Join(" OR ", orGroup) + ")");
                    }
                }
            }

            if (sbtgConditions.Count > 0)
            {
                query += " OR (" + string.Join(" OR ", sbtgConditions) + ")";
            }

            if (!string.IsNullOrEmpty(maHangGhe_Ten) && !maHangGhe_Ten.Equals("ALL"))
            {
                query += " OR hg.MaHangGhe = @MaHangGhe";
                parameters.Add(new MySqlParameter("@MaHangGhe", maHangGhe_Ten));
            }

            // Xử lý điều kiện ở các trường thông tin liên quan đến số lượng ghế các hạng ghế.
            List<string> hangGhe_conditions = new List<string>();

            var fieldGheMappings = new Dictionary<string, (string maHangGhe, int? tu, int? den)>
            {
                { "SoLuongGhe", (maHangGhe_SLGhe, soLuongGheHangVeTu, soLuongGheHangVeDen) },
                { "SLGheConLai", (maHangGhe_SLGheConLai, soLuongGheHangVeConLaiTu, soLuongGheHangVeConLaiDen) }
            };
            foreach (var mapping in fieldGheMappings)
            {
                string field = mapping.Key;
                string maHangGhe = mapping.Value.maHangGhe;
                int? tu = mapping.Value.tu;
                int? den = mapping.Value.den;

                if (tu.HasValue || den.HasValue)
                {
                    List<string> fieldConditions = new List<string>();
                    bool hasHangGhe = !string.IsNullOrEmpty(maHangGhe) && !maHangGhe.Equals("ALL");

                    if (hasHangGhe)
                    {
                        fieldConditions.Add($"hvcb.MaHangGhe = @{field}HangGhe");
                        parameters.Add(new MySqlParameter($"@{field}HangGhe", maHangGhe));
                    }

                    if (tu.HasValue)
                    {
                        fieldConditions.Add($"hvcb.{field} >= @{field}Tu");
                        parameters.Add(new MySqlParameter($"@{field}Tu", tu.Value));
                    }
                    if (den.HasValue)
                    {
                        fieldConditions.Add($"hvcb.{field} <= @{field}Den");
                        parameters.Add(new MySqlParameter($"@{field}Den", den.Value));
                    }

                    hangGhe_conditions.Add("(" + string.Join(" AND ", fieldConditions) + ")");
                }
            }
            if (hangGhe_conditions.Count > 0)
            {
                query += " OR (" + string.Join(" OR ", hangGhe_conditions) + ")";
            }

            // Xử lý điều kiện ở các trường thông tin liên quan đến tuyến bay 
            List<string> tuyenBayConditions = new List<string>();

            var tuyenBayMappings = new List<(string field, string value, int? tu, int? den)>
            {
                ("MaHangGhe", maHangGhe_DonGia, null, null),
                ("MaSanBayDi", maSanBayDi_TuyenBay, null, null),
                ("MaSanBayDen", maSanBayDen_TuyenBay, null, null),
                ("DonGiaQuyDinh", null, donGiaHangVeTuyenBayTu, donGiaHangVeTuyenBayDen)
            };

            foreach (var (field, value, tu, den) in tuyenBayMappings)
            {
                List<string> fieldConditions = new List<string>();

                if (!string.IsNullOrEmpty(value) && !value.Equals("ALL"))
                {
                    fieldConditions.Add($"hvtb.{field} = @TuyenBay_{field}");
                    parameters.Add(new MySqlParameter($"@TuyenBay_{field}", value));
                }

                if (field == "DonGiaQuyDinh" && (tu.HasValue || den.HasValue))
                {
                    if (tu.HasValue)
                    {
                        fieldConditions.Add($"hvtb.{field} >= @TuyenBay_{field}_Tu");
                        parameters.Add(new MySqlParameter($"@TuyenBay_{field}_Tu", tu.Value));
                    }
                    if (den.HasValue)
                    {
                        fieldConditions.Add($"hvtb.{field} <= @TuyenBay_{field}_Den");
                        parameters.Add(new MySqlParameter($"@TuyenBay_{field}_Den", den.Value));
                    }
                }

                if (fieldConditions.Count > 0)
                {
                    tuyenBayConditions.Add("(" + string.Join(" AND ", fieldConditions) + ")");
                }
            }

            if (tuyenBayConditions.Count > 0)
            {
                query += " OR (" + string.Join(" AND ", tuyenBayConditions) + ")";
            }


            if (!string.IsNullOrEmpty(maVeChuyenBay))
            {
                query += " OR vcb.MaVe LIKE @MaVeChuyenBay";
                parameters.Add(new MySqlParameter("@MaVeChuyenBay", $"%{maVeChuyenBay}%"));
            }
            if (trangThaiVe.HasValue && trangThaiVe != -1)
            {
                query += " OR vcb.TrangThaiVe = @TrangThaiVe";
                parameters.Add(new MySqlParameter("@TrangThaiVe", trangThaiVe.Value));
            }

            if (donGiaVeChuyenBayTu.HasValue || donGiaVeChuyenBayDen.HasValue)
            {
                List<string> donGiaConditions = new List<string>();
                if (donGiaVeChuyenBayTu.HasValue)
                {
                    donGiaConditions.Add("vcb.DonGia >= @DonGiaVeChuyenBayTu");
                    parameters.Add(new MySqlParameter("@DonGiaVeChuyenBayTu", donGiaVeChuyenBayTu.Value));
                }
                if (donGiaVeChuyenBayDen.HasValue)
                {
                    donGiaConditions.Add("vcb.DonGia <= @DonGiaVeChuyenBayDen");
                    parameters.Add(new MySqlParameter("@DonGiaVeChuyenBayDen", donGiaVeChuyenBayDen.Value));
                }
                if (donGiaConditions.Count > 0)
                {
                    query += " OR " + "(" + string.Join(" AND ", donGiaConditions) + ")";
                }
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

            query += " GROUP BY cb.MaChuyenBay, cb.MaSanBayDi, cb.MaSanBayDen, cb.NgayBay, cb.GioBay, cb.ThoiGianBay";
            query += " ORDER BY cb.MaChuyenBay";

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
                    SoGheDat = 0,
                    SoGheTrong = 0
                };
                dsChuyenBay.Add(cb);
            }

            // Lấy thông tin số lượng ghế đã đặt và còn trống cho các chuyến bay đã được truy vấn.
            if (dsChuyenBay.Count > 0)
            {
                List<string> maChuyenBayList = dsChuyenBay.Select(cb => cb.MaChuyenBay).ToList();
                string seatQuery = @"
                    SELECT
                        MaChuyenBay,
                        COALESCE(SUM(SoLuongGhe), 0) - COALESCE(SUM(SLGheConLai), 0) AS SoGheDat,
                        COALESCE(SUM(SLGheConLai), 0) AS SoGheTrong
                    FROM HANGVECB
                    WHERE MaChuyenBay IN ({0})
                    GROUP BY MaChuyenBay";

                var placeholders = string.Join(",", maChuyenBayList.Select((_, i) => $"@MaChuyenBay{i}"));
                seatQuery = string.Format(seatQuery, placeholders);

                List<MySqlParameter> seatParameters = new List<MySqlParameter>();
                for (int i = 0; i < maChuyenBayList.Count; i++)
                {
                    seatParameters.Add(new MySqlParameter($"@MaChuyenBay{i}", maChuyenBayList[i]));
                }

                DataTable seatDt = dataHelper.ExecuteQuery(seatQuery, seatParameters);

                foreach (DataRow seatRow in seatDt.Rows)
                {
                    string maChuyenBaySeat = seatRow["MaChuyenBay"].ToString();
                    var chuyenBay = dsChuyenBay.FirstOrDefault(cb => cb.MaChuyenBay == maChuyenBaySeat);
                    if (chuyenBay != null)
                    {
                        chuyenBay.SoGheDat = int.TryParse(seatRow["SoGheDat"].ToString(), out int soGheDat) ? soGheDat : 0;
                        chuyenBay.SoGheTrong = int.TryParse(seatRow["SoGheTrong"].ToString(), out int soGheTrong) ? soGheTrong : 0;
                    }
                }
            }
            return dsChuyenBay;
        }

        public Tuple<string, string> LayMaSanBayDiDen(string maChuyenBay)
        {
            try
            {
                Tuple<string, string> maSanBayDiDen = new Tuple<string, string>("", "");
                string query = "SELECT MaSanBayDi, MaSanBayDen FROM CHUYENBAY WHERE MaChuyenBay = @MaChuyenBay";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@MaChuyenBay", maChuyenBay)
                };

                DataTable dt = dataHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count == 0)
                {
                    return maSanBayDiDen;
                }

                DataRow dr = dt.Rows[0];
                maSanBayDiDen = new Tuple<string, string>(dr["MaSanBayDi"].ToString(), dr["MaSanBayDen"].ToString());

                return maSanBayDiDen;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in LayMaSanBayDiDen (DAL_ChuyenBay.cs): {ex.Message}");
                return new Tuple<string, string>("", "");
            }
        }
      
        public List<DTO_ChuyenBay> LayChuyenBayTheoNam(int nam)
        {
            List<DTO_ChuyenBay> dsChuyenBay = new List<DTO_ChuyenBay>();
            try
            {
                string query = @"
            SELECT cb.*
            FROM CHUYENBAY cb
            WHERE YEAR(cb.NgayBay) = @Nam
            ORDER BY cb.NgayBay, cb.GioBay";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@Nam", nam)
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in LayChuyenBayTheoNam (DAL_ChuyenBay.cs): {ex.Message}");
                return new List<DTO_ChuyenBay>();
            }

            return dsChuyenBay;
        }
      
        public List<DTO_ChuyenBay> LayTatCaChuyenBayDuaVaoThangNamBay(int thang, int nam)
        {
            List<DTO_ChuyenBay> dsChuyenBay = new List<DTO_ChuyenBay>();
            try
            {
                string query = @"
                    SELECT cb.*
                    FROM CHUYENBAY cb
                    WHERE MONTH(cb.NgayBay) = @thang
                    AND YEAR(cb.NgayBay) = @nam";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@thang", thang),
                    new MySqlParameter("@nam", nam)
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in LayTatCaChuyenBayDuaVaoThangNamBay (DAL_ChuyenBay.cs): {ex.Message}");
            }
            return dsChuyenBay;
        }
      
    }
}
