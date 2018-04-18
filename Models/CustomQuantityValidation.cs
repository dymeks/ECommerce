using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce
{
    public class ValidQuantityAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value,object ProductQuantity ,ValidationContext validationContext)
        {
            

            if ((int)value > (int) ProductQuantity)
            {
                return new ValidationResult("There are not enough products to currently buy that many.");
            }

            return ValidationResult.Success;
        }
    }
}