using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class CompanyRole
    {
        public CompanyRole()
        {
            this.CompanyMembers = new List<CompanyMember>();
        }

        public int CompanyRoleId { get; set; }
        public string CompanyRoleName { get; set; }
        public string CompanyRoleDescription { get; set; }
        public Nullable<bool> Approved { get; set; }
        public virtual ICollection<CompanyMember> CompanyMembers { get; set; }
    }
}
