using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public Nullable<int> CategoryAreaId { get; set; }
        public Nullable<int> CompanyProductServiceId { get; set; }
        public virtual CompanyProductService CompanyProductService { get; set; }
    }
}
