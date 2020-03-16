using BusinessLogic.Enums;
using BusinessLogic.Interfaces;
using BusinessLogic.Mappers;
using BusinessLogic.Models;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private const int SaltSizeBytes = 32;
        // about values https://en.wikipedia.org/wiki/PBKDF2 . I get for IOS
        private const int IterationCount = 10000;
        //SHA-1 is 20 bytes, SHA-224 is 28 bytes, SHA-256 is 32 bytes, SHA-384 is 48 bytes, SHA-512 is 64 bytes
        private const int NumBytesRequested = 32;

        private IUserRepository User { get; }
        private IUserPasswordRepository UserPassword { get; }

        public UserService(IUserRepository user, IUserPasswordRepository userPassword)
        {
            User = user;
            UserPassword = userPassword;
        }

        public async Task<StatusCode> Create(User entity)
        {
            Validation(entity);
            var users = await User.GetBy(entity.Email, entity.Phone);
            var isExist = users != null;

            if (isExist)
            {
                return StatusCode.AlreadyExists;
            }

            await User.Create(entity.ToEntity());
            await UserPassword.Create(NewUserPassword(entity.Password, entity.Id));
            return StatusCode.Created;
        }

        public async Task<StatusCode> Update(User entity)
        {
            var user = await User.GetById(entity.Id);
            if (user != null)
            {
                Validation(entity);
                await User.Update(entity.ToEntity());
                return StatusCode.Updated;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<StatusCode> Delete(User entity)
        {
            var user = await User.GetById(entity.Id);
            var passwordInformation = await UserPassword.GetBy(entity.Id);
            if (user != null)
            {
                await UserPassword.Delete(passwordInformation.Id);
                await User.Delete(entity.Id);
                return StatusCode.Deleted;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<IEnumerable<User>> GetAll() =>
            (await User.GetAll()).Select(user => user.ToModel());

        public async Task<User> GetById(Guid id) =>
            (await User.GetById(id))?.ToModel();

        public async Task<bool> ValidatePassword(Guid userId, string password)
        {
            var userPassword = await UserPassword.GetBy(userId);
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
            var randomBytes = new byte[SaltSizeBytes];
            using var generator = RandomNumberGenerator.Create();
            generator.GetBytes(randomBytes);
            return randomBytes;
        }

        public static bool Validate(string value, byte[] salt, byte[] hash) =>
            GetUserPassword(value, salt).SequenceEqual(hash);

        private static byte[] GetUserPassword(string password, byte[] salt) =>
            KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: IterationCount,
                numBytesRequested: NumBytesRequested);

        private void Validation(User entity)
        {
            var validator = new Validator<User>();
            validator.IsValidName(entity.FirstName + entity.LastName);
            validator.IsValidEmail(entity.Email);
            validator.IsValidPhone(entity.Phone);
        }
    }
}
