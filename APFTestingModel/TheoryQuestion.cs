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
    
    internal abstract partial class TheoryQuestion
    {
        public TheoryQuestion()
        {
            this.SelectedTheoryQuestions = new HashSet<SelectedTheoryQuestion>();
            this.PossibleAnswers = new HashSet<PossibleAnswer>();
        }
    
        public System.Guid Id { get; set; }
        public int NumberOfCorrectAnswers { get; set; }
        public bool IsActive { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<SelectedTheoryQuestion> SelectedTheoryQuestions { get; set; }
        public virtual ICollection<PossibleAnswer> PossibleAnswers { get; set; }
    }
}