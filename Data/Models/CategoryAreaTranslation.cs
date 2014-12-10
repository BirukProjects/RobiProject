using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class CategoryAreaTranslation
    {
        public int CategoryAreaTranslationId { get; set; }
        public string LanguageCode { get; set; }
        public string CategoryNameTranslated { get; set; }
        public Nullable<int> CategoryAreaId { get; set; }
    }
}
