using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class CompanyProductService
    {
        public CompanyProductService()
        {
            this.ProductCategories = new List<ProductCategory>();
        }

        public int CompanyProductServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public string Tag { get; set; }
        public Nullable<int> companyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
