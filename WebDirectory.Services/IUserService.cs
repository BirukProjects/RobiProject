using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDirectory.Services
{
   public interface IUserService
    {
       bool AddUser(User user);
       bool EditUser(User user);
       User FindByID(int id);
       List<User> GetAllUsers();


    }
}
