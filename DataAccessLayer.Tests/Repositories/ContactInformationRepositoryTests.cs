using System;
using System.Collections.Generic;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using NUnit.Framework;
using ORM.Models;

namespace DataAccessLayer.Tests.Repositories
{
    [TestFixture()]
    public class ContactInformationRepositoryTests
    {
        private readonly IUserRepository _userRepository;
        private readonly IContactInformationRepository _contactInformationRepository;
        private static readonly User User = new User
        {
            Id = Guid.NewGuid(),
            FirstName = Guid.NewGuid().ToString(),
            LastName = Guid.NewGuid().ToString(),
            Login = Guid.NewGuid().ToString(),
            Password = Guid.NewGuid().ToString()
        };

        private List<ContactInformation> _information = new List<ContactInformation>
        {
            new ContactInformation
            {
                Id = Guid.NewGuid(),
                UserId = User.Id,
                Address = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString(),
                Phone = Guid.NewGuid().ToString()
            },
            new ContactInformation
            {
                Id = Guid.NewGuid(),
                UserId = User.Id,
                Address = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString(),
                Phone = Guid.NewGuid().ToString()
            },
            new ContactInformation
            {
                Id = Guid.NewGuid(),
                UserId = User.Id,
                Address = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString(),
                Phone = Guid.NewGuid().ToString()
            },
            new ContactInformation
            {
                Id = Guid.NewGuid(),
                UserId = User.Id,
                Address = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString(),
                Phone = Guid.NewGuid().ToString()
            }
        };

        public ContactInformationRepositoryTests()
        {
            _userRepository = new UserRepository(new UnitOfWork(new ORM.ApplicationContext()));
            _contactInformationRepository = new ContactInformationRepository(new UnitOfWork(new ORM.ApplicationContext()));
        }

        [Test]
        [Order(0)]
        public void CreateTest()
        {
            _userRepository.Create(User);
            foreach (var information in _information)
            {
                _contactInformationRepository.Create(information);
            }
        }
       
        [Test]
        [Order(1)]
        public void GetContactInformationByUserTest()
        {
            var testUserInformation = _contactInformationRepository.GetContactInformationByUser(User);
            Assert.IsTrue(testUserInformation.FindIndex(u => u.Id == _information[0].Id) >= 0);
        }

        [Test]
        [Order(2)]
        public void GetByIdTest()
        {
            var information = _contactInformationRepository.GetById(_information[0].Id);
            Assert.AreEqual(information.Id, _information[0].Id);
        }

        [Test]
        [Order(3)]
        public void GetAllTest()
        {
            var contactInformation = _contactInformationRepository.GetAll();
            Assert.IsTrue(contactInformation.Count > 0);
        }

        [Test]
        [Order(99)]
        public void UpdateTest()
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
        public void DeleteTest()
        {
            foreach (var information in _information)
            {
                _contactInformationRepository.Delete(information.Id);
            }
            _userRepository.Delete(User.Id);
        }
    }
}