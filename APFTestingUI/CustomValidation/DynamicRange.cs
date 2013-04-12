using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace APFTestingUI
{
    public class DynamicRange : ValidationAttribute, IClientValidatable
    {
        private string _maxValueName;

        public DynamicRange(string maxValue)
        {
            _maxValueName = maxValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var maxValueProperty = validationContext.ObjectType.GetProperty(_maxValueName);
            
            if (maxValueProperty == null)
            {
                return new ValidationResult(string.Format("Unknown property {0}", maxValueProperty));
            }

            int maxValue = (int)maxValueProperty.GetValue(validationContext.ObjectInstance, null);
            int intValue = Int32.Parse((string)value);
            if (maxValue < intValue || intValue < 0)
            {
                return new ValidationResult(string.Format(ErrorMessage, maxValue));
            }

            return null;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ValidationType = "dynamicrange",
                ErrorMessage = this.ErrorMessage,
            };
           
            rule.ValidationParameters["maxvalueproperty"] = _maxValueName;
            yield return rule;
        }

    }
}