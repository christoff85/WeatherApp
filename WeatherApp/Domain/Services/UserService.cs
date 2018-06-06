using System;
using WeatherApp.Domain.Abstractions;
using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public User LoginUser(User user)
        {
            throw new NotImplementedException();
        }

        public User CreateUser(User user)
        {
            if(_repository.UserNameExists(user.Name))
                throw new InvalidOperationException("User with given username already exist");

            _repository.Add(user);
            _repository.SaveChanges();

            return _repository.GetUserByUserName(user.Name);

        }
    }
}