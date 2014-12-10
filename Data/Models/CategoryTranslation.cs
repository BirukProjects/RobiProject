using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class CategoryTranslation
    {
        public int CategoryTranslationId { get; set; }
        public string Languagecode { get; set; }
        public string Area { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public int CategoryId { get; set; }
    }
}
