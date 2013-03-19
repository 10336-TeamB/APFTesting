using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APFTestingModel
{
    public class BusinessRuleException : ApplicationException
    {
        public BusinessRuleException(string message)
            : base(message)
        {
        }
    }
}
