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
        Company FindByID(int id);
        List<Company> GetAllCompanys();
    }
}
