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
    
    internal partial class AssessmentTaskPilot : AssessmentTask
    {
        public AssessmentTaskPilot()
        {
            this.SelectedAssessmentTasks = new HashSet<SelectedAssessmentTask>();
            this.PracticalComponentTemplatePilots = new HashSet<PracticalComponentTemplatePilot>();
        }
    
    	public string Title { get; set; }
    	public string Details { get; set; }
    	public int MaxScore { get; set; }
    
        public virtual ICollection<SelectedAssessmentTask> SelectedAssessmentTasks { get; set; }
        public virtual ICollection<PracticalComponentTemplatePilot> PracticalComponentTemplatePilots { get; set; }
    }
}
