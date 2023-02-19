using Meetup.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IMeetingRepository MeetingRepository { get; }
        IParticipantRepository ParticipantRepository { get; }

        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
