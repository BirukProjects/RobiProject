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
  public  class UserService:IUserService
    {

      private IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
      {
          _unitOfWork = unitOfWork;

      }
        public bool AddUser(User user)
        {
            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Save();
            return true;
        }

        public bool EditUser(User user)
        {
            _unitOfWork.UserRepository.Edit(user);
            _unitOfWork.Save();
            return true;
        }

        public User FindByID(int id)
        {
            return _unitOfWork.UserRepository.FindById(id);
        }

        public List<User> GetAllUsers()
        {
            return _unitOfWork.UserRepository.GetAll();
        }
    }
}
