using DPA.SHOPPING.CORE.Core.Entities;
using DPA.SHOPPING.CORE.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DPA.SHOPPING.CORE.Core.Interfaces;

namespace DPA.SHOPPING.CORE.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDbContext _storeDbContext;
        public UserRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }

        public async Task<User?> SignIn(string email, string password)
        {

            return await _storeDbContext
                                .User
                                .Where(u => u.Email == email
                                        && u.Password == password
                                        && u.IsActive == true)
                               .FirstOrDefaultAsync();
        }

        public async Task<int> SignUp(User user)
        {
            _storeDbContext.User.Add(user);
            await _storeDbContext.SaveChangesAsync();
            return user.Id;
        }
    }
}
