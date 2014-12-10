using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDirectory.Data.Repository;

namespace WebDirectory.Services 
{
    public class CompanyCategoryService : ICompanyCategoryService
    {
        private IUnitOfWork _unitOfWork;

        public CompanyCategoryService(IUnitOfWork unitOfWork)
      {
          _unitOfWork = unitOfWork;

      }

        public bool AddCompanyCategory(CompanyCategory companyCategory)
        {
            _unitOfWork.CompanyCategoryRepository.Add(companyCategory);
            _unitOfWork.Save();
            return true;
        }

        public bool EditCompanyCategory(CompanyCategory companyCategory)
        {
            _unitOfWork.CompanyCategoryRepository.Edit(companyCategory);
            _unitOfWork.Save();
            return true;
        }

        public CompanyCategory FindByID(int id)
        {
            return _unitOfWork.CompanyCategoryRepository.FindById(id);
        }

        public List<CompanyCategory> GetAllCompanyCategorys()
        {
            return _unitOfWork.CompanyCategoryRepository.GetAll();
        }
    }
}
