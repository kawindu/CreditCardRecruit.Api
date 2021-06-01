using CreditCardRecruit.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CreditCardRecruit.Api.Services
{
    public class CreditCardService : ICreditCardService
    {
        public async Task<ActionResult<CreditCard>> CreateCreditCardAsync(CreditCard creditCard)
        {
            if (IsCreditCardNumberValid(creditCard.CreditCardNumber) && !IsCreditCardExpired(creditCard.ExpiryDate))
            {
                creditCard.CreditCardNumber = Base64Encode(creditCard.CreditCardNumber);
                creditCard.CvcNumber = Base64Encode(creditCard.CvcNumber);
                creditCard.ExpiryDate = Base64Encode(creditCard.ExpiryDate);

                //TODO:await Save 'creditCard' in storage 

                CreditCard savedCreditCardFromStorage = new CreditCard()
                {
                    Id = 1,
                    Name = "Kawindu",
                    CreditCardNumber = "NTU1NTM0MTI0NDQ0MTExNQ==",
                    CvcNumber = "MzAz",
                    ExpiryDate = "MTIvMjAyMA=="
                };

                return new CreditCard()
                {
                    Id = savedCreditCardFromStorage.Id,
                    Name = savedCreditCardFromStorage.Name,
                    CreditCardNumber = Base64Decode(savedCreditCardFromStorage.CreditCardNumber),
                    CvcNumber = Base64Decode(savedCreditCardFromStorage.CvcNumber),
                    ExpiryDate = Base64Decode(savedCreditCardFromStorage.ExpiryDate)
                };
            }

            return new ObjectResult(new { error = "Invalid credit card." })
            {
                StatusCode = 422
            };
        }

        public async Task<CreditCard> GetCreditCardByIdAsync(int id)
        {
            //TODO: await Get credit Card details by "id" from storage 

            CreditCard creditCardByIdFromStorage = new CreditCard()
            {
                Id = 1,
                Name = "Kawindu",
                CreditCardNumber = "NTU1NTM0MTI0NDQ0MTExNQ==",
                CvcNumber = "MzAz",
                ExpiryDate = "MTIvMjAyMA=="
            };

            return new CreditCard()
            {
                Id = creditCardByIdFromStorage.Id,
                Name = creditCardByIdFromStorage.Name,
                CreditCardNumber = Base64Decode(creditCardByIdFromStorage.CreditCardNumber),
                CvcNumber = Base64Decode(creditCardByIdFromStorage.CvcNumber),
                ExpiryDate = Base64Decode(creditCardByIdFromStorage.ExpiryDate)
            };
        }

        public async Task<IEnumerable<CreditCard>> GetCreditCardsAsync()
        {
            //TODO: await Get all credit Cards from storage 

            List<CreditCard> decodeCreditCards = new();

            List<CreditCard> creditCards = new()
            {
                new CreditCard()
                {
                    Id = 1,
                    Name = "Kawindu",
                    CreditCardNumber = "NTU1NTM0MTI0NDQ0MTExNQ==",
                    CvcNumber = "MzAz",
                    ExpiryDate = "MTIvMjAyMA=="
                },
                new CreditCard()
                {
                    Id = 1,
                    Name = "Kawindu",
                    CreditCardNumber = "NTU1NTM0MTI0NDQ0MTExNQ==",
                    CvcNumber = "MzAz",
                    ExpiryDate = "MTIvMjAyMA=="
                }
            };

            foreach (CreditCard encodeCreditCard in creditCards)
            {
                decodeCreditCards.Add(new CreditCard()
                {
                    Id = encodeCreditCard.Id,
                    Name = encodeCreditCard.Name,
                    CreditCardNumber = Base64Decode(encodeCreditCard.CreditCardNumber),
                    CvcNumber = Base64Decode(encodeCreditCard.CvcNumber),
                    ExpiryDate = Base64Decode(encodeCreditCard.ExpiryDate)
                });
            }

            return decodeCreditCards;
        }

        private string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private string Base64Decode(string encodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(encodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private bool IsCreditCardNumberValid(string creditCardNumber)
        {
            var attribute = new CreditCardAttribute();
            return attribute.IsValid(creditCardNumber);
        }

        private bool IsCreditCardExpired(string expiryDate)
        {
            try
            {
                var separatedExpiryDate = expiryDate.Split('/');
                var year = int.Parse(separatedExpiryDate[1]);
                var month = int.Parse(separatedExpiryDate[0]);
                var numberDays = DateTime.DaysInMonth(year, month);
                var cardExpiry = new DateTime(year, month, numberDays, 23, 59, 59);
                return cardExpiry > DateTime.Now;
            }
            catch (Exception)
            {
                //TODO: logging the exception 
                return true;
            }

        }
    }
}
