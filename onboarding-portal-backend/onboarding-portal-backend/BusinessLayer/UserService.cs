using DataAccess;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserService:IUserService
    {
        private readonly IUserRepository repository;
        public UserService(IUserRepository userRepository)
        {
            repository = userRepository;
        }

        public User GetUserOnLogin(User user)
        {

            return null;
        }


        public Task<List<User>> GetUsers()
        {
            return repository.getUsers();
        }

        public async Task<bool> ValidateUser(User user)
        {
            var _user =await repository.ValidateUser(user);
            if (_user == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<User> LoginUser(User user)
        {
            var _user = await repository.LoginUser(user);
            if (_user.UserId != null)
            {
                return _user;
            }
            else
            {
                return user;
            }
        }

        public async Task<User> CreateUser(User user)
        {
            var _user = await repository.ValidateUser(user);

            if (_user == null)
            {
                repository.CreateUser(user);
                return user;
            }
            else
            {
                user.UserType = "Error";
                return user;
            }
        }
        public async Task<bool> CheckNewUser(string userId, string password)
        {
            bool returnedValue = await repository.CheckNewUser(userId, password);
            return returnedValue;
        }
        public async Task<bool> ResetPassword(User user)
        {
            if (await repository.ResetPassword(user))
                return true;
            else
                return false;
        }
    }
}
