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
    public class PostCommentsController : ControllerBase
    {
        private readonly IPostCommentsRepository _postRepository;

        public PostCommentsController(IPostCommentsRepository _postRepository)
        {
            this._postRepository = _postRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostComments postComments)
        {
            if (!ModelState.IsValid) return BadRequest();

            var isCreated = await _postRepository.Create(postComments);
            return Ok(new { isCreated });
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var postComments = await _postRepository.Get();

            return Ok(postComments);
        }
    }
}
