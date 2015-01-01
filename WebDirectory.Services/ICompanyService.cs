using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDirectory.Services
{
    public interface ICompanyService 
    {
        bool AddCompany(Company company);
        bool EditCompany(Company company);
        bool DeleteCompany(Company company);

        bool DeleteById(int id);
       
        Company FindByID(int id);
        List<Company> GetAllCompanys();
    }
}
