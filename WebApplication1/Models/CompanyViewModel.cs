using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CompanyViewModel
    {

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyWebsite { get; set; }
        public string CompanyEmail1 { get; set; }
        public string CompanyEmail2 { get; set; }
        public string CompanyTelephone { get; set; }
        public string CompanyDescription { get; set; }
       
        public string UserOwnerName { get; set; }
      
        public string CompanyLogoPath { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> LastUpdateDate { get; set; }
        public Nullable<System.DateTime> CompanyFoundedDate { get; set; }
        public string turnover { get; set; }
        public string numberOfEmployees { get; set; }
        public string companydescription { get; set; }
        public string   CompanyType { get; set; }
     
    }
}