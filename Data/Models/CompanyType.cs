using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class CompanyType
    {
        public CompanyType()
        {
            this.Companies = new List<Company>();
        }

        public int CompanyTypeId { get; set; }
        public string CompanyTypeName { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
    }
}
