using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace APFTestingModel
{
    /// <summary>
    /// Business rule exception
    /// </summary>
    [Serializable]
    public class BusinessRuleException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessRuleException()
            : base()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Exception message</param>
        public BusinessRuleException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="ex">Inner exception</param>
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
