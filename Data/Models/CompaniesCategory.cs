using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class CompaniesCategory
    {
        public int CompanyCategoryId { get; set; }
        public Nullable<int> CategoryAreaId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
