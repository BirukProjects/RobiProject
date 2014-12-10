using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Company
    {
        public Company()
        {
            this.CompaniesCategories = new List<CompaniesCategory>();
            this.CompanyCategories = new List<CompanyCategory>();
            this.CompanyMembers = new List<CompanyMember>();
            this.CompanyPortfolios = new List<CompanyPortfolio>();
            this.CompanyProductServices = new List<CompanyProductService>();
            this.CompanyTranslations = new List<CompanyTranslation>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyWebsite { get; set; }
        public string CompanyEmail1 { get; set; }
        public string CompanyEmail2 { get; set; }
        public string CompanyTelephone { get; set; }
        public Nullable<int> CompanyTypeId { get; set; }
        public int UserOwnerId { get; set; }
        public int UserCreatorId { get; set; }
        public string CompanyLogoPath { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> LastUpdateDate { get; set; }
        public Nullable<System.DateTime> CompanyFoundedDate { get; set; }
        public string turnover { get; set; }
        public string numberOfEmployees { get; set; }
        public string companydescription { get; set; }
        public virtual CompanyType CompanyType { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual ICollection<CompaniesCategory> CompaniesCategories { get; set; }
        public virtual ICollection<CompanyCategory> CompanyCategories { get; set; }
        public virtual ICollection<CompanyMember> CompanyMembers { get; set; }
        public virtual ICollection<CompanyPortfolio> CompanyPortfolios { get; set; }
        public virtual ICollection<CompanyProductService> CompanyProductServices { get; set; }
        public virtual ICollection<CompanyTranslation> CompanyTranslations { get; set; }
    }
}
