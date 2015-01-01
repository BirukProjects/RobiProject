using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDirectory.Data.Repository;

namespace WebDirectory.Services
{
   




    public class CompaniesCategoryService:ICompaniesCategoryService
   {
       private readonly  IUnitOfWork _unitOfWork;
      

       public CompaniesCategoryService(IUnitOfWork unitOfWork)
       {
           this._unitOfWork = unitOfWork;
       }
       #region Default Service Implementation
       public bool AddCompaniesCategory(CompaniesCategory entity)
       {
           _unitOfWork.CompaniesCategoryRepository.Add(entity);
           _unitOfWork.Save();
           return true;
           
       }
       public bool EditCompaniesCategory(CompaniesCategory entity)
       {
           _unitOfWork.CompaniesCategoryRepository.Edit(entity);
           _unitOfWork.Save();
           return true;

       }
         public bool DeleteCompaniesCategory(CompaniesCategory entity)
        {
             if(entity==null) return false;
           _unitOfWork.CompaniesCategoryRepository.Delete(entity);
           _unitOfWork.Save();
           return true;
        }
       public  bool DeleteById(int id)
       {
           var entity = _unitOfWork.CompaniesCategoryRepository.FindById(id);
           if(entity==null) return false;
           _unitOfWork.CompaniesCategoryRepository.Delete(entity);
           _unitOfWork.Save();
           return true;
       }
       public List<CompaniesCategory> GetAllCompaniesCategory()
       {
           return _unitOfWork.CompaniesCategoryRepository.GetAll();
       } 
       public CompaniesCategory FindById(int id)
       {
           return _unitOfWork.CompaniesCategoryRepository.FindById(id);
       }
      
       #endregion
       
       public void Dispose()
       {
           _unitOfWork.Dispose();
           
       }
       
   }
   }
   
         
      