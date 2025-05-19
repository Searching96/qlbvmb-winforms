using MySql.Data.MySqlClient;
using Org.BouncyCastle.Math.Field;
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

            return dsChuyenBay;
        }

        public Tuple<string, string> LayMaSanBayDiDen(string maChuyenBay)
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
    }
}
