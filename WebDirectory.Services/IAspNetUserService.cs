using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebDirectory.Services
{
   
   public  interface IAspNetUserService
   {
       
       bool AddAspNetUser(AspNetUser aspNetUser);
       bool DeleteAspNetUser(AspNetUser aspNetUser);
       bool DeleteById(int id);
       bool EditAspNetUser(AspNetUser aspNetUser);
       AspNetUser FindById(int id);
       List<AspNetUser> GetAllAspNetUser();
      


   }
}

          
      