
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
    
internal partial class PracticalComponentTemplatePilot : PracticalComponentTemplate
{

    public PracticalComponentTemplatePilot()
    {

        this.AssessmentTaskPilots = new HashSet<AssessmentTaskPilot>();

        this.PracticalComponentPilots = new HashSet<PracticalComponentPilot>();

    }




    public virtual ICollection<AssessmentTaskPilot> AssessmentTaskPilots { get; set; }

    public virtual ICollection<PracticalComponentPilot> PracticalComponentPilots { get; set; }

}

}
