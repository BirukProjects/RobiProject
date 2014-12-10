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


    public class PackageService:IPackageService
   {
       private readonly  IUnitOfWork _unitOfWork;
      

       public PackageService(IUnitOfWork unitOfWork)
       {
           this._unitOfWork = unitOfWork;
       }
      
       public bool AddPackage(Package package)
       {
           _unitOfWork.PackageRepository.Add(package);
           _unitOfWork.Save();
           return true;
           
       }
       public bool EditPackage(Package package)
       {
           _unitOfWork.PackageRepository.Edit(package);
           _unitOfWork.Save();
           return true;

       }
         public bool DeletePackage(Package package)
        {
             if(package==null) return false;
           _unitOfWork.PackageRepository.Delete(package);
           _unitOfWork.Save();
           return true;
        }
       public  bool DeleteById(int id)
       {
           var entity = _unitOfWork.PackageRepository.FindById(id);
           if(entity==null) return false;
           _unitOfWork.PackageRepository.Delete(entity);
           _unitOfWork.Save();
           return true;
       }
       public List<Package> GetAllPackage()
       {
           return _unitOfWork.PackageRepository.GetAll();
       } 
       public Package FindById(int id)
       {
           return _unitOfWork.PackageRepository.FindById(id);
       }
     
       
       public void Dispose()
       {
           _unitOfWork.Dispose();
           
       }
       
   }
   }
   
         
      