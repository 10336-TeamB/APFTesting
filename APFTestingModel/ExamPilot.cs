
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
    
internal partial class ExamPilot : Exam
{

	public Nullable<System.Guid> CandidateId { get; set; }

	public System.Guid PracticalComponentId { get; set; }



    public virtual CandidatePilot CandidatePilot { get; set; }

    public virtual PracticalComponentPilot PracticalComponentPilot { get; set; }

}

}
