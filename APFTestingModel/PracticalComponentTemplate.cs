
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
    
internal abstract partial class PracticalComponentTemplate
{

    public PracticalComponentTemplate()
    {

        this.PracticalComponents = new HashSet<PracticalComponent>();

    }


	public System.Guid Id { get; set; }

	public bool IsActive { get; set; }



    public virtual ICollection<PracticalComponent> PracticalComponents { get; set; }

}

}
