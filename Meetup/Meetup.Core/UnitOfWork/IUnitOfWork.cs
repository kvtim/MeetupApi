using Meetup.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IMeetingRepository MeetingRepository { get; }
        IUserRepository UserRepository { get; }

        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
