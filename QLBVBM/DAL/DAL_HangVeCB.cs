using MySql.Data.MySqlClient;
using QLBVBM.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace QLBVBM.DAL
{
    public class DAL_HangVeCB
    {
        private DataHelper dataHelper = new DataHelper();

        public bool ThemHangVeCB(DTO_HangVeCB hangVeCB)
        {
            try
            {
                string query = "INSERT INTO HANGVECB (MaChuyenBay, MaHangGhe, SoLuongGhe, SLGheConLai) " +
                "VALUES (@MaChuyenBay, @MaHangGhe, @SoLuongGhe, @SoLuongGheConLai)";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@MaChuyenBay", hangVeCB.MaChuyenBay),
                    new MySqlParameter("@MaHangGhe", hangVeCB.MaHangGhe),
                    new MySqlParameter("@SoLuongGhe", hangVeCB.SoLuongGhe),
                    new MySqlParameter("@SoLuongGheConLai", hangVeCB.SoLuongGheConLai ?? 0),
                };

                int result = dataHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in ThemHangVeCB (DAL_HangVeCB.cs): {ex.Message}");
                return false;
            }
        }

        public bool CapNhatSoLuongVeDaBan(string maChuyenBay, string maHangGhe)
        {
            try
            {
                string query = @"UPDATE HANGVECB 
                            SET SLGheConLai = SLGheConLai - 1 
                            WHERE MaChuyenBay = @MaChuyenBay 
                            AND MaHangGhe = @MaHangGhe";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@MaChuyenBay", maChuyenBay),
                    new MySqlParameter("@MaHangGhe", maHangGhe)
                };

                int result = dataHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in CapNhatSoLuongVeDaBan (DAL_HangVeCB.cs): {ex.Message}");
                return false;
            }
        }

        public List<DTO_HangVeCB> TraCuuHangVe(string maChuyenBay)
        {
            List<DTO_HangVeCB> dsHangVe = new List<DTO_HangVeCB>();

            try
            {
                string query = $"SELECT * FROM HANGVECB WHERE MaChuyenBay = '{maChuyenBay}'";
                DataTable dt = dataHelper.ExecuteQuery(query);

                foreach (DataRow dr in dt.Rows)
                {
                    DTO_HangVeCB hangVeCB = new DTO_HangVeCB
                    {
                        MaChuyenBay = dr["MaChuyenBay"].ToString(),
                        MaHangGhe = dr["MaHangGhe"].ToString(),
                        SoLuongGhe = Convert.ToInt32(dr["SoLuongGhe"]),
                        SoLuongGheConLai = Convert.ToInt32(dr["SLGheConLai"]),
                    };
                    dsHangVe.Add(hangVeCB);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in TraCuuHangVe (DAL_HangVeCB.cs): {ex.Message}");
                return new List<DTO_HangVeCB>();
            }

            return dsHangVe;
        }

        public bool CapNhatSoLuongVeDaDat(string maChuyenBay, string maHangGhe)
        {
            try
            {
                string query = @"UPDATE HANGVECB 
                            SET SLGheConLai = SLGheConLai - 1 
                            WHERE MaChuyenBay = @MaChuyenBay 
                            AND MaHangGhe = @MaHangGhe";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@MaChuyenBay", maChuyenBay),
                    new MySqlParameter("@MaHangGhe", maHangGhe)
                };

                int result = dataHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in CapNhatSoLuongVeDaDat (DAL_HangVeCB.cs): {ex.Message}");
                return false;
            }
        }

        public DTO_HangVeCB TraCuuMotHangVe(string maChuyenBay, string maHangGhe)
        {
            DTO_HangVeCB hangVe = new DTO_HangVeCB();

            try
            {
                string query = $"SELECT * FROM HANGVECB WHERE MaChuyenBay = '{maChuyenBay}' AND MaHangGhe = '{maHangGhe}'";
                DataTable dt = dataHelper.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    DTO_HangVeCB hangVeCB = new DTO_HangVeCB
                    {
                        MaChuyenBay = dr["MaChuyenBay"].ToString(),
                        MaHangGhe = dr["MaHangGhe"].ToString(),
                        SoLuongGhe = Convert.ToInt32(dr["SoLuongGhe"]),
                        SoLuongGheConLai = Convert.ToInt32(dr["SLGheConLai"]),
                    };
                    return hangVeCB;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in TraCuuMotHangVe (DAL_HangVeCB.cs): {ex.Message}");
                return new DTO_HangVeCB();
            }

            return hangVe;
        }
    }
}
