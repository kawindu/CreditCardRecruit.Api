using CreditCardRecruit.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditCardRecruit.Api.Services
{
    public interface ICreditCardService
    {
        Task<IEnumerable<CreditCard>> GetCreditCardsAsync();
        Task<CreditCard> GetCreditCardByIdAsync(int id);
        Task<ActionResult<CreditCard>> CreateCreditCardAsync(CreditCard creditCard);
    }
}
