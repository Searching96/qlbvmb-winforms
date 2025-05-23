using MySql.Data.MySqlClient;
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
    public class DAL_DonGiaHangGhe
    {
        private DataHelper dataHelper = new DataHelper();
        private DAL_ChuyenBay dalChuyenBay = new DAL_ChuyenBay();   
        private DAL_HangVeTuyenBay dalHangVeTuyenBay = new DAL_HangVeTuyenBay();

        public List<DTO_DonGiaHangGhe> LayDanhSachTenHangGheChuyenBay(string maChuyenBay)
        {
            List<DTO_DonGiaHangGhe> dsTenHangGhe = new List<DTO_DonGiaHangGhe>();
            try
            {
                // get available HangGhe (not sold out: ConLai > 0) for the flight
                string query = @"
                    SELECT hg.MaHangGhe, hg.TenHangGhe
                    FROM HANGGHE hg
                    JOIN HANGVECB hvcb ON hg.MaHangGhe = hvcb.MaHangGhe
                    WHERE hvcb.MaChuyenBay = @maChuyenBay
                    AND hvcb.SLGheConLai > 0";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@maChuyenBay", maChuyenBay)
                };

                // Get the departure and arrival airports for the flight
                Tuple<string, string> maSanBayDiDen = dalChuyenBay.LayMaSanBayDiDen(maChuyenBay);
                string maSanBayDi = maSanBayDiDen.Item1;
                string maSanBayDen = maSanBayDiDen.Item2;

                DataTable dt = dataHelper.ExecuteQuery(query, parameters);

                foreach (DataRow dr in dt.Rows)
                {
                    DTO_DonGiaHangGhe donGiaHangGhe = new DTO_DonGiaHangGhe
                    {
                        MaHangGhe = dr["MaHangGhe"].ToString(),
                        TenHangGhe = dr["TenHangGhe"].ToString(),
                        MaChuyenBay = maChuyenBay,
                        DonGia = dalHangVeTuyenBay.LayDonGiaQuyDinh(maSanBayDi, maSanBayDen, dr["MaHangGhe"].ToString())
                    };
                    dsTenHangGhe.Add(donGiaHangGhe);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in LayDanhSachTenHangGheChuyenBay (DAL_DonGiaHangGhe.cs): {ex.Message}");
                return new List<DTO_DonGiaHangGhe>();
            }

            return dsTenHangGhe;
        }
    }
}
