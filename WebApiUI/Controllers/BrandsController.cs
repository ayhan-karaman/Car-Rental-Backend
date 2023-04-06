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
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("all-brands")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAllBrands();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-by-id-brand")]
        public IActionResult GetById(int id)
        {
            var result = _brandService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("new-brand")]
        public IActionResult Add(Brand brand)
        {
            var result = _brandService.Add(brand);
            return result.Success ? Ok(result) : BadRequest(result);
        } 

        [HttpPut("edit-brand")]
        public IActionResult Update(Brand brand)
        {
            var result = _brandService.Update(brand);
            return result.Success ? Ok(result) : BadRequest(result); 
        }

        [HttpDelete("remove-brand")]
        public IActionResult Delete(Brand brand)
        {
             var result = _brandService.Delete(brand);
             return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}