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
    
    public partial class PracticalComponentTemplate
    {
        public PracticalComponentTemplate()
        {
            this.PracticalComponents = new HashSet<PracticalComponent>();
            this.PracticalComponentItems = new HashSet<PracticalComponentItem>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<int> ExamTypeId { get; set; }
    
        public virtual ICollection<PracticalComponent> PracticalComponents { get; set; }
        public virtual ICollection<PracticalComponentItem> PracticalComponentItems { get; set; }
    }
}
