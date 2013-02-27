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
    
    public partial class TheoryComponent
    {
        public TheoryComponent()
        {
            this.Exams = new HashSet<Exam>();
            this.SelectedOptions = new HashSet<SelectedOption>();
            this.Questions = new HashSet<Question>();
        }
    
        public System.Guid Id { get; set; }
        public System.Guid ExaminerId { get; set; }
        public System.Guid FormatId { get; set; }
    
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<SelectedOption> SelectedOptions { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual TheoryComponentFormat TheoryComponentFormat { get; set; }
        public virtual Examiner Examiner { get; set; }
    }
}
