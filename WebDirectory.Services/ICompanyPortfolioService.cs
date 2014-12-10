using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDirectory.Data.Repository;
using WebDirectory.Data;
using Data.Models;
namespace WebDirectory.Services
{
   public  interface ICompanyPortfolioService
   {
       
       bool AddCompanyPortfolio(CompanyPortfolio companyProtfolio);
       bool DeleteCompanyPortfolio(CompanyPortfolio companyProtfolio);
       bool DeleteById(int id);
       bool EditCompanyPortfolio(CompanyPortfolio companyProtfolio);
       CompanyPortfolio FindById(int id);
       List<CompanyPortfolio> GetAllCompanyPortfolio();
     


   }
}

          
      