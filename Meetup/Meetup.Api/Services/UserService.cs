using Meetup.Domain.Models;
using Meetup.Domain.Services;
using Meetup.Infascructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Security.Cryptography;

namespace Meetup.Api.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _context.Users.FirstAsync(u => u.UserName == userName);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> AddAsync(User user)
        {
            if (_context.Users.Any(e => e.UserName == user.UserName 
            && e.Password == user.Password))
            {
                return null;
            }

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
