using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace EJ2CoreSampleBrowser.Models
{
	public class CheckBoxModel
    {
        [Check]
        public bool check { get; set; }
    }

    public class Check : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            CheckBoxModel model = (CheckBoxModel)validationContext.ObjectInstance;

            if (model.check != true)
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
        private string GetErrorMessage()
        {
            return $"You need to agree to the Terms and Conditions";
        }
    }
}