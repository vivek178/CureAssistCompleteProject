using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public interface IUserRepository
    {
        Task<List<User>> getUsers();
        Task<User> ValidateUser(User user);
        int CreateUser(User user);
        Task<User> LoginUser(User user);
        Task<bool> CheckNewUser(string userId, string password);
        Task<bool> ResetPassword(User user);
    }
}
