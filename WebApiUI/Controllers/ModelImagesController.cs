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
    public class ModelImagesController : ControllerBase
    {
          private readonly IModelImageService _modelImageService;

        public ModelImagesController(IModelImageService modelImageService)
        {
            _modelImageService = modelImageService;
        }

        [HttpPost("new-image")]
        public IActionResult Add([FromForm] ModelImage modelImage, [FromForm] IFormFile file)
        {
                    var result = _modelImageService.Add(modelImage, file);
                    return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("edit-image")]
        public IActionResult Update([FromForm] ModelImage modelImage, [FromForm] IFormFile file)
        {
                    var result = _modelImageService.Update(modelImage, file);
                    return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-by-model-id-images")]
        public IActionResult GetByModelIdImages(int id)
        {
            var result = _modelImageService.GetAllByImageId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}