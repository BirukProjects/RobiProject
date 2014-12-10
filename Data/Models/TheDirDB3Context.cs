using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Data.Models.Mapping;

namespace Data.Models
{
    public partial class TheDirDB3Context : DbContext
    {
        static TheDirDB3Context()
        {
            Database.SetInitializer<TheDirDB3Context>(null);
        }

        public TheDirDB3Context()
            : base("Name=DefaultConnection")
        {
        }

        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryArea> CategoryAreas { get; set; }
        public DbSet<CategoryAreaTranslation> CategoryAreaTranslations { get; set; }
        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompaniesCategory> CompaniesCategories { get; set; }
        public DbSet<CompanyCategory> CompanyCategories { get; set; }
        public DbSet<CompanyMember> CompanyMembers { get; set; }
        public DbSet<CompanyPortfolio> CompanyPortfolios { get; set; }
        public DbSet<CompanyProductService> CompanyProductServices { get; set; }
        public DbSet<CompanyRole> CompanyRoles { get; set; }
        public DbSet<CompanyTranslation> CompanyTranslations { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<MapArea> MapAreas { get; set; }
        public DbSet<MapCity> MapCities { get; set; }
        public DbSet<MapCountry> MapCountries { get; set; }
        public DbSet<MapStateOrProvince> MapStateOrProvinces { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PreferencesKey> PreferencesKeys { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<UserPreference> UserPreferences { get; set; }
        public DbSet<UserPreferencesKey> UserPreferencesKeys { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new AspNetUserMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CategoryAreaMap());
            modelBuilder.Configurations.Add(new CategoryAreaTranslationMap());
            modelBuilder.Configurations.Add(new CategoryTranslationMap());
            modelBuilder.Configurations.Add(new CompanyMap());
            modelBuilder.Configurations.Add(new CompaniesCategoryMap());
            modelBuilder.Configurations.Add(new CompanyCategoryMap());
            modelBuilder.Configurations.Add(new CompanyMemberMap());
            modelBuilder.Configurations.Add(new CompanyPortfolioMap());
            modelBuilder.Configurations.Add(new CompanyProductServiceMap());
            modelBuilder.Configurations.Add(new CompanyRoleMap());
            modelBuilder.Configurations.Add(new CompanyTranslationMap());
            modelBuilder.Configurations.Add(new CompanyTypeMap());
            modelBuilder.Configurations.Add(new MapAreaMap());
            modelBuilder.Configurations.Add(new MapCityMap());
            modelBuilder.Configurations.Add(new MapCountryMap());
            modelBuilder.Configurations.Add(new MapStateOrProvinceMap());
            modelBuilder.Configurations.Add(new PackageMap());
            modelBuilder.Configurations.Add(new PreferencesKeyMap());
            modelBuilder.Configurations.Add(new ProductCategoryMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new UserPreferenceMap());
            modelBuilder.Configurations.Add(new UserPreferencesKeyMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
