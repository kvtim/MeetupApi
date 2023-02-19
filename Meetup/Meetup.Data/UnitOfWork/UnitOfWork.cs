using Meetup.Domain.Repositories;
using Meetup.Domain.UnitOfWork;
using Meetup.Infascructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Infascructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IMeetingRepository _meetingRepository;
        private IParticipantRepository _participantRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IMeetingRepository MeetingRepository => _meetingRepository = 
            _meetingRepository ?? new MeetingRepository(_context);

        public IParticipantRepository ParticipantRepository => _participantRepository = 
            _participantRepository ?? new ParticipantRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            _context.Dispose();
        }

        public async Task RollbackAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
