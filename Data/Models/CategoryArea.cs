using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class CategoryArea
    {
        public int CategoryAreaId { get; set; }
        public string CategoryName { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<bool> Approved { get; set; }
        public string IconPath { get; set; }
        public virtual Category Category { get; set; }
    }
    public partial class CategoryArea1
    {
        public int CategoryAreaId { get; set; }
        public string CategoryName { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<bool> Approved { get; set; }
        public string IconPath { get; set; }
        public virtual Category Category { get; set; }
    }
}
