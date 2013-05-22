using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EmailService
{
    [DataContract]
    public class EmailDataContract
    {
        [DataMember]
        public List<KeyValuePair<string, string>> Exam { get; set; }

        [DataMember]
        public int ExamType { get; set; }

        [DataMember]
        public string ToAddress { get; set; }

        [DataMember]
        public string Body { get; set; }

        [DataMember]
        public string Subject { get; set; }

        [DataMember]
        public Guid ExamId {get; set; }
    }
}