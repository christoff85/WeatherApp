using System;
using WeatherApp.Domain.Abstractions;
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

        public User LoginUser(User user)
        {
            throw new NotImplementedException();
        }

        public User CreateUser(User user)
        {
            if(_repository.UserNameExists(user.Name))
                throw new InvalidOperationException("User with given username already exist");

            _repository.Create(user);
            _unitOfWork.SaveChanges();

            return _repository.GetUserByUserName(user.Name);

        }
    }
}