using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDirectory.Data.Repository;

namespace WebDirectory.Services
{
  

 
   public  interface ICompaniesCategoryService
   {
       
       bool AddCompaniesCategory(CompaniesCategory CompaniesCategory);
       bool DeleteCompaniesCategory(CompaniesCategory CompaniesCategory);
       bool DeleteById(int id);
       bool EditCompaniesCategory(CompaniesCategory CompaniesCategory);
       CompaniesCategory FindById(int id);
       List<CompaniesCategory> GetAllCompaniesCategory();
       


   }
}

          
      