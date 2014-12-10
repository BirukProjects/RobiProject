using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDirectory.Data.Repository;
using Data.Models;

namespace Web.Directory.Repository
{
    /// <summary>
    /// The Entity Framework implementation of IUnitOfWork
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        
            private readonly TheDirDB3Context _context;
            public UnitOfWork()
            {
                this._context = new TheDirDB3Context();
            }

            // TODO: Add private properties to for each repository

            private IGenericRepository<User> userRepository;
            private IGenericRepository<UserPreference> userPreferenceRepository;
            private IGenericRepository<Package> packageRepository;
            private IGenericRepository<Company> companyRepository;
            private IGenericRepository<CompanyCategory> companyCategoryRepository;

            private IGenericRepository<CompanyMember> companyMemberRepository;
            private IGenericRepository<CompanyPortfolio> companyPortfolioRepository;
            private IGenericRepository<CompanyProductService> companyProductServiceRepository;
            private IGenericRepository<CompanyTranslation> companyTranslationRepository;
            private IGenericRepository<CompanyType> companyTypeRepository;
            private IGenericRepository<CategoryArea> categoryAreaRepository;
            private IGenericRepository<Category> categoryRepository;
            private IGenericRepository<ProductCategory> productCategoryRepository;
            private IGenericRepository<AspNetUser> aspNetUserRepository;
        
            public IGenericRepository<CompanyType> CompanyTypeRepository
            {
                get
                {
                    return this.companyTypeRepository ?? (this.companyTypeRepository = new GenericRepository<CompanyType>(_context));
                }
            }
            public IGenericRepository<AspNetUser> AspNetUserRepository
            {
                get
                {
                    return this.aspNetUserRepository ?? (this.aspNetUserRepository = new GenericRepository<AspNetUser>(_context));
                }
            }
            public IGenericRepository<ProductCategory> ProductCategoryRepository
            {
                get
                {
                    return this.productCategoryRepository ?? (this.productCategoryRepository = new GenericRepository<ProductCategory>(_context));
                }
            }
           public IGenericRepository<Category>  CategoryRepository
            {
                get
                {
                    return this.categoryRepository ?? (this.categoryRepository = new GenericRepository<Category>(_context));
                }
            }
           public IGenericRepository<CategoryArea> CategoryAreaRepository
           {
               get
               {
                   return this.categoryAreaRepository ?? (this.categoryAreaRepository = new GenericRepository<CategoryArea>(_context));
               }
           }
            public IGenericRepository<CompanyTranslation> CompanyTranslationRepository
            {
                get
                {
                    return this.companyTranslationRepository ?? (this.companyTranslationRepository = new GenericRepository<CompanyTranslation>(_context));
                }
            }
            public IGenericRepository<CompanyProductService> CompanyProductServiceRepository
            {
                get
                {
                    return this.companyProductServiceRepository ?? (this.companyProductServiceRepository = new GenericRepository<CompanyProductService>(_context));
                }
            }
            public IGenericRepository<CompanyPortfolio> CompanyPortfolioRepository
            {
                get
                {
                    return this.companyPortfolioRepository ?? (this.companyPortfolioRepository = new GenericRepository<CompanyPortfolio>(_context));
                }
            }
        public IGenericRepository<CompanyMember> CompanyMemberRepository
            {
                get
                {
                    return this.companyMemberRepository ?? (this.companyMemberRepository = new GenericRepository<CompanyMember>(_context));
                }
            }
        
        public IGenericRepository<Company> CompanyRepository
            {
                get
                {
                    return this.companyRepository ?? (this.companyRepository = new GenericRepository<Company>(_context));
                }
            }
            public IGenericRepository<CompanyCategory> CompanyCategoryRepository
            {
                get
                {
                    return this.companyCategoryRepository ?? (this.companyCategoryRepository = new GenericRepository<CompanyCategory>(_context));
                }
            }
            public IGenericRepository<User> UserRepository
            {
                get
                {
                    return this.userRepository ?? (this.userRepository = new GenericRepository<User>(_context));
                }
            }
            public IGenericRepository<Package> PackageRepository
            {
                get { return this.packageRepository ?? (this.packageRepository = new GenericRepository<Package>(_context)); }
            }
            public IGenericRepository<UserPreference> UserPreferenceRepository
            {
                get { return this.userPreferenceRepository ?? (this.userPreferenceRepository = new GenericRepository<UserPreference>(_context)); }
            }
            public void Save()
            {
                try
                {
                    _context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException e)
                {
                    throw e;
                }
            }

            private bool disposed = false;

            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        _context.Dispose();
                    }
                }
                this.disposed = true;
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }


    }
    
}
