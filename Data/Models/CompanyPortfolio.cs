using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class CompanyPortfolio
    {
        public int CompanyPortfolioId { get; set; }
        public string CompanyPortfolioName { get; set; }
        public string CompanyPortfolioUrl { get; set; }
        public string CompanyPortfolioDescription { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public string CompanyPortfolioTags { get; set; }
        public virtual Company Company { get; set; }
    }
}
