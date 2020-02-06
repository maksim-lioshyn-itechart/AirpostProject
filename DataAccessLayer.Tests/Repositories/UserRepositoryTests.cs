using System;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using NUnit.Framework;
using ORM.Models;

namespace DataAccessLayer.Tests.Repositories
{
    [TestFixture()]
    public class UserRepositoryTests
    {
        private readonly IUserRepository _userRepository;
        private User _testUser;
        private readonly User _user;
        public UserRepositoryTests()
        {
            _userRepository = new UserRepository();
            _user = new User
            {
                FirstName = Guid.NewGuid().ToString(),
                LastName = Guid.NewGuid().ToString(),
                Login = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString()
            };
        }

        [Test]
        [Order(0)]
        public void CreateTest()
        {
            _userRepository.Create(_user);
        }


        [Test]
        [Order(1)]
        public void GetByNameTest()
        {
            _testUser = _userRepository.GetByName(_user.FirstName);
            Assert.AreEqual(_user.Login, _testUser.Login);
        }

        [Test]
        [Order(2)]
        public void UpdateTest()
        {
            var firstName = "testUser.FirstName";
            var testUser = _userRepository.GetByName(_user.FirstName);
            testUser.FirstName = firstName;
            _userRepository.Update(testUser);
            var test = _userRepository.GetByName(firstName);
            Assert.AreEqual(firstName, test.FirstName);
        }

        [Test]
        [Order(3)]
        public void GetByIdTest()
        {
            var testUser = _userRepository.GetById(_testUser.Id);
            Assert.AreEqual(_testUser.Login, testUser.Login);
        }

        [Test]
        [Order(4)]
        public void GetAllTest()
        {
            var testUsers = _userRepository.GetAll();
            Assert.IsNotNull(testUsers);
        }

        [Test]
        [Order(100)]
        public void DeleteTest()
        {
            _userRepository.Delete(_testUser.Id);
        }

    }
}