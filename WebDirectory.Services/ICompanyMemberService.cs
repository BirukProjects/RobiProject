using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDirectory.Services
{
   public  interface ICompanyMemberService
   {
       
       bool AddCompanyMember(CompanyMember companyMember);
       bool DeleteCompanyMember(CompanyMember companyMember);
       bool DeleteById(int id);
       bool EditCompanyMember(CompanyMember companyMember);
       CompanyMember FindById(int id);
       List<CompanyMember> GetAllCompanyMember();
     


   }
}

          
      