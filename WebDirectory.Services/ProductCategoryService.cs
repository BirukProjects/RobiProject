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


    public class ProductCategoryService:IProductCategoryService
   {
       private readonly  IUnitOfWork _unitOfWork;
      

       public ProductCategoryService(IUnitOfWork unitOfWork)
       {
           this._unitOfWork = unitOfWork;
       }
       #region Default Service Implementation
       public bool AddProductCategory(ProductCategory productCategory)
       {
           _unitOfWork.ProductCategoryRepository.Add(productCategory);
           _unitOfWork.Save();
           return true;
           
       }
       public bool EditProductCategory(ProductCategory productCategory)
       {
           _unitOfWork.ProductCategoryRepository.Edit(productCategory);
           _unitOfWork.Save();
           return true;

       }
         public bool DeleteProductCategory(ProductCategory productCategory)
        {
             if(productCategory==null) return false;
           _unitOfWork.ProductCategoryRepository.Delete(productCategory);
           _unitOfWork.Save();
           return true;
        }
       public  bool DeleteById(int id)
       {
           var entity = _unitOfWork.ProductCategoryRepository.FindById(id);
           if(entity==null) return false;
           _unitOfWork.ProductCategoryRepository.Delete(entity);
           _unitOfWork.Save();
           return true;
       }
       public List<ProductCategory> GetAllProductCategory()
       {
           return _unitOfWork.ProductCategoryRepository.GetAll();
       } 
       public ProductCategory FindById(int id)
       {
           return _unitOfWork.ProductCategoryRepository.FindById(id);
       }
      
       #endregion
       
       public void Dispose()
       {
           _unitOfWork.Dispose();
           
       }
       
   }
   }
   
         
      