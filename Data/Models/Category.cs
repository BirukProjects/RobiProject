using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Category
    {
        public Category()
        {
            this.CategoryAreas = new List<CategoryArea>();
        }

        public int CategoryID { get; set; }
        public string Area { get; set; }
        public string Category1 { get; set; }
        public string Subcategory { get; set; }
        public virtual ICollection<CategoryArea> CategoryAreas { get; set; }
    }
}
