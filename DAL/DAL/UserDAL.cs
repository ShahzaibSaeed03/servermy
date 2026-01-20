using DTO;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL : IUserDAL
    {
        private readonly MyCaDbContext _context;

        public UserDAL(MyCaDbContext context)
        {
            _context = context;
        }
        public async Task<TUser> AddUser(TUser user)
        {
            await _context.TUsers.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<TUser?> GetUserById(int userId)
        {
            return await _context.TUsers.FindAsync(userId);
        }

        public async Task<TUser?> GetUserByEmail(string email)
        {
            return await _context.TUsers.Where(user => user.Email == email).FirstOrDefaultAsync();
        }

        public async Task<TUser?> AddTokens(int userId, int number)
        {
            var user = await _context.TUsers.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
                throw new Exception("user not found");
            user.RemainingTokens += number;
            _context.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
