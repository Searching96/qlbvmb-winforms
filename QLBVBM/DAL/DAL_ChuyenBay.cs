using MySql.Data.MySqlClient;
using Org.BouncyCastle.Math.Field;
using QLBVBM.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVBM.DAL
{
    public class DAL_ChuyenBay
    {
        private DataHelper dataHelper = new DataHelper();

        public List<DTO_ChuyenBay> LayTatCaChuyenBay()
        {
            List<DTO_ChuyenBay> dsChuyenBay = new List<DTO_ChuyenBay>();
            try
            {
                string query = "SELECT * FROM CHUYENBAY";
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
                Debug.WriteLine($"Error in LayTatCaChuyenBay (DAL_ChuyenBay.cs): {ex.Message}");
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
    }
}
