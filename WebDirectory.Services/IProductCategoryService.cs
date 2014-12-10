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
  
   public  interface IProductCategoryService
   {
       
       bool AddProductCategory(ProductCategory productCategory);
       bool DeleteProductCategory(ProductCategory productCategory);
       bool DeleteById(int id);
       bool EditProductCategory(ProductCategory productCategory);
       ProductCategory FindById(int id);
       List<ProductCategory> GetAllProductCategory();
      


   }
}

          
      