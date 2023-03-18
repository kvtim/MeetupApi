using Meetup.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Domain.Services
{
    public interface IUserService
    {
        Task<User> GetByUserNameAsync(string id);
        Task<IEnumerable<User>> GetAll();
        Task<User> AddAsync(User user);
    }
}
