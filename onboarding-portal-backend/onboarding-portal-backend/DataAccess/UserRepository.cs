using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext context;
        public UserRepository(UserDbContext userDbContext)
        {
            context = userDbContext;
        }


        public int CreateUser(User user)
        {
            context.Users.Add(user);
            return context.SaveChanges();
        }


        public Task<User> ValidateUser(User user)
        {
            return context.Users.Where(n => n.EmailId == user.EmailId && n.UserType == user.UserType).FirstOrDefaultAsync();
        }


        public async Task<bool> CheckNewUser(string userId,string password)
        {
            User user = context.Users.Where(n => n.UserId == userId && n.Password == null).FirstOrDefault();
            if (user != null)
            {
                user.Password = password;
                context.Entry<User>(user).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }


        public Task<List<User>> getUsers()
        {
            return context.Users.ToListAsync<User>();
                 
        }


        public async Task<User> LoginUser(User user)
        {
            User userReturnValue = await ValidateUser(user);
            if (user.EmailId == userReturnValue.EmailId && user.Password == userReturnValue.Password)
            {
                return userReturnValue;
            }
            else
            {
                return user;
            }
        }
        public async Task<bool> ResetPassword(User user)
        {
            User userReturnType=context.Users.Where(n =>n.Password == user.Password && n.EmailId==user.EmailId).FirstOrDefault();
            if (userReturnType != null)
            {
                userReturnType.Password = user.NewPassword;
                context.Entry<User>(userReturnType).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
