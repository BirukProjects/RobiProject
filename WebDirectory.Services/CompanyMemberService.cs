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

    public class CompanyMemberService:ICompanyMemberService
   {
       private readonly  IUnitOfWork _unitOfWork;
      

       public CompanyMemberService(IUnitOfWork unitOfWork)
       {
           this._unitOfWork = unitOfWork;
       }
       #region Default Service Implementation
       public bool AddCompanyMember(CompanyMember companyMember)
       {
           _unitOfWork.CompanyMemberRepository.Add(companyMember);
           _unitOfWork.Save();
           return true;
           
       }
       public bool EditCompanyMember(CompanyMember companyMember)
       {
           _unitOfWork.CompanyMemberRepository.Edit(companyMember);
           _unitOfWork.Save();
           return true;

       }
         public bool DeleteCompanyMember(CompanyMember companyMember)
        {
             if(companyMember==null) return false;
           _unitOfWork.CompanyMemberRepository.Delete(companyMember);
           _unitOfWork.Save();
           return true;
        }
       public  bool DeleteById(int id)
       {
           var entity = _unitOfWork.CompanyMemberRepository.FindById(id);
           if(entity==null) return false;
           _unitOfWork.CompanyMemberRepository.Delete(entity);
           _unitOfWork.Save();
           return true;
       }
       public List<CompanyMember> GetAllCompanyMember()
       {
           return _unitOfWork.CompanyMemberRepository.GetAll();
       } 
       public CompanyMember FindById(int id)
       {
           return _unitOfWork.CompanyMemberRepository.FindById(id);
       }
      
       #endregion
       
       public void Dispose()
       {
           _unitOfWork.Dispose();
           
       }
       
   }
   }
   
         
      