using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mappers;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

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

        public Task Update(UserBm entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(UserBm entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserBm>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserBm> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ValidatePassword(Guid userId, string password)
        {
            var usrPassword = await UnitOfWork.UserPassword.GetByUserId(userId);
            var a = Validate(password, usrPassword.Salt, usrPassword.Hash);
            return a;
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

        public static bool Validate(string value, byte[] salt, byte[] hash)
            => UserPassword(value, salt) == hash;

        private static byte[] UserPassword(string password, byte[] salt)
        {
            return KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 128 / 8);
        }
    }
}
