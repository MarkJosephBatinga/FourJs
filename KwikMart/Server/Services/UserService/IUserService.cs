using KwikMart.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KwikMart.Server.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> AddUser(User newUser);

        Task<User> GetUser(LoginUser existingUser);
    }
}
