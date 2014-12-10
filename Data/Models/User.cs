using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class User
    {
        public User()
        {
            this.Companies = new List<Company>();
            this.Companies1 = new List<Company>();
            this.UserPreferences = new List<UserPreference>();
            this.UserPreferencesKeys = new List<UserPreferencesKey>();
        }

        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string ContactName { get; set; }
        public int PackageId { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Company> Companies1 { get; set; }
        public virtual Package Package { get; set; }
        public virtual ICollection<UserPreference> UserPreferences { get; set; }
        public virtual ICollection<UserPreferencesKey> UserPreferencesKeys { get; set; }
    }
}
