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
   public  interface ICompanyTranslationService
   {
       
       bool AddCompanyTranslation(CompanyTranslation companyTranslation);
       bool DeleteCompanyTranslation(CompanyTranslation companyTranslation);
       bool DeleteById(int id);
       bool EditCompanyTranslation(CompanyTranslation companyTranslation);
       CompanyTranslation FindById(int id);
       List<CompanyTranslation> GetAllCompanyTranslation();
      


   }
}

          
      