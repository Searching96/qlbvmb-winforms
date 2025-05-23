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
    }
}
