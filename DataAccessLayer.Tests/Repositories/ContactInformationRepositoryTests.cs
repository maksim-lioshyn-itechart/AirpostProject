using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using NUnit.Framework;

using static DataAccessLayer.Tests.Repositories.StabsEntities;

namespace DataAccessLayer.Tests.Repositories
{
    [TestFixture()]
    public class UserContactInformationRepositoryTests
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserContactInformationRepository _UserContactInformationRepository;

        private readonly List<UserContactInformation> _information = new List<UserContactInformation>
        {
            new UserContactInformation
            {
                Id = Guid.NewGuid(),
                UserId = BaseUser.Id,
                Address = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString(),
                Phone = Guid.NewGuid().ToString()
            },
            new UserContactInformation
            {
                Id = Guid.NewGuid(),
                UserId = BaseUser.Id,
                Address = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString(),
                Phone = Guid.NewGuid().ToString()
            },
            new UserContactInformation
            {
                Id = Guid.NewGuid(),
                UserId = BaseUser.Id,
                Address = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString(),
                Phone = Guid.NewGuid().ToString()
            },
            new UserContactInformation
            {
                Id = Guid.NewGuid(),
                UserId = BaseUser.Id,
                Address = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString(),
                Phone = Guid.NewGuid().ToString()
            }
        };

        public UserContactInformationRepositoryTests()
        {
            _userRepository = new UserRepository();
            _UserContactInformationRepository = new UserContactInformationRepository();
        }

        [Test]
        [Order(0)]
        public void UserContactInformationRepository_CreateTest_CreateTestUserContactInformation()
        {
            _userRepository.Create(BaseUser);
            foreach (var information in _information)
            {
                _UserContactInformationRepository.Create(information);
            }
        }
       
        [Test]
        [Order(1)]
        public void UserContactInformationRepository_GetUserContactInformationByUserTest_ReturnTestUserContactInformation()
        {
            var testUserInformation = _UserContactInformationRepository.GetUserContactInformation(BaseUser);
            Assert.IsTrue(testUserInformation.ToList().FindIndex(u => u.Id == _information[0].Id) >= 0);
        }

        [Test]
        [Order(2)]
        public void UserContactInformationRepository_GetByIdTest_ReturnTestUserContactInformation()
        {
            var information = _UserContactInformationRepository.GetById(_information[0].Id);
            Assert.AreEqual(information.Id, _information[0].Id);
        }

        [Test]
        [Order(3)]
        public void UserContactInformationRepository_GetAllTest_ReturnAllUserContactInformation()
        {
            var UserContactInformation = _UserContactInformationRepository.GetAll().ToList();
            Assert.Greater(UserContactInformation.Count, 0);
        }

        [Test]
        [Order(99)]
        public void UserContactInformationRepository_UpdateTest_UpdateTestUserContactInformation()
        {
            var phone = "phone";
            var information = _UserContactInformationRepository.GetById(_information[0].Id);
            information.Phone = phone;
            _UserContactInformationRepository.Update(information);
            var test = _UserContactInformationRepository.GetById(_information[0].Id);
            Assert.AreEqual(phone, test.Phone);
        }

        [Test]
        [Order(100)]
        public void UserContactInformationRepository_DeleteTest_DeleteTestUserContactInformation()
        {
            foreach (var information in _information)
            {
                _UserContactInformationRepository.Delete(information.Id);
            }
            _userRepository.Delete(BaseUser.Id);
        }
    }
}