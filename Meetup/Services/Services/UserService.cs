using Meetup.Core.Models;
using Meetup.Core.Services;
using Meetup.Core.UnitOfWork;
using Meetup.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Security.Cryptography;

namespace Meetup.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _unitOfWork.UserRepository.GetByUserNameAsync(userName);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _unitOfWork.UserRepository.GetAllWithMeetingsAsync();
        }

        public async Task<IEnumerable<Meeting>> GetUserMeetings(string userName)
        {
            return await _unitOfWork.UserRepository.GetUserMeetingsAsync(userName);
        }

        public async Task<Meeting> BecomeMember(int meetingId, string userName)
        {
            var meeting = await _unitOfWork.UserRepository.BecomeMemberAsync(meetingId, userName);

            await _unitOfWork.CommitAsync();

            return meeting;
        }

        public async Task<User> RefuseToMeeting(int meetingId, string userName)
        {
            var user = await _unitOfWork.UserRepository.RefuseToMeetingAsync(meetingId, userName);

            await _unitOfWork.CommitAsync();

            return user;
        }

        public async Task<User> AddAsync(User user)
        {
            user = await _unitOfWork.UserRepository.CheckedAddAsync(user);
            await _unitOfWork.CommitAsync();

            return user;
        }
    }
}
