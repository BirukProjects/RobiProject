using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class CompanyCategory
    {
        public int CompanyCategoryId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public virtual Company Company { get; set; }
    }
}
