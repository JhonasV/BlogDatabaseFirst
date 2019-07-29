using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDatabaseFirst.Models;
using TestDatabaseFirst.Services.Interfaces;

namespace TestDatabaseFirst.Services.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly PostDatabaseFirstContext _context;

        public UsersRepository(PostDatabaseFirstContext _context)
        {
            this._context = _context;
        }

        public async Task<bool> Create(Users user)
        {
            var isCreated = false;
            try
            {
                //user.CreatedAt = DateTime.Now;
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                isCreated = true;
            }
            catch (Exception e)
            {
                //TODO: Implement logger
                throw;
            }
            return isCreated;
        }

        public async Task<bool> Delete(int User_id)
        {
            var isDeleted = false;
            try
            {
                var user = await _context.Users.FindAsync(User_id);
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                isDeleted = true;
            }
            catch (Exception)
            {

                throw;
            }
            return isDeleted;
        }

        public async Task<List<Users>> Get()
        {
            List<Users> users = new List<Users>();
            try
            {
                users = await _context
                    .Users
                    .Include(u => u.Posts)
                    .Include(u => u.PostLikes)
                    .ToListAsync();
                

            }
            catch (Exception)
            {
                
                
            }
            return users;
        }

        public async Task<Users> Get(int User_id)
        {
            Users user = new Users();
            try
            {
                var users = await this.Get();
                user = users.Where(u => u.UserId.Equals(User_id)).FirstOrDefault();
               
            }
            catch (Exception)
            {

                throw;
            }
            return user;
        }

        public async Task<bool> Update(Users user, int User_id)
        {
            var isUpdated = false;
            try
            {
                var newUser = await this.Get(User_id);
                newUser.UserName = user.UserName;
                newUser.UpdatedAt = DateTime.Now;
                isUpdated = true;
            }
            catch (Exception)
            {

                throw;
            }
            return isUpdated;
        }
    }
}
