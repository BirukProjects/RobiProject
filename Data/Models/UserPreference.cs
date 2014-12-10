using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class UserPreference
    {
        public int UserPreferenceId { get; set; }
        public int UserId { get; set; }
        public string MainCountryCode { get; set; }
        public string SecondCountryCode { get; set; }
        public string ThirdCountryCode { get; set; }
        public virtual User User { get; set; }
    }
}
