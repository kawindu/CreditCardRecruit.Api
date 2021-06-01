using CreditCardRecruit.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace CreditCardRecruit.Api.Tests.Unit
{
    public class CreditCardTests
    {
        [Fact]
        public void CreateCreditCardAsync_InputInvalidCvcNumber_ReturnInvalidCvcNumber()
        {
            CreditCard creditCard = new CreditCard()
            {
                Name = "Kawindu",
                CreditCardNumber = "5555341244441115",
                CvcNumber = "1213",
                ExpiryDate = "12/2030"
            };

            var lstErrors = ValidateModel(creditCard);
            Assert.True(lstErrors.Where(x => x.ErrorMessage.Contains("Invalid CVC numbers (must be 3 digits).")).Count() > 0);
        }

        [Fact]
        public void CreateCreditCardAsync_InputInvalidExpiryDate_ReturnInvalidExpiryDate()
        {
            CreditCard creditCard = new CreditCard()
            {
                Name = "Kawindu",
                CreditCardNumber = "5555341244441115",
                CvcNumber = "121",
                ExpiryDate = "13/2030"
            };

            var lstErrors = ValidateModel(creditCard);
            Assert.True(lstErrors.Where(x => x.ErrorMessage.Contains("Invalid expiry date (mm/yyyy).")).Count() > 0);
        }

        [Fact]
        public void CreateCreditCardAsync_InputInvalidCreditCardNumber_ReturnInvalidCreditCardNumber()
        {
            //TODO: Write unit test
        }

        [Fact]
        public void CreateCreditCardAsync_InputValidCreditCardNumber_ReturnValidCreditCardNumber()
        {
            //TODO: Write unit test
        }

        [Fact]
        public void CreateCreditCardAsync_InputValidCvcNumber_ReturnValidCvcNumber()
        {
            //TODO: Write unit test
        }

        [Fact]
        public void CreateCreditCardAsync_InputValidExpiryDate_ReturnValidExpiryDate()
        {
            //TODO: Write unit test
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}
