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
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("all-colors")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAllColors();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-by-id-color")]
        public IActionResult GetById(int id)
        {
            var result = _colorService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("new-color")]
        public IActionResult Add(Color color)
        {
            var result = _colorService.Add(color);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("edit-color")]
        public IActionResult Update(Color color)
        {
            var result = _colorService.Update(color);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("new-color")]
        public IActionResult Delete(Color color)
        {
            var result = _colorService.Delete(color);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}