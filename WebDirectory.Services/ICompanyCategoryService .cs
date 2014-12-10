using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDirectory.Services
{
    public interface ICompanyCategoryService 
    {
        bool AddCompanyCategory(CompanyCategory companyCategory);
        bool EditCompanyCategory(CompanyCategory companyCategory);
        CompanyCategory FindByID(int id);
        List<CompanyCategory> GetAllCompanyCategorys();
    }
}
