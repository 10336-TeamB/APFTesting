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
    
    internal partial class Answer
    {
        public Answer()
        {
            this.PossibleAnswers = new HashSet<PossibleAnswer>();
        }
    
        public System.Guid Id { get; set; }
        public System.Guid TheoryQuestionId { get; set; }
        public bool IsCorrect { get; set; }
        public int DisplayOrderIndex { get; set; }
        public string Description { get; set; }
    
        public virtual TheoryQuestion TheoryQuestion { get; set; }
        public virtual ICollection<PossibleAnswer> PossibleAnswers { get; set; }
    }
}