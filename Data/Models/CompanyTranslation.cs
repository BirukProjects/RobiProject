using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class CompanyTranslation
    {
        public int CompanyTranslationID { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public virtual Company Company { get; set; }
    }
}
