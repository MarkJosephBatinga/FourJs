using KwikMart.Server.Data;
using KwikMart.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KwikMart.Server.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _data;
        List<User> Users = new List<User>();

        public UserService(DataContext data)
        {
            _data = data;
        }
        public async Task<List<User>> AddUser(User newUser)
        {
            await _data.Users.AddAsync(newUser);
            await _data.SaveChangesAsync();
            Users = await _data.Users.ToListAsync();
            return Users;
        }

        public async Task<User> GetUser(LoginUser existingUser)
        {
            User dbuser = await _data.Users.FirstOrDefaultAsync(u => u.EmailAddress == existingUser.EmailAddress && u.Password == existingUser.Password);
            var dbnotfound = new User();
            if (dbuser == null)
                return dbnotfound;
            return dbuser;
        }
    }
}
