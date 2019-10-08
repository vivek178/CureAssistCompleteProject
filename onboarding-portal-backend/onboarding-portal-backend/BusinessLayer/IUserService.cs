using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BusinessLayer
{
   public interface IUserService
    {
        User GetUserOnLogin(User user);

        Task<List<User>> GetUsers();
        //string CreateUser(User user);
        Task<bool> ValidateUser(User user);

        Task<User> LoginUser(User user);

        Task<User> CreateUser(User user);
        Task<bool> CheckNewUser(string userId, string password);
        Task<bool> ResetPassword(User user);
    }
}
