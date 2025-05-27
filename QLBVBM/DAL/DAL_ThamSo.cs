using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using QLBVBM.DTO;
using System.Diagnostics;

namespace QLBVBM.DAL
{
    public class DAL_ThamSo
    {
        DataHelper dataHelper = new DataHelper();

        public int LaySoLuongSanBayToiDa()
        {
            string query = "SELECT SoSanBayTGToiDa FROM THAMSO";
            DataTable dt = dataHelper.ExecuteQuery(query);
            int result;
            int.TryParse(dt.Rows[0]["SoSanBayTGToiDa"].ToString(), out result);
            return result;
        }

        public int LayThoiGianBayToiThieu()
        {
            string query = "SELECT TGBayToiThieu FROM THAMSO";
            DataTable dt = dataHelper.ExecuteQuery(query);
            int result;
            int.TryParse(dt.Rows[0]["TGBayToiThieu"].ToString(), out result);
            return result;
        }

        public int LayThoiGianDungToiThieu()
        {
            string query = "SELECT TGDungToiThieu FROM THAMSO";
            DataTable dt = dataHelper.ExecuteQuery(query);
            int result;
            int.TryParse(dt.Rows[0]["TGDungToiThieu"].ToString(), out result);
            return result;
        }

        public int LayThoiGianDungToiDa()
        {
            string query = "SELECT TGDungToiDa FROM THAMSO";
            DataTable dt = dataHelper.ExecuteQuery(query);
            int result;
            int.TryParse(dt.Rows[0]["TGDungToiDa"].ToString(), out result);
            return result;
        }

        public int LayThoiGianDatVeToiThieu()
        {
            string query = "SELECT TGDatTruocVeToiThieu FROM THAMSO";
            DataTable dt = dataHelper.ExecuteQuery(query);
            int result;
            int.TryParse(dt.Rows[0]["TGDatTruocVeToiThieu"].ToString(), out result);
            return result;
        }

        public int LayThoiGianHuyDatVeToiThieu()
        {
            string query = "SELECT TGHuyDatTruocVeToiThieu FROM THAMSO";
            DataTable dt = dataHelper.ExecuteQuery(query);
            int result;
            int.TryParse(dt.Rows[0]["TGHuyDatTruocVeToiThieu"].ToString(), out result);
            return result;
        }

        public bool CapNhatThamSo(DTO_ThamSo thamSoDuocCapNhat)
        {
            try
            {
                string query = @"UPDATE THAMSO 
                                SET SoSanBayTGToiDa         = @SoSanBayTGToiDa,
                                    TGBayToiThieu           = @TGBayToiThieu,
                                    TGDungToiThieu          = @TGDungToiDa,
                                    TGDungToiDa             = @TGDungToiDa,
                                    TGDatTruocVeToiThieu    = @TGDatTruocVeToiThieu,
                                    TGHuyDatTruocVeToiThieu = @TGHuyDatTruocVeToiThieu";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@SoSanBayTGToiDa", thamSoDuocCapNhat.SoSanBayTGToiDa),
                    new MySqlParameter("@TGBayToiThieu", thamSoDuocCapNhat.TgBayToiThieu),
                    new MySqlParameter("@TGDungToiThieu", thamSoDuocCapNhat.TgDungToiThieu),
                    new MySqlParameter("@TGDungToiDa", thamSoDuocCapNhat.TgDungToiDa),
                    new MySqlParameter("@TGDatTruocVeToiThieu", thamSoDuocCapNhat.TgDatTruocVeToiThieu),
                    new MySqlParameter("@TGHuyDatTruocVeToiThieu", thamSoDuocCapNhat.TgHuyDatTruocVeToiThieu)
                };

                int result = dataHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in CapNhatThamSo (DAL_ThamSo.cs): {ex.Message}");
                return false;
            }
        }
    }
}
