using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDirectory.Data.Repository;

namespace WebDirectory.Services
{
   

    public class CategoryAreaService:ICategoryAreaService
   {
       private readonly  IUnitOfWork _unitOfWork;
      

       public CategoryAreaService(IUnitOfWork unitOfWork)
       {
           this._unitOfWork = unitOfWork;
       }
       #region Default Service Implementation
       public bool AddCategoryArea(CategoryArea categoyArea)
       {
           _unitOfWork.CategoryAreaRepository.Add(categoyArea);
           _unitOfWork.Save();
           return true;
           
       }
       public bool EditCategoryArea(CategoryArea categoyArea)
       {
           _unitOfWork.CategoryAreaRepository.Edit(categoyArea);
           _unitOfWork.Save();
           return true;

       }
         public bool DeleteCategoryArea(CategoryArea categoyArea)
        {
             if(categoyArea==null) return false;
           _unitOfWork.CategoryAreaRepository.Delete(categoyArea);
           _unitOfWork.Save();
           return true;
        }
       public  bool DeleteById(int id)
       {
           var entity = _unitOfWork.CategoryAreaRepository.FindById(id);
           if(entity==null) return false;
           _unitOfWork.CategoryAreaRepository.Delete(entity);
           _unitOfWork.Save();
           return true;
       }
       public List<CategoryArea> GetAllCategoryArea()
       {
           return _unitOfWork.CategoryAreaRepository.GetAll();
       } 
       public CategoryArea FindById(int id)
       {
           return _unitOfWork.CategoryAreaRepository.FindById(id);
       }
       
       #endregion
       
       public void Dispose()
       {
           _unitOfWork.Dispose();
           
       }
       
   }
   }
   
         
      