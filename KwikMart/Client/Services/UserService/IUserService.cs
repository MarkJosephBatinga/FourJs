using KwikMart.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KwikMart.Client.Services.UserService
{
    interface IUserService
    {

        Task<User> GetUser(string username);
        Task<List<User>> RegisterUser(User newUser);
        Task<User> LoginUser(LoginUser existingUser);
        Task<User> UpdateUser(User existingUser);
        Task<List<User>> DeleteUser(int Id);

    }
}
