using Meetup.Domain.Models;
using Meetup.Domain.Repositories;
using Meetup.Domain.Services;
using Meetup.Domain.UnitOfWork;

namespace Meetup.Api.Services
{
    public class MeetingService : IMeetingService
    {
        public readonly IUnitOfWork _unitOfWork;

        public MeetingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Meeting entity)
        {
            _unitOfWork.MeetingRepository.AddAsync(entity);

            await _unitOfWork.CommitAsync();
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
            _unitOfWork.MeetingRepository.RemoveAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Meeting entity)
        {
            _unitOfWork.MeetingRepository.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
