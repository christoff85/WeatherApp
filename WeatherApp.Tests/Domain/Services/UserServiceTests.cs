using NUnit.Framework;
using NSubstitute;
using WeatherApp.Domain.Abstractions.Data;
using WeatherApp.Domain.Models;
using WeatherApp.Domain.Services;

namespace WeatherApp.Tests.Domain.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        private readonly string _username = "JohnDoe";
        private readonly string _password = "password";

        [Test]
        public void LoginUserByUserService_ExpectResultEqualToUserStub()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var repository = Substitute.For<IUserRepository>();
            var expected = new User();

            repository.GetSingleOrDefault(_username, _password).Returns(expected);

            var sut = new UserService(repository, unitOfWork);
            var result = sut.LoginUser(_username, _password);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TryToCreateUserByUserServiceButUserExists_ExpectResultToBeNull()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var repository = Substitute.For<IUserRepository>();

            repository.UserNameExists(_username).Returns(true);

            var sut = new UserService(repository, unitOfWork);
            var result = sut.CreateUser(_username, _password);

            Assert.IsNull(result);
        }

        [Test]
        public void CreateUserByUserService_ExpectResultEqualToUserStub()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var repository = Substitute.For<IUserRepository>();
            var expected = new User();

            repository.UserNameExists(_username).Returns(false);
            repository.GetUserByUserName(_username).Returns(expected);

            var sut = new UserService(repository, unitOfWork);
            var result = sut.CreateUser(_username, _password);

            repository.Received().CreateUser(_username, _password);
            unitOfWork.Received().SaveChanges();

            Assert.AreEqual(expected, result);
        }
    }
}
