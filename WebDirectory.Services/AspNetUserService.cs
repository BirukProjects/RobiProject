using System;
using Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDirectory.Data.Repository;
using System.Security.Cryptography;

namespace WebDirectory.Services
{

    public class AspNetUserService : IAspNetUserService
    {
        private readonly IUnitOfWork _unitOfWork;


        public AspNetUserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        #region Default Service Implementation
        public bool AddAspNetUser(AspNetUser aspNetUser)
        {
            _unitOfWork.AspNetUserRepository.Add(aspNetUser);
            _unitOfWork.Save();
            return true;

        }
        public bool EditAspNetUser(AspNetUser aspNetUser)
        {
            _unitOfWork.AspNetUserRepository.Edit(aspNetUser);
            _unitOfWork.Save();
            return true;

        }
        public bool DeleteAspNetUser(AspNetUser aspNetUser)
        {
            if (aspNetUser == null) return false;
            _unitOfWork.AspNetUserRepository.Delete(aspNetUser);
            _unitOfWork.Save();
            return true;
        }
        public bool DeleteById(int id)
        {
            var entity = _unitOfWork.AspNetUserRepository.FindById(id);
            if (entity == null) return false;
            _unitOfWork.AspNetUserRepository.Delete(entity);
            _unitOfWork.Save();
            return true;
        }
        public List<AspNetUser> GetAllAspNetUser()
        {
            return _unitOfWork.AspNetUserRepository.GetAll();
        }
        public AspNetUser FindById(int id)
        {
            return _unitOfWork.AspNetUserRepository.FindById(id);
        }
        public AspNetUser FindById(string id)
        {
            return _unitOfWork.AspNetUserRepository.FindById(id);
        }

        #endregion

        public void Dispose()
        {
            _unitOfWork.Dispose();

        }
        public string HashPassword(string password)
        {
            Byte[] passwordBytes = Encoding.Unicode.GetBytes(password);
            SHA256Managed hashProvider = new SHA256Managed();
            hashProvider.Initialize();
            passwordBytes = hashProvider.ComputeHash(passwordBytes);
            hashProvider.Clear();
            return Convert.ToBase64String(passwordBytes);
        }
    }
}


