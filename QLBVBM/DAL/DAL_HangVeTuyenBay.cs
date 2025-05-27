using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using QLBVBM.DTO;

namespace QLBVBM.DAL
{
    public class DAL_HangVeTuyenBay
    {
        public DataHelper dataHelper = new DataHelper();

        public int LayDonGiaQuyDinh(string maSanBayDi, string maSanBayDen, string maHangGhe)
        {
            try
            {
                string query = @"SELECT DonGiaQuyDinh 
                                FROM HANGVE_TUYENBAY 
                                WHERE MaSanBayDi = @MaSanBayDi 
                                AND MaSanBayDen = @MaSanBayDen 
                                AND MaHangGhe = @MaHangGhe";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@MaSanBayDi", maSanBayDi),
                    new MySqlParameter("@MaSanBayDen", maSanBayDen),
                    new MySqlParameter("@MaHangGhe", maHangGhe)
                };

                DataTable dt = dataHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    return Convert.ToInt32(dr["DonGiaQuyDinh"]);
                }
                else throw new Exception("Không tìm thấy thông tin giá vé cho tuyến bay này.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in LayDonGiaQuyDinh (DAL_HangVeTuyenBay.cs): {ex.Message}");
                return 0;
            }
        }

        public List<DTO_SanBay> LaySanBayDenTheoSanBayDi(string maSanBayDi)
        {
            List<DTO_SanBay> dsSanBayDen = new List<DTO_SanBay>();
            try
            {
                string query = @"SELECT DISTINCT sb.MaSanBay, sb.TenSanBay 
                                FROM SANBAY sb 
                                JOIN HANGVE_TUYENBAY hvtb ON sb.MaSanBay = hvtb.MaSanBayDen 
                                WHERE hvtb.MaSanBayDi = @MaSanBayDi";
                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@MaSanBayDi", maSanBayDi)
                };

                DataTable dt = dataHelper.ExecuteQuery(query, parameters);
                foreach (DataRow dr in dt.Rows)
                {
                    DTO_SanBay sanBay = new DTO_SanBay
                    {
                        MaSanBay = dr["MaSanBay"].ToString(),
                        TenSanBay = dr["TenSanBay"].ToString()
                    };
                    dsSanBayDen.Add(sanBay);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in LaySanBayDenTheoSanBayDi (DAL_HangVeTuyenBay.cs): {ex.Message}");
                return new List<DTO_SanBay>();
            }

            return dsSanBayDen;
        }

        public List<DTO_HangGhe> LayHangGheTheoTuyenBay(string maSanBayDi, string maSanBayDen)
        {
            List<DTO_HangGhe> dsHangGhe = new List<DTO_HangGhe>();

            try
            {
                string query = @"SELECT hg.MaHangGhe, hg.TenHangGhe
                                FROM HANGGHE hg
                                JOIN HANGVE_TUYENBAY hvtb 
                                ON hg.MaHangGhe = hvtb.MaHangGhe
                                WHERE hvtb.MaSanBayDi = @MaSanBayDi
                                AND hvtb.MaSanBayDen = @MaSanBayDen";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@MaSanBayDi", maSanBayDi),
                    new MySqlParameter("@MaSanBayDen", maSanBayDen)
                };

                DataTable dt = dataHelper.ExecuteQuery(query, parameters);
                foreach (DataRow dr in dt.Rows)
                {
                    DTO_HangGhe hangGhe = new DTO_HangGhe
                    {
                        MaHangGhe = dr["MaHangGhe"].ToString(),
                        TenHangGhe = dr["TenHangGhe"].ToString()
                    };
                    dsHangGhe.Add(hangGhe);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Error in LayHangGheTheoTuyenBay (DAL_HangVeTuyenBay.cs): {ex.Message}");
                return new List<DTO_HangGhe>();
            }

            return dsHangGhe;
        }
    }
}
