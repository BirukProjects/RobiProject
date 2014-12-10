using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class MapStateOrProvince
    {
        public MapStateOrProvince()
        {
            this.MapCities = new List<MapCity>();
        }

        public int MapStateOrProvinceId { get; set; }
        public Nullable<int> MapCountryId { get; set; }
        public string StateOrProvinceName { get; set; }
        public virtual ICollection<MapCity> MapCities { get; set; }
        public virtual MapCountry MapCountry { get; set; }
    }
}
