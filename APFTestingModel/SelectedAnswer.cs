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
    
    internal partial class SelectedAnswer
    {
        public System.Guid Id { get; set; }
        public System.Guid SelectedTheoryQuestionId { get; set; }
        public System.Guid PossibleAnswerId { get; set; }
        public System.DateTime SelectedTime { get; set; }
        public bool IsChecked { get; set; }
    
        public virtual PossibleAnswer PossibleAnswer { get; set; }
        public virtual SelectedTheoryQuestion SelectedTheoryQuestion { get; set; }
    }
}
