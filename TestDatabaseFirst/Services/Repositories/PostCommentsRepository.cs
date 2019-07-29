using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDatabaseFirst.Models;
using TestDatabaseFirst.Services.Interfaces;

namespace TestDatabaseFirst.Services.Repositories
{
    public class PostCommentsRepository : IPostCommentsRepository
    {
        private readonly PostDatabaseFirstContext _context;
        public PostCommentsRepository(PostDatabaseFirstContext _context)
        {
            this._context = _context;
        }

        public async Task<bool> Create(PostComments postComments)
        {
            var isCreated = false;
            try
            {
                await _context.PostComments.AddAsync(postComments);
                await _context.SaveChangesAsync();
                isCreated = true;
            }
            catch (Exception)
            {
            }
            return isCreated;
        }

        public async Task<List<PostComments>> Get()
        {
            var postComments = new List<PostComments>();
            try
            {
                postComments = await 
                    _context
                    .PostComments
                    .Include(pc => pc.Post)
                    .Include(pc => pc.User)
                    .Include(pc => pc.Post.PostLikes)
                    .ToListAsync();
            }
            catch (Exception)
            {

            }
            return postComments;
        }
    }
}
