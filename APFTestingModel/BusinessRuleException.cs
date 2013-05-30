using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace APFTestingModel
{
    [Serializable]
    public class BusinessRuleException : Exception
    {
        public BusinessRuleException()
            : base()
        {
        }

        public BusinessRuleException(string message)
            : base(message)
        {
        }

        public BusinessRuleException(string message, Exception ex)
            : base(message, ex)
        {
        }

        protected BusinessRuleException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
