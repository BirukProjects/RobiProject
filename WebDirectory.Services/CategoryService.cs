using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDirectory.Data.Repository;

namespace WebDirectory.Services
{
    

    public class CategoryService:ICategoryService
   {
       private readonly  IUnitOfWork _unitOfWork;
      

       public CategoryService(IUnitOfWork unitOfWork)
       {
           this._unitOfWork = unitOfWork;
       }
       #region Default Service Implementation
       public bool AddCategory(Category category)
       {
           _unitOfWork.CategoryRepository.Add(category);
           _unitOfWork.Save();
           return true;
           
       }
       public bool EditCategory(Category category)
       {
           _unitOfWork.CategoryRepository.Edit(category);
           _unitOfWork.Save();
           return true;

       }
         public bool DeleteCategory(Category category)
        {
             if(category==null) return false;
           _unitOfWork.CategoryRepository.Delete(category);
           _unitOfWork.Save();
           return true;
        }
       public  bool DeleteById(int id)
       {
           var entity = _unitOfWork.CategoryRepository.FindById(id);
           if(entity==null) return false;
           _unitOfWork.CategoryRepository.Delete(entity);
           _unitOfWork.Save();
           return true;
       }
       public List<Category> GetAllCategory()
       {
           return _unitOfWork.CategoryRepository.GetAll();
       } 
       public Category FindById(int id)
       {
           return _unitOfWork.CategoryRepository.FindById(id);
       }
     
       #endregion
       
       public void Dispose()
       {
           _unitOfWork.Dispose();
           
       }
       
   }
   }
   
         
      