using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mappers;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork UnitOfWork { get; }

        public UserService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<bool> Create(UserBm entity)
        {
            var users = await UnitOfWork.User.GetAll();
            var isExist = users.FirstOrDefault(user =>
                              user.Id == entity.Id
                              && user.Email == entity.Email
                              && user.Phone == entity.Phone) != null;

            if (isExist)
            {
                return false;
            }

            await UnitOfWork.User.Create(entity.ToDal());
            await UnitOfWork.UserPassword.Create(NewUserPassword(entity.Password, entity.Id));
            return true;
        }

        public async Task Update(UserBm entity)
        {
            var user = await UnitOfWork.User.GetById(entity.Id);
            if (user != null)
            {
                await UnitOfWork.User.Update(entity.ToDal());
            }
        }

        public async Task Delete(UserBm entity)
        {
            var user = await UnitOfWork.User.GetById(entity.Id);
            var passwordInformation = await UnitOfWork.UserPassword.GetByUserId(entity.Id);
            if (user != null)
            {
                await UnitOfWork.UserPassword.Delete(passwordInformation.Id);
                await UnitOfWork.User.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<UserBm>> GetAll() =>
            (await UnitOfWork.User.GetAll()).Select(user => user.ToBm());

        public async Task<UserBm> GetById(Guid id) =>
            (await UnitOfWork.User.GetById(id)).ToBm();

        public async Task<bool> ValidatePassword(Guid userId, string password)
        {
            var userPassword = await UnitOfWork.UserPassword.GetByUserId(userId);
            return Validate(password, userPassword.Salt, userPassword.Hash);
        }

        public Task<bool> UpdatePassword(Guid userId, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        private UserPassword NewUserPassword(string password, Guid userId)
        {
            var salt = CreateSalt();

            return new UserPassword
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Hash = UserPassword(password, salt),
                Salt = salt
            };
        }

        private static byte[] CreateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using var generator = RandomNumberGenerator.Create();
            generator.GetBytes(randomBytes);
            return randomBytes;
        }

        public static bool Validate(string value, byte[] salt, byte[] hash) =>
            UserPassword(value, salt).SequenceEqual(hash);

        private static byte[] UserPassword(string password, byte[] salt) =>
            KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8);
    }
}
