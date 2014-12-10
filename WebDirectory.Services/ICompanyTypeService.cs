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
  
   public  interface ICompanyTypeService
   {
       
       bool AddCompanyType(CompanyType companyType);
       bool DeleteCompanyType(CompanyType companyType);
       bool DeleteById(int id);
       bool EditCompanyType(CompanyType companyType);
       CompanyType FindById(int id);
       List<CompanyType> GetAllCompanyType();
      


   }
}

          
      