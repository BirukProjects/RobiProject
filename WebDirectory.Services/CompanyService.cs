using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDirectory.Data.Repository;

namespace WebDirectory.Services 
{
    public class CompanyService : ICompanyService
    {
        private IUnitOfWork _unitOfWork;

        public CompanyService(IUnitOfWork unitOfWork)
      {
          _unitOfWork = unitOfWork;

      }

        public bool AddCompany(Company company)
        {
            _unitOfWork.CompanyRepository.Add(company);
            _unitOfWork.Save();
            return true;
        }

        public bool EditCompany(Company company)
        {
            _unitOfWork.CompanyRepository.Edit(company);
            _unitOfWork.Save();
            return true;
        }

        public Company FindByID(int id)
        {
            return _unitOfWork.CompanyRepository.FindById(id);
        }

        public List<Company> GetAllCompanys()
        {
            return _unitOfWork.CompanyRepository.GetAll();
        }
        public bool DeleteCompany(Company company)
        {
            if (company == null) 
            _unitOfWork.CompanyRepository.Delete(company);
            _unitOfWork.Save();
            return true;
        }
        public bool DeleteById(int id)
        {
            var entity = _unitOfWork.CompanyRepository.FindById(id);
            if (entity == null) return false;
            _unitOfWork.CompanyRepository.Delete(entity);
            _unitOfWork.Save();
            return true;
        }
    }
}
