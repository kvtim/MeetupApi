using Meetup.Core.Models;
using Meetup.Core.Repositories;
using Meetup.Core.Services;
using Meetup.Core.UnitOfWork;

namespace Meetup.Api.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MeetingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Meeting> AddAsync(Meeting entity)
        {
            await _unitOfWork.MeetingRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task<IEnumerable<Meeting>> GetAllAsync()
        {
            return await _unitOfWork.MeetingRepository.GetAllAsync();
        }

        public async Task<Meeting> GetByIdAsync(int id)
        {
            return await _unitOfWork.MeetingRepository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(Meeting entity)
        {
            await _unitOfWork.MeetingRepository.RemoveAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task<Meeting> UpdateAsync(Meeting entity)
        {
            await _unitOfWork.MeetingRepository.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();

            return entity;
        }
    }
}
