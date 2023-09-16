using Microsoft.EntityFrameworkCore;
using ReWrite.API.DAL.AuthDAL.Interfaces;
using ReWrite.API.DAL.Context;
using ReWrite.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ReWrite.API.DAL.AuthDAL.Concrete
{
    public class AuthDAL : IAuthDAL
    {
        private readonly AuthContext _context;
        public AuthDAL(AuthContext context)
        {
            _context = context;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _context.User.FirstOrDefaultAsync(a => a.Username == username);
            if (user == null)
            {
                return null;
            }
            if (!CheckPassword(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            return user;
        }

        private bool CheckPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < password.Length; i++)
                {
                    if (passHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passHash, passSalt;
            CryptPass(password,out passHash, out passSalt);
            user.PasswordHash = passHash;
            user.PasswordSalt = passSalt;

            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private void CryptPass(string password, out byte[] passHash, out byte[] passSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                passSalt = hmac.Key;
            }
        }

        public async Task<bool> UserExist(string username)
        {
            return await _context.User.AnyAsync(a=>a.Username==username);
        }
    }
}
