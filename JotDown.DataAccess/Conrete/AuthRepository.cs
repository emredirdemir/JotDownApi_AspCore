using JotDown.DataAccess.Abstract;
using JotDown.DataAccess.Contexts.EntityFramewwork;
using JotDown.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JotDown.DataAccess.Conrete
{
    public class AuthRepository : IAuthRepo
    {
        private JotContext _context;
        public AuthRepository(JotContext context)
        {
            _context = context;
        }

        public async Task<User> Login(string userName, string password)
        {
           var user = await _context.users.FirstOrDefaultAsync(user => user.UserName == userName);

            if (user == null)
            {
                return null;
            }

            if (!VerifypassHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return user;
        }

        private bool VerifypassHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA256(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
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

            CreatePassHash(password ,out passHash, out passSalt);
            user.PasswordHash = passHash;
            user.PasswordSalt = passSalt;
            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private void CreatePassHash(string password, out byte[] passHash, out byte[] passSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passSalt = hmac.Key;
                passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string userName)
        {
            if (await _context.users.AnyAsync(x => x.UserName == userName))
            {
                return true;
            }

            return false;
        }
    }
}
