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
        private IUserRepository User { get; }
        private IUserPasswordRepository UserPassword { get; }

        public UserService(IUserRepository user, IUserPasswordRepository userPassword)
        {
            User = user;
            UserPassword = userPassword;
        }

        public async Task<bool> Create(User entity)
        {
            var users = (await User.GetAll())
                .FirstOrDefault(
                    user =>
                        user.Id == entity.Id
                        && user.Email == entity.Email
                        && user.Phone == entity.Phone);
            var isExist = users != null;

            if (isExist)
            {
                return false;
            }

            await User.Create(entity.ToEntity());
            await UserPassword.Create(NewUserPassword(entity.Password, entity.Id));
            return true;
        }

        public async Task Update(User entity)
        {
            var user = await User.GetById(entity.Id);
            if (user != null)
            {
                await User.Update(entity.ToEntity());
            }
        }

        public async Task Delete(User entity)
        {
            var user = await User.GetById(entity.Id);
            var passwordInformation = await UserPassword.GetByUserId(entity.Id);
            if (user != null)
            {
                await UserPassword.Delete(passwordInformation.Id);
                await User.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<User>> GetAll() =>
            (await User.GetAll()).Select(user => user.ToModel());

        public async Task<User> GetById(Guid id) =>
            (await User.GetById(id))?.ToModel();

        public async Task<bool> ValidatePassword(Guid userId, string password)
        {
            var userPassword = await UserPassword.GetByUserId(userId);
            return Validate(password, userPassword.Salt, userPassword.Hash);
        }

        public Task<bool> UpdatePassword(Guid userId, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        private UserPasswordEntity NewUserPassword(string password, Guid userId)
        {
            var salt = CreateSalt();

            return new UserPasswordEntity
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Hash = GetUserPassword(password, salt),
                Salt = salt
            };
        }

        private static byte[] CreateSalt()
        {
            var saltSizeBytes = 32;
            var randomBytes = new byte[saltSizeBytes];
            using var generator = RandomNumberGenerator.Create();
            generator.GetBytes(randomBytes);
            return randomBytes;
        }

        public static bool Validate(string value, byte[] salt, byte[] hash) =>
            GetUserPassword(value, salt).SequenceEqual(hash);

        private static byte[] GetUserPassword(string password, byte[] salt)
        {
            // about values https://en.wikipedia.org/wiki/PBKDF2 . I get for IOS
            var iterationCount = 10000;
            //SHA-1 is 20 bytes, SHA-224 is 28 bytes, SHA-256 is 32 bytes, SHA-384 is 48 bytes, SHA-512 is 64 bytes
            var numBytesRequested = 32;
            return KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: iterationCount,
                numBytesRequested: numBytesRequested);
        }
    }
}
