using Meetup.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Core.Services
{
    public interface IJWTTokenService
    {
        JWTToken Authenticate(string userName, string password);
    }
}
