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
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialsController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet("get-all")]
        public IActionResult GetAllDto()
        {
             var result = _testimonialService.GetAllCustomerTestimonailDtos();
             return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("new-comment")]
        public IActionResult Add(Testimonial testimonial)
        {
             var result = _testimonialService.Add(testimonial);
             return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}