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
    
    internal abstract partial class TheoryComponent
    {
        public TheoryComponent()
        {
            this.Exams = new HashSet<Exam>();
            this.SelectedTheoryQuestions = new HashSet<SelectedTheoryQuestion>();
        }
    
        public System.Guid Id { get; set; }
        public System.Guid FormatId { get; set; }
        public int CurrentQuestionIndex { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<SelectedTheoryQuestion> SelectedTheoryQuestions { get; set; }
        public virtual TheoryComponentFormat TheoryComponentFormat { get; set; }
    }
}
