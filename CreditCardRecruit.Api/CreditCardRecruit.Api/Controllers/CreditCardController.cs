using CreditCardRecruit.Api.Models;
using CreditCardRecruit.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CreditCardRecruit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardService _creditCardService;

        public CreditCardController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        // GET: api/<CreditCardController>
        [HttpGet]
        public async Task<IEnumerable<CreditCard>> GetAsync()
        {
            return await _creditCardService.GetCreditCardsAsync();
        }

        // GET api/<CreditCardController>/5
        [HttpGet("{id}")]
        public async Task<CreditCard> GetAsync(int id)
        {
            return await _creditCardService.GetCreditCardByIdAsync(id);
        }

        // POST api/<CreditCardController>
        [HttpPost]
        public async Task<ActionResult<CreditCard>> PostAsync([FromBody] CreditCard creditCard)
        {
            return await _creditCardService.CreateCreditCardAsync(creditCard);
        }
    }
}
