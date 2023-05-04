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
    public class CreditCardsController : ControllerBase
    {
        private readonly ICreditCardService _creditCardService;

        public CreditCardsController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpPost("new-card")]
        public IActionResult Add(CreditCard creditCard)
        {
            var result = _creditCardService.Add(creditCard);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-by-customer-id")]
        public IActionResult GetByCustomerId(int customerId)
        {
             var result = _creditCardService.GetByCustomerId(customerId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}