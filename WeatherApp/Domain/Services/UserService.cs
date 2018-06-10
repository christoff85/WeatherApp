using System;
using WeatherApp.Domain.Abstractions.Data;
using WeatherApp.Domain.Abstractions.Services;
using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public User LoginUser(string userName, string password)
        {
            return _repository.GetSingleOrDefault(userName, password);
        }

        public User CreateUser(string userName, string password)
        {
            if (_repository.UserNameExists(userName))
                return null;

            _repository.CreateUser(userName, password);
            _unitOfWork.SaveChanges();

            return _repository.GetUserByUserName(userName);
        }
    }
}