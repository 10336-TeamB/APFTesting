
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
    
internal partial class Administrator : Person
{

	public int UserId { get; set; }

	public Nullable<int> EFRequired { get; set; }



    public virtual User User { get; set; }

}

}
