using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVBM.DTO
{
    public class DTO_ThamSo
    {
        private int? soSanBayTGToiDa;
        private int? tgBayToiThieu;
        private int? tgDungToiThieu;
        private int? tgDungToiDa;
        //private int? tgDatTruocVeToiThieu;
        //private int? tgHuyDatTruocVeToiThieu;

        public DTO_ThamSo(int? soSanBayTGToiDa = null, int? tgBayToiThieu = null, int? tgDungToiThieu = null, int? tgDungToiDa = null)
        {
            this.soSanBayTGToiDa = soSanBayTGToiDa;
            this.tgBayToiThieu = tgBayToiThieu;
            this.tgDungToiThieu = tgDungToiThieu;
            this.tgDungToiDa = tgDungToiDa;
            //this.tgDatTruocVeToiThieu = tgDatTruocVeToiThieu;
            //this.tgHuyDatTruocVeToiThieu = tgHuyDatTruocVeToiThieu;
        }

        public int? SoSanBayTGToiDa { get => soSanBayTGToiDa; set => soSanBayTGToiDa = value; }
        public int? TgBayToiThieu { get => tgBayToiThieu; set => tgBayToiThieu = value; }
        public int? TgDungToiThieu { get => tgDungToiThieu; set => tgDungToiThieu = value; }
        public int? TgDungToiDa { get => tgDungToiDa; set => tgDungToiDa = value; }
        //public int? TgDatTruocVeToiThieu { get => tgDatTruocVeToiThieu; set => tgDatTruocVeToiThieu = value; }
        //public int? TgHuyDatTruocVeToiThieu { get => tgHuyDatTruocVeToiThieu; set => tgHuyDatTruocVeToiThieu = value; }
    }
}
