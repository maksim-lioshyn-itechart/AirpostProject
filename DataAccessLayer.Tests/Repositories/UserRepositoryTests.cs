using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using NUnit.Framework;

using static DataAccessLayer.Tests.Repositories.StabsEntities;

namespace DataAccessLayer.Tests.Repositories
{
    [TestFixture()]
    public class UserRepositoryTests
    {
        private readonly IUserRepository _userRepository;
        private User _testUser;
        
        public UserRepositoryTests()
        {
            _userRepository = new UserRepository();
        }

        [Test]
        [Order(0)]
        public void UserRepository_CreateTest_CreateTestUser()
        {
            _userRepository.Create(BaseUser);
        }
       
        [Test]
        [Order(1)]
        public void UserRepository_GetByNameTest_ReturnTestUser()
        {
            _testUser = _userRepository.GetByName(BaseUser.FirstName);
            Assert.AreEqual(BaseUser.Login, _testUser.Login);
        }

        [Test]
        [Order(1)]
        public async Task UserRepository_GetByNameAsyncTest_ReturnTestUser()
        {
            var testUser = await _userRepository.GetByNameAsync(BaseUser.FirstName);
            Assert.AreEqual(BaseUser.Login, testUser.Login);
        }

        [Test]
        [Order(2)]
        public void UserRepository_GetByIdTest_ReturnTestUser()
        {
            var testUser = _userRepository.GetById(_testUser.Id);
            Assert.AreEqual(_testUser.Login, testUser.Login);
        }

        [Test]
        [Order(3)]
        public void UserRepository_GetAllTest_ReturnSomeUsers()
        {
            var testUsers = _userRepository.GetAll();
            Assert.IsNotNull(testUsers);
        }

        [Test]
        [Order(99)]
        public void UserRepository_UpdateTest_UpdateFirstNameTestUser()
        {
            var firstName = "testUser.FirstName";
            var testUser = _userRepository.GetByName(BaseUser.FirstName);
            testUser.FirstName = firstName;
            _userRepository.Update(testUser);
            var test = _userRepository.GetByName(firstName);
            Assert.AreEqual(firstName, test.FirstName);
        }

        [Test]
        [Order(100)]
        public void UserRepository_DeleteTest_DeleteTestUser()
        {
            _userRepository.Delete(_testUser.Id);
        }

    }
}