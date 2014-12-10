using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class MapCountry
    {
        public MapCountry()
        {
            this.MapStateOrProvinces = new List<MapStateOrProvince>();
        }

        public int MapCountryId { get; set; }
        public Nullable<int> MapAreaId { get; set; }
        public string CountryName { get; set; }
        public virtual MapArea MapArea { get; set; }
        public virtual ICollection<MapStateOrProvince> MapStateOrProvinces { get; set; }
    }
}
