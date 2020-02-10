﻿using System;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using NUnit.Framework;
using ORM.Models;
using static DataAccessLayer.Tests.Repositories.StabsEntities;

namespace DataAccessLayer.Tests.Repositories
{
    [TestFixture()]
    public class RoleRepositoryTests
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
       
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
        public void RoleRepository_CreateTest_CreateTestRole()
        {
            _userRepository.Create(BaseUser);
            _roleRepository.Create(_role);
        }

        [Test]
        [Order(1)]
        public void RoleRepository_GetByNameTest_ReturnTestRole()
        {
            _testRole = _roleRepository.GetByName(_role.Name);
            Assert.AreEqual(_testRole.Name, _role.Name);
        }

        [Test]
        [Order(2)]
        public void RoleRepository_GetByIdTest_ReturnTestRole()
        {
            var testRole = _roleRepository.GetById(_testRole.Id);
            Assert.AreEqual(_testRole.Name, testRole.Name);
        }

        [Test]
        [Order(3)]
        public void RoleRepository_GetAllTest_ReturnAllRoles()
        {
            var testRoles = _roleRepository.GetAll();
            Assert.Greater(testRoles.Count, 0);
        }

        [Test]
        [Order(4)]
        public void RoleRepository_AssignRoleToUserByIdTest_SetUpTestRoleToTestUser()
        {
            _roleRepository.AssignRoleToUser(BaseUser.Id, _role.Id);
            var testUser = _userRepository.GetByName(BaseUser.FirstName);
            Assert.AreEqual(testUser.RoleId, _role.Id);
        }

        [Test()]
        [Order(5)]
        public void RoleRepository_AssignRoleToUserByNameTest_SetUpTestRoleToTestUser()
        {
            _roleRepository.AssignRoleToUser(BaseUser.Id, _role.Name);
            var testUser = _userRepository.GetByName(BaseUser.FirstName);
            Assert.AreEqual(testUser.RoleId, _role.Id);
        }

        [Test]
        [Order(99)]
        public void RoleRepository_UpdateTest_UpdateTestRole()
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
        public void RoleRepository_DeleteTest_DeleteTestRole()
        {
            _roleRepository.Delete(_role.Id);
            _userRepository.Delete(BaseUser.Id);
        }

    }
}