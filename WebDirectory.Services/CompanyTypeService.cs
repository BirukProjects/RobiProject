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

    public class CompanyTypeService:ICompanyTypeService
   {
       private readonly  IUnitOfWork _unitOfWork;
      

       public CompanyTypeService(IUnitOfWork unitOfWork)
       {
           this._unitOfWork = unitOfWork;
       }
       #region Default Service Implementation
       public bool AddCompanyType(CompanyType companyType)
       {
           _unitOfWork.CompanyTypeRepository.Add(companyType);
           _unitOfWork.Save();
           return true;
           
       }
       public bool EditCompanyType(CompanyType companyType)
       {
           _unitOfWork.CompanyTypeRepository.Edit(companyType);
           _unitOfWork.Save();
           return true;

       }
         public bool DeleteCompanyType(CompanyType companyType)
        {
             if(companyType==null) return false;
           _unitOfWork.CompanyTypeRepository.Delete(companyType);
           _unitOfWork.Save();
           return true;
        }
       public  bool DeleteById(int id)
       {
           var entity = _unitOfWork.CompanyTypeRepository.FindById(id);
           if(entity==null) return false;
           _unitOfWork.CompanyTypeRepository.Delete(entity);
           _unitOfWork.Save();
           return true;
       }
       public List<CompanyType> GetAllCompanyType()
       {
           return _unitOfWork.CompanyTypeRepository.GetAll();
       } 
       public CompanyType FindById(int id)
       {
           return _unitOfWork.CompanyTypeRepository.FindById(id);
       }
     
       #endregion
       
       public void Dispose()
       {
           _unitOfWork.Dispose();
           
       }
       
   }
   }
   
         
      