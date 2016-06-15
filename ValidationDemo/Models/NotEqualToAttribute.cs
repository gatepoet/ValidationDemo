using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ValidationDemo.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NotEqualToAttribute : ValidationAttribute, IClientValidatable
    {
        public string OtherProperty { get; set; }

        public NotEqualToAttribute(string otherProperty)
        {
            OtherProperty = otherProperty;
        }

        public override string FormatErrorMessage(string name)
        {
            if (string.IsNullOrEmpty(base.ErrorMessage))
            {
                return $"The field '{name}' cannot be equal to '{OtherProperty}'.";
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
                ValidationType = "notequalto"
            };

            rule.ValidationParameters.Add("otherproperty", OtherProperty);

            yield return rule;
        }

        public override bool RequiresValidationContext
        {
            get
            {
                return true;
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyValue = validationContext.ObjectType.GetProperty(OtherProperty)
                .GetValue(validationContext.ObjectInstance);

            if (value.Equals(otherPropertyValue))
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return null;
        }
    }
}