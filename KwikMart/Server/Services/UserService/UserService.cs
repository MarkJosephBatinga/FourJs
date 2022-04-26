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
        User user = new User();

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

        public async Task<User> GetLogUser(string username)
        {
            return user = await _data.Users.Where(u => u.EmailAddress == username).FirstOrDefaultAsync();
        }

        public async Task<User> UpdateUSer(User existingUser)
        {
            var dbUser = await _data.Users.FindAsync(existingUser.Id);
            if (dbUser != null)
            {
                _data.Entry(dbUser).CurrentValues.SetValues(existingUser);
                await _data.SaveChangesAsync();
            }
            return dbUser;
        }

        public async Task<User> RemoveUser(int userId)
        {
            var user = await _data.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
            return user;
        }
    }
}
