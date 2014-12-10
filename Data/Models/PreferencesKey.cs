using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class PreferencesKey
    {
        public PreferencesKey()
        {
            this.UserPreferencesKeys = new List<UserPreferencesKey>();
        }

        public int PreferenceKeyId { get; set; }
        public string KeyName { get; set; }
        public string DefaultValue { get; set; }
        public virtual ICollection<UserPreferencesKey> UserPreferencesKeys { get; set; }
    }
}
