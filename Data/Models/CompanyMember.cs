using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class CompanyMember
    {
        public int CompanyMemberId { get; set; }
        public Nullable<int> CompanyRoleId { get; set; }
        public string Name { get; set; }
        public string UrlProfile { get; set; }
        public string PublicEmail { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual CompanyRole CompanyRole { get; set; }
    }
}
