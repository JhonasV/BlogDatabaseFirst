using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDatabaseFirst.Models;

namespace TestDatabaseFirst.Services.Interfaces
{
    public interface IPostCommentsRepository
    {
        Task<bool> Create(PostComments postComments);
        Task<List<PostComments>> Get();
    }
}
