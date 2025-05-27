using QLBVBM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBVBM.DTO;

namespace QLBVBM.BUS
{
    public class BUS_ThamSo
    {
        private DAL_ThamSo DAL_ThamSo = new DAL_ThamSo();
        private static Dictionary<string, object> cache = new Dictionary<string, object>();

        private T GetCachedValue<T>(string cacheKey, Func<T> getValue)
        {
            if (cache.ContainsKey(cacheKey))
            {
                return (T)cache[cacheKey];
            }

            T value = getValue();
            cache[cacheKey] = value;
            return value;
        }

        public int LaySoLuongSanBayToiDa()
        {
            return GetCachedValue(nameof(LaySoLuongSanBayToiDa),
                () => DAL_ThamSo.LaySoLuongSanBayToiDa());
        }

        public int LayThoiGianBayToiThieu()
        {
            return GetCachedValue(nameof(LayThoiGianBayToiThieu),
                () => DAL_ThamSo.LayThoiGianBayToiThieu());
        }

        public int LayThoiGianDungToiThieu()
        {
            return GetCachedValue(nameof(LayThoiGianDungToiThieu),
                () => DAL_ThamSo.LayThoiGianDungToiThieu());
        }

        public int LayThoiGianDungToiDa()
        {
            return GetCachedValue(nameof(LayThoiGianDungToiDa),
                () => DAL_ThamSo.LayThoiGianDungToiDa());
        }

        public int LayThoiGianDatVeToiThieu()
        {
            return GetCachedValue(nameof(LayThoiGianDatVeToiThieu),
                () => DAL_ThamSo.LayThoiGianDatVeToiThieu());
        }

        public int LayThoiGianHuyDatVeToiThieu()
        {
            return GetCachedValue(nameof(LayThoiGianHuyDatVeToiThieu),
                () => DAL_ThamSo.LayThoiGianHuyDatVeToiThieu());
        }

        public bool ValidateThamSo(string thamSo)
        {
            if (string.IsNullOrWhiteSpace(thamSo))
                return false;

            if (int.TryParse(thamSo, out int value))
                return value > 0;

            return false;
        }

        public bool CapNhatThamSo(DTO_ThamSo thamSoDuocCapNhat)
        {
            bool result = DAL_ThamSo.CapNhatThamSo(thamSoDuocCapNhat);
            if (result) cache.Clear(); // Clear cache if update is successful
            return result;
        }
    }
}
