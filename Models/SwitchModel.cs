using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace EJ2CoreSampleBrowser.Models
{
	public class SwitchModel
    {
        [SwitchCheck]
        public bool check { get; set; }
    }

    public class SwitchCheck : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            SwitchModel model = (SwitchModel)validationContext.ObjectInstance;

            if (model.check != true)
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
        private string GetErrorMessage()
        {
            return $"You need to agree to receive newsletter";
        }
    }
}