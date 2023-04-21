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
    public class Rentals : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public Rentals(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost("new-rental")]
        public IActionResult AddRental(Rental rental)
        {
                var result = _rentalService.Add(rental);
                return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpGet("get_by_customer_id_rentals")]
        public IActionResult GetByCustomerIdRentals(int customerId)
        {
                var result = _rentalService.GetAllCustomerId(customerId);
                return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get_all_rentals")]
        public IActionResult GetAllRentals()
        {
                var result = _rentalService.GetAll();
                return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}