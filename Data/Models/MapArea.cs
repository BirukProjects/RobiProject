using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class MapArea
    {
        public MapArea()
        {
            this.MapCountries = new List<MapCountry>();
        }

        public int MapAreaId { get; set; }
        public string MapAreaName { get; set; }
        public virtual ICollection<MapCountry> MapCountries { get; set; }
    }
}
