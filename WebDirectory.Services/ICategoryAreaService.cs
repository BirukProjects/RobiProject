using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDirectory.Services
{
   public  interface ICategoryAreaService
   {

       bool AddCategoryArea(CategoryArea categoryArea);
       bool DeleteCategoryArea(CategoryArea categoryArea);
       bool DeleteById(int id);
       bool EditCategoryArea(CategoryArea categoryArea);
       CategoryArea FindById(int id);
       List<CategoryArea> GetAllCategoryArea();
     


   }
}

          
      