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
    
    internal partial class CandidatePacker : Person
    {
        public CandidatePacker()
        {
            this.ExamPackers = new HashSet<ExamPacker>();
        }
    
    	public string APFNumber { get; set; }
    	public System.Guid CreatedBy { get; set; }
    
        public virtual Examiner Examiner { get; set; }
        public virtual ICollection<ExamPacker> ExamPackers { get; set; }
    }
}
