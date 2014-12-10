using System;
using System.Collections.Generic;
using Data.Models;

namespace WebDirectory.Data.Repository
{
    /// <summary>
    /// UnitOfWork class to manage persistence and retrival of modles associated with
    /// the security module
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Company> CompanyRepository { get; }
        IGenericRepository<CompanyCategory> CompanyCategoryRepository { get; }
        IGenericRepository<Package> PackageRepository { get; }
        IGenericRepository<UserPreference> UserPreferenceRepository { get; }
        IGenericRepository<CompanyMember> CompanyMemberRepository { get; }
        IGenericRepository<CompanyPortfolio> CompanyPortfolioRepository { get; }

        IGenericRepository<CompanyProductService> CompanyProductServiceRepository { get; }
        IGenericRepository<CompanyTranslation> CompanyTranslationRepository { get; }

        IGenericRepository<CompanyType> CompanyTypeRepository { get; }

        IGenericRepository<CategoryArea> CategoryAreaRepository { get; }

        IGenericRepository<Category> CategoryRepository { get; }

        IGenericRepository<ProductCategory> ProductCategoryRepository { get; }

        IGenericRepository<AspNetUser> AspNetUserRepository { get; }
        void Save();
    }
}
