using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDatabaseFirst.Models;
using TestDatabaseFirst.Services.Interfaces;

namespace TestDatabaseFirst.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository usersRepository;
        public UsersController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Users user)
        {
            var isCreated = await usersRepository.Create(user);

            return Ok(new { isCreated });
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await usersRepository.Get();

            return Ok(users);
        }


    }
}
