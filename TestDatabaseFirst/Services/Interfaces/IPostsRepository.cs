using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDatabaseFirst.Models;

namespace TestDatabaseFirst.Services.Interfaces
{
    public interface IPostsRepository
    {
        Task<List<Posts>> Get();
        Task<Posts> Get(int post_id);
        Task<bool> Create(Posts post);
        Task<bool> Update(Posts post, int Post_id);
        Task<bool> Delete(int Post_id);
    }
}
