
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
    
internal partial class PracticalComponentPacker : PracticalComponent
{

    public PracticalComponentPacker()
    {

        this.AssessmentTaskPackers = new HashSet<AssessmentTaskPacker>();

    }




    public virtual ICollection<AssessmentTaskPacker> AssessmentTaskPackers { get; set; }

}

}
