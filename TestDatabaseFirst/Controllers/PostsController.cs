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
    public class PostsController : ControllerBase
    {
        private readonly IPostsRepository postsRepository;

        public PostsController(IPostsRepository postsRepository)
        {
            this.postsRepository = postsRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Posts posts)
        {
            if (!ModelState.IsValid) return BadRequest();

            var isCreated = await postsRepository.Create(posts);

            return Ok(new { isCreated });
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await postsRepository.Get();

            return Ok(new { posts });
        }

        [HttpGet("{Post_id}")]
        public async Task<IActionResult> Get(int Post_id)
        {
            var post = await postsRepository.Get(Post_id);

            if (post == null) return NotFound();

            return Ok(new { post });
        }

    }
}
