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
   public  interface ICompanyProductServiceService
   {
       
       bool AddCompanyProductService(CompanyProductService companyProductService);
       bool DeleteCompanyProductService(CompanyProductService companyProductService);
       bool DeleteById(int id);
       bool EditCompanyProductService(CompanyProductService companyProductService);
       CompanyProductService FindById(int id);
       List<CompanyProductService> GetAllCompanyProductService();
     


   }
}

          
      