using MySql.Data.MySqlClient;
using QLBVBM.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVBM.DAL
{
    public class DAL_ChuyenBay
    {
        private DataHelper dataHelper = new DataHelper();

        public bool ThemChuyenBay(DTO_ChuyenBay chuyenBay)
        {
            string query = "INSERT INTO CHUYENBAY (MaChuyenBay, MaSanBayDi, MaSanBayDen, NgayGioBay, ThoiGianBay) " +
               "VALUES (@MaChuyenBay, @MaSanBayDi, @MaSanBayDen, @NgayGioBay, @ThoiGianBay)";

            List<MySqlParameter> parameters = new List<MySqlParameter>
                    {
                        new MySqlParameter("@MaChuyenBay", chuyenBay.MaChuyenBay),
                        new MySqlParameter("@MaSanBayDi", chuyenBay.MaSanBayDi),
                        new MySqlParameter("@MaSanBayDen", chuyenBay.MaSanBayDen),
                        new MySqlParameter("@NgayGioBay", chuyenBay.NgayGioBay),
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
            string query = $"SELECT * FROM CHUYENBAY WHERE MaSanBayDi = '{maSanBayDi}' AND MaSanBayDen = '{maSanBayDen}' AND DATE(NgayGioBay) = '{ngayBay}'";
            DataTable dt = dataHelper.ExecuteQuery(query);

            foreach (DataRow dr in dt.Rows)
            {
                DTO_ChuyenBay cb = new DTO_ChuyenBay
                {
                    MaChuyenBay = dr["MaChuyenBay"].ToString(),
                    MaSanBayDi = dr["MaSanBayDi"].ToString(),
                    MaSanBayDen = dr["MaSanBayDen"].ToString(),
                    NgayGioBay = DateTime.Parse(dr["NgayGioBay"].ToString()),
                    ThoiGianBay = int.Parse(dr["ThoiGianBay"].ToString())
                };
                dsChuyenBay.Add(cb);
            }

            return dsChuyenBay;
        }
    }
}
