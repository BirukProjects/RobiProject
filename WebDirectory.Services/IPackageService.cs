using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDirectory.Services
{
   public  interface IPackageService
   {
       
       bool AddPackage(Package package);
       bool DeletePackage(Package package);
       bool DeleteById(int id);
       bool EditPackage(Package package);
       Package FindById(int id);
       List<Package> GetAllPackage();
       


   }
}

          
      