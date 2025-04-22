using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
