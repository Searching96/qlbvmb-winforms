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
    public class DAL_DonGiaHangGhe
    {
        private DataHelper dataHelper = new DataHelper();

        public List<DTO_DonGiaHangGhe> LayDanhSachTenHangGheChuyenBay(string maChuyenBay)
        {
            List<DTO_DonGiaHangGhe> dsTenHangGhe = new List<DTO_DonGiaHangGhe>();
            // get available HangGhe (not sold out: SoLuong > DaBan) for the flight
            string query = @"
                SELECT hg.MaHangGhe, hg.TenHangGhe, hvcb.DonGia
                FROM HANGGHE hg
                JOIN HANGVECB hvcb ON hg.MaHangGhe = hvcb.MaHangGhe
                WHERE hvcb.MaChuyenBay = @maChuyenBay
                AND hvcb.SoLuongGhe > hvcb.SoLuongGheDaBan";

            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@maChuyenBay", maChuyenBay)
            };

            DataTable dt = dataHelper.ExecuteQuery(query, parameters);

            foreach (DataRow dr in dt.Rows)
            {
                DTO_DonGiaHangGhe donGiaHangGhe = new DTO_DonGiaHangGhe
                {
                    MaHangGhe = dr["MaHangGhe"].ToString(),
                    TenHangGhe = dr["TenHangGhe"].ToString(),
                    MaChuyenBay = maChuyenBay,
                    DonGia = Convert.ToInt32(dr["DonGia"])
                };
                dsTenHangGhe.Add(donGiaHangGhe);
            }

            return dsTenHangGhe;
        }
    }
}
