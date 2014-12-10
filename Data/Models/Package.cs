using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Package
    {
        public Package()
        {
            this.Users = new List<User>();
        }

        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public Nullable<decimal> PackageValue { get; set; }
        public Nullable<bool> PackageShowOnline { get; set; }
        public string PackageCode { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
