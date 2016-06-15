using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ValidationDemo.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UppercaseAttribute : ValidationAttribute, IClientValidatable
    {
        public override string FormatErrorMessage(string name)
        {
            if (string.IsNullOrEmpty(base.ErrorMessage))
            {
                return $"The field '{name}' must be in uppercase.";
            }
            else {
                return base.FormatErrorMessage(name);
            }
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "uppercase"
            };

            yield return rule;
        }

        public override bool IsValid(object value)
        {
            var text = value as string;
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            return text == text.ToUpper();
        }
    }
}