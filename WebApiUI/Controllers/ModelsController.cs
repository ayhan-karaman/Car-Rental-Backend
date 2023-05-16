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
    public class ModelsController : ControllerBase
    {
        private readonly IModelService _modelService;

        public ModelsController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet("all-models")]
        public IActionResult GetAll()
        {
            var result = _modelService.GetAllModelFeatureDtos();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-by-id-model")]
        public IActionResult GetById(int id)
        {
            var result = _modelService.GetByModelId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-by-brand-and-color-name-colors")]
        public IActionResult GetByBrandNameAndColorNameModels(string brandName, string colorName)
        {
            var result = _modelService.GetBrandNameAndColorNameModels(brandName, colorName);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-by-brand-name")]
        public IActionResult GetByBrandNameNameModels(string brandName)
        {
            var result = _modelService.GetBrandNameModels(brandName);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-by-color-name")]
        public IActionResult GetByColorNameNameModels(string colorName)
        {
            var result = _modelService.GetColorNameModels(colorName);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("new-model")]
        public IActionResult Add(Model model)
        {
            var result = _modelService.Add(model);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("edit-model")]
        public IActionResult Update(Model model)
        {
            var result = _modelService.Update(model);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("remove-model")]
        public IActionResult Delete(Model model)
        {
            var result = _modelService.Delete(model);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}