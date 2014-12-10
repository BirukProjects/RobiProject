using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class UserPreferencesKey
    {
        public int UserPreferencesKey1 { get; set; }
        public string KeyValueOverrided { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> PreferenceKeyId { get; set; }
        public virtual PreferencesKey PreferencesKey { get; set; }
        public virtual User User { get; set; }
    }
}
