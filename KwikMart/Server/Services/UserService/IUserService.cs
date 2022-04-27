using KwikMart.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KwikMart.Server.Services.UserService
{
    public interface IUserService
    {
        Task<User> GetLogUser(string username);

        Task<List<User>> AddUser(User newUser);
        Task<User> GetUser(LoginUser existingUser);
        Task<User> UpdateUSer(User existingUser);
        Task<List<User>> RemoveUser(int userId);
    }
}
