﻿using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Matricks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Matricks.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<User> Login(string userName, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);

            return (user == null || !PasswordHashVerified(password, user.PasswordHash, user.PasswordSalt)) ? null : user;
        }

        private bool PasswordHashVerified(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            // Hash password and compare with PasswordHash stored in database
            var hash = new HMACSHA512(passwordSalt);
            var computedHash = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            if (computedHash.SequenceEqual(passwordHash))
            {
                return true;
            } else {
                return false;
            }
            // Temporary return value for testing
            //return true;
        }

        public async Task<User> Register(string userName, string password)
        {
            // Hash the password using SHA512 with random key (salt)
            var hash = new HMACSHA512();
            var computedHash = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            var newUser = new User { UserName = userName };
            newUser.PasswordHash = computedHash;
            newUser.PasswordSalt = hash.Key;

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public Boolean Duplicate(string userName)
        {
            var flag = false;
            foreach(var user in _context.Users)
            {
                if (userName == user.UserName)
                {
                    return true;
                }
            }
            return flag;
        }

    }
}
