using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDatabaseFirst.Models;
using TestDatabaseFirst.Services.Interfaces;

namespace TestDatabaseFirst.Services.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        private readonly PostDatabaseFirstContext _context;

        public PostsRepository(PostDatabaseFirstContext context)
        {
            this._context = context;
        }

        public async Task<bool> Create(Posts post)
        {
            var isCreated = false;
            try
            {
                await _context.Posts.AddAsync(post);
                await _context.SaveChangesAsync();
                isCreated = true;
            }
            catch (Exception)
            {

                
            }
            return isCreated;
        }

        public Task<bool> Delete(int Post_id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Posts>> Get()
        {
            var posts = new List<Posts>();
            try
            {
                posts = await
                    _context
                    .Posts
                    .Include(p => p.User)
                    .Include(p => p.PostComments)
                    .Include(p => p.PostLikes)
                    .ToListAsync();
            }
            catch (Exception e)
            {

                //throw;
            }
            return posts;
        }

        public async Task<Posts> Get(int post_id)
        {
            var post = new Posts();
            try
            {
                post = await 
                    _context
                    .Posts
                    .Include(p => p.User)
                    .Include(p => p.PostComments)
                    .Include(p => p.PostLikes)
                    .FirstOrDefaultAsync(p => p.PostId.Equals(post_id));

            }
            catch (Exception)
            {

                throw;
            }
            return post;
        }

        public Task<bool> Update(Posts post, int Post_id)
        {
            throw new NotImplementedException();
        }
    }
}
