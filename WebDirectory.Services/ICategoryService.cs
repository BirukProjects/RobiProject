using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDirectory.Services
{
  
   public  interface ICategoryService
   {
       
       bool AddCategory(Category category);
       bool DeleteCategory(Category category);
       bool DeleteById(int id);
       bool EditCategory(Category category);
       Category FindById(int id);
       List<Category> GetAllCategory();
      


   }
}

          
      