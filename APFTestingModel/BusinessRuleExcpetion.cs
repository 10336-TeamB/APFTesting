using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APFTestingModel
{
    public class BusinessRuleExcpetion : ApplicationException
    {
        public BusinessRuleExcpetion(string message)
            : base(message)
        {
        }
    }
}
