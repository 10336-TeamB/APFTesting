
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
    
internal partial class Address
{

    public Address()
    {

        this.CandidatePilots = new HashSet<CandidatePilot>();

    }


	public System.Guid Id { get; set; }

	public string Address1 { get; set; }

	public string Address2 { get; set; }

	public string Suburb { get; set; }

	public string State { get; set; }

	public string Postcode { get; set; }



    public virtual ICollection<CandidatePilot> CandidatePilots { get; set; }

}

}
