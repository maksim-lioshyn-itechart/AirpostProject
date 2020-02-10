using System;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using NUnit.Framework;
using ORM.Models;

namespace DataAccessLayer.Tests.Repositories
{
    [TestFixture()]
    public class RoleRepositoryTests
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly User _user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = Guid.NewGuid().ToString(),
            LastName = Guid.NewGuid().ToString(),
            Login = Guid.NewGuid().ToString(),
            Password = Guid.NewGuid().ToString()
        };

        private readonly Role _role = new Role
        {
            Id  = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString()
        };

        private Role _testRole = new Role();

        public RoleRepositoryTests()
        {
            _roleRepository = new RoleRepository(new UnitOfWork(new ApplicationContext()));
            _userRepository = new UserRepository(new UnitOfWork(new ApplicationContext()));
        }

        [Test]
        [Order(0)]
        public void CreateTest()
        {
            _userRepository.Create(_user);
            _roleRepository.Create(_role);
        }

        [Test]
        [Order(1)]
        public void GetByNameTest()
        {
            _testRole = _roleRepository.GetByName(_role.Name);
            Assert.AreEqual(_testRole.Name, _role.Name);
        }

        [Test]
        [Order(2)]
        public void GetByIdTest()
        {
            var testRole = _roleRepository.GetById(_testRole.Id);
            Assert.AreEqual(_testRole.Name, testRole.Name);
        }

        [Test]
        [Order(3)]
        public void GetAllTest()
        {
            var testRoles = _roleRepository.GetAll();
            Assert.IsTrue(testRoles.Count > 0);
        }

        [Test]
        [Order(4)]
        public void AssignRoleToUserByIdTest()
        {
            _roleRepository.AssignRoleToUser(_user.Id, _role.Id);
            var testUser = _userRepository.GetByName(_user.FirstName);
            Assert.AreEqual(testUser.RoleId, _role.Id);
        }

        [Test()]
        [Order(5)]
        public void AssignRoleToUserByNameTest()
        {
            _roleRepository.AssignRoleToUser(_user.Id, _role.Name);
            var testUser = _userRepository.GetByName(_user.FirstName);
            Assert.AreEqual(testUser.RoleId, _role.Id);
        }

        [Test]
        [Order(99)]
        public void UpdateTest()
        {
            var name = "name";
            var testRole = _roleRepository.GetByName(_role.Name);
            testRole.Name = name;
            _roleRepository.Update(testRole);
            var test = _roleRepository.GetByName(name);
            Assert.AreEqual(name, test.Name);
        }

        [Test]
        [Order(100)]
        public void DeleteTest()
        {
            _roleRepository.Delete(_role.Id);
            _userRepository.Delete(_user.Id);
        }

    }
}