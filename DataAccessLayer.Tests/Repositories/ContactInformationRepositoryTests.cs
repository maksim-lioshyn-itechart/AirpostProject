using System;
using System.Collections.Generic;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using NUnit.Framework;
using ORM.Models;
using static DataAccessLayer.Tests.Repositories.StabsEntities;

namespace DataAccessLayer.Tests.Repositories
{
    [TestFixture()]
    public class ContactInformationRepositoryTests
    {
        private readonly IUserRepository _userRepository;
        private readonly IContactInformationRepository _contactInformationRepository;

        private readonly List<ContactInformation> _information = new List<ContactInformation>
        {
            new ContactInformation
            {
                Id = Guid.NewGuid(),
                UserId = BaseUser.Id,
                Address = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString(),
                Phone = Guid.NewGuid().ToString()
            },
            new ContactInformation
            {
                Id = Guid.NewGuid(),
                UserId = BaseUser.Id,
                Address = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString(),
                Phone = Guid.NewGuid().ToString()
            },
            new ContactInformation
            {
                Id = Guid.NewGuid(),
                UserId = BaseUser.Id,
                Address = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString(),
                Phone = Guid.NewGuid().ToString()
            },
            new ContactInformation
            {
                Id = Guid.NewGuid(),
                UserId = BaseUser.Id,
                Address = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString(),
                Phone = Guid.NewGuid().ToString()
            }
        };

        public ContactInformationRepositoryTests()
        {
            _userRepository = new UserRepository(new UnitOfWork(new ApplicationContext()));
            _contactInformationRepository = new ContactInformationRepository(new UnitOfWork(new ApplicationContext()));
        }

        [Test]
        [Order(0)]
        public void ContactInformationRepository_CreateTest_CreateTestContactInformation()
        {
            _userRepository.Create(BaseUser);
            foreach (var information in _information)
            {
                _contactInformationRepository.Create(information);
            }
        }
       
        [Test]
        [Order(1)]
        public void ContactInformationRepository_GetContactInformationByUserTest_ReturnTestContactInformation()
        {
            var testUserInformation = _contactInformationRepository.GetContactInformationByUser(BaseUser);
            Assert.IsTrue(testUserInformation.FindIndex(u => u.Id == _information[0].Id) >= 0);
        }

        [Test]
        [Order(2)]
        public void ContactInformationRepository_GetByIdTest_ReturnTestContactInformation()
        {
            var information = _contactInformationRepository.GetById(_information[0].Id);
            Assert.AreEqual(information.Id, _information[0].Id);
        }

        [Test]
        [Order(3)]
        public void ContactInformationRepository_GetAllTest_ReturnAllContactInformation()
        {
            var contactInformation = _contactInformationRepository.GetAll();
            Assert.Greater(contactInformation.Count, 0);
        }

        [Test]
        [Order(99)]
        public void ContactInformationRepository_UpdateTest_UpdateTestContactInformation()
        {
            var phone = "phone";
            var information = _contactInformationRepository.GetById(_information[0].Id);
            information.Phone = phone;
            _contactInformationRepository.Update(information);
            var test = _contactInformationRepository.GetById(_information[0].Id);
            Assert.AreEqual(phone, test.Phone);
        }

        [Test]
        [Order(100)]
        public void ContactInformationRepository_DeleteTest_DeleteTestContactInformation()
        {
            foreach (var information in _information)
            {
                _contactInformationRepository.Delete(information.Id);
            }
            _userRepository.Delete(BaseUser.Id);
        }
    }
}