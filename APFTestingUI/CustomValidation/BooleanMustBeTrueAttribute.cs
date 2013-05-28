using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APFTestingUI
{
    public class BooleanMustBeTrueAttribute : ValidationAttribute
    {
        public override bool IsValid(object propertyValue)
        {
            return propertyValue != null
                && propertyValue is bool
                && (bool)propertyValue;
        }
    }
}