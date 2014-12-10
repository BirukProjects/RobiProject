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
   

    public class CompanyProductServiceService:ICompanyProductServiceService
   {
       private readonly  IUnitOfWork _unitOfWork;
      

       public CompanyProductServiceService(IUnitOfWork unitOfWork)
       {
           this._unitOfWork = unitOfWork;
       }
       #region Default Service Implementation
       public bool AddCompanyProductService(CompanyProductService companyProductService)
       {
           _unitOfWork.CompanyProductServiceRepository.Add(companyProductService);
           _unitOfWork.Save();
           return true;
           
       }
       public bool EditCompanyProductService(CompanyProductService companyProductService)
       {
           _unitOfWork.CompanyProductServiceRepository.Edit(companyProductService);
           _unitOfWork.Save();
           return true;

       }
         public bool DeleteCompanyProductService(CompanyProductService companyProductService)
        {
             if(companyProductService==null) return false;
           _unitOfWork.CompanyProductServiceRepository.Delete(companyProductService);
           _unitOfWork.Save();
           return true;
        }
       public  bool DeleteById(int id)
       {
           var entity = _unitOfWork.CompanyProductServiceRepository.FindById(id);
           if(entity==null) return false;
           _unitOfWork.CompanyProductServiceRepository.Delete(entity);
           _unitOfWork.Save();
           return true;
       }
       public List<CompanyProductService> GetAllCompanyProductService()
       {
           return _unitOfWork.CompanyProductServiceRepository.GetAll();
       } 
       public CompanyProductService FindById(int id)
       {
           return _unitOfWork.CompanyProductServiceRepository.FindById(id);
       }
      
       #endregion
       
       public void Dispose()
       {
           _unitOfWork.Dispose();
           
       }
       
   }
   }
   
         
      