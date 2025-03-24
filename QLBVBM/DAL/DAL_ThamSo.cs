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
            return int.Parse(dt.Rows[0]["SoSanBayTGToiDa"].ToString());
        }

        public int LayThoiGianBayToiThieu()
        {
            string query = "SELECT TGBayToiThieu FROM THAMSO";
            DataTable dt = dataHelper.ExecuteQuery(query);
            return int.Parse(dt.Rows[0]["TGBayToiThieu"].ToString());
        }

        public int LayThoiGianDungToiThieu()
        {
            string query = "SELECT TGDungToiThieu FROM THAMSO";
            DataTable dt = dataHelper.ExecuteQuery(query);
            return int.Parse(dt.Rows[0]["TGDungToiThieu"].ToString());
        }

        public int LayThoiGianDungToiDa()
        {
            string query = "SELECT TGDungToiDa FROM THAMSO";
            DataTable dt = dataHelper.ExecuteQuery(query);
            return int.Parse(dt.Rows[0]["TGDungToiDa"].ToString());
        }
    }
}
