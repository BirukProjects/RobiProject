using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class MapCity
    {
        public int MapCityId { get; set; }
        public Nullable<int> MapStateOrProvinceId { get; set; }
        public string CityName { get; set; }
        public string ZipCode { get; set; }
        public virtual MapStateOrProvince MapStateOrProvince { get; set; }
    }
}
