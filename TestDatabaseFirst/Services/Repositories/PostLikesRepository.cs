using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDatabaseFirst.Models;
using TestDatabaseFirst.Services.Interfaces;

namespace TestDatabaseFirst.Services.Repositories
{
    public class PostLikesRepository : IPostLikesRepository
    {
        private readonly PostDatabaseFirstContext _context;

        public PostLikesRepository(PostDatabaseFirstContext _context)
        {
            this._context = _context;
        }

        public async Task<bool> Create(PostLikes postLikes)
        {
            var isCreated = false;
            try
            {
                await _context.PostLikes.AddAsync(postLikes);
                await _context.SaveChangesAsync();
                isCreated = true;
            }
            catch (Exception)
            {

               
            }

            return isCreated;
        }

        public async Task<List<PostLikes>> Get()
        {
            List<PostLikes> postlikes = new List<PostLikes>();
            try
            {
                postlikes = await _context
                    .PostLikes
                    .Include(p => p.Post)
                    .Include(p => p.User)
                    .ToListAsync();
            }
            catch (Exception)
            {

                
            }
            return postlikes;
        }
    }
}
