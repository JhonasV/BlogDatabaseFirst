using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDatabaseFirst.Models;

namespace TestDatabaseFirst.Services.Interfaces
{
    public interface IPostLikesRepository
    {
        Task<List<PostLikes>> Get();
        Task<bool> Create(PostLikes postLikes);
    }
}
