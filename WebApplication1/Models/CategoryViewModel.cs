using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        public string Area { get; set; }
        public string Category1 { get; set; }
        public string Subcategory { get; set; }
    }

    public class CategoryTreeVeiw
    {
        public int CategoryID { get; set; }
     
        public string CategoryName { get; set; }

        public int CategoryAreaId { get; set; }
        public string CategoryAreaName { get; set; }
        public string IconPath { get; set; }
    }
}