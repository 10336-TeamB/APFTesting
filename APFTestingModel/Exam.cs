//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APFTestingModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Exam
    {
        public System.Guid Id { get; set; }
        public int ExamStatusId { get; set; }
        public System.Guid TheoryComponentId { get; set; }
        public System.Guid PracticalComponentId { get; set; }
        public System.Guid CandidateId { get; set; }
        public int ExamTypeId { get; set; }
    
        public virtual PracticalComponent PracticalComponent { get; set; }
        public virtual TheoryComponent TheoryComponent { get; set; }
        public virtual Candidate Candidate { get; set; }
    }
}
