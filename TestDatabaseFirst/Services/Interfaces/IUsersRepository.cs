using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDatabaseFirst.Models;

namespace TestDatabaseFirst.Services.Interfaces
{
    public interface IUsersRepository
    {
        Task<List<Users>> Get();
        Task<Users> Get(int User_id);
        Task<bool> Create(Users user);
        Task<bool> Update(Users user, int User_id);
        Task<bool> Delete(int User_id);
    }
}
