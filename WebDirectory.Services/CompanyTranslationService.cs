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

  
    public class CompanyTranslationService:ICompanyTranslationService
   {
       private readonly  IUnitOfWork _unitOfWork;
      

       public CompanyTranslationService(IUnitOfWork unitOfWork)
       {
           this._unitOfWork = unitOfWork;
       }
      
       public bool AddCompanyTranslation(CompanyTranslation companyTranslation)
       {
           _unitOfWork.CompanyTranslationRepository.Add(companyTranslation);
           _unitOfWork.Save();
           return true;
           
       }
       public bool EditCompanyTranslation(CompanyTranslation companyTranslation)
       {
           _unitOfWork.CompanyTranslationRepository.Edit(companyTranslation);
           _unitOfWork.Save();
           return true;

       }
         public bool DeleteCompanyTranslation(CompanyTranslation companyTranslation)
        {
             if(companyTranslation==null) return false;
           _unitOfWork.CompanyTranslationRepository.Delete(companyTranslation);
           _unitOfWork.Save();
           return true;
        }
       public  bool DeleteById(int id)
       {
           var entity = _unitOfWork.CompanyTranslationRepository.FindById(id);
           if(entity==null) return false;
           _unitOfWork.CompanyTranslationRepository.Delete(entity);
           _unitOfWork.Save();
           return true;
       }
       public List<CompanyTranslation> GetAllCompanyTranslation()
       {
           return _unitOfWork.CompanyTranslationRepository.GetAll();
       } 
       public CompanyTranslation FindById(int id)
       {
           return _unitOfWork.CompanyTranslationRepository.FindById(id);
       }
       
       
       public void Dispose()
       {
           _unitOfWork.Dispose();
           
       }
       
   }
   }
   
         
       