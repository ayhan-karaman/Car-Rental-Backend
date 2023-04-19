using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApiUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("all-blogs")]
        public IActionResult GetAllUserForBlogDtos()
        {
             var result = _blogService.GetUserForBlogDtos();
             return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-by-id-blog")]
        public IActionResult GetByIdBlog(int id)
        {
            var result = _blogService.GetByIdUserForBlogDtos(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("new-blog")]
        public IActionResult Add([FromForm] Blog blog, [FromForm] IFormFile file)
        {
            var result = _blogService.Add(blog, file);
            return result.Success ? Ok(result) : BadRequest(result); 
        }


    }
    
}