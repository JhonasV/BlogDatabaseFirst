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
    public class PostLikesController : ControllerBase
    {
        private readonly IPostLikesRepository postLikesRepo;
        public PostLikesController(IPostLikesRepository postLikesRepo)
        {
            this.postLikesRepo = postLikesRepo;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostLikes postLikes)
        {
            if (!ModelState.IsValid) return BadRequest();

            var isCreated = await postLikesRepo.Create(postLikes);

            return Ok(new { isCreated });
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var postlikes = await postLikesRepo.Get();

            return Ok(postlikes);
        }
    }
}
