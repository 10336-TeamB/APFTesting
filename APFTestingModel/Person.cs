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
    
    internal abstract partial class Person
    {
    	public System.Guid Id { get; set; }
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    	public System.Guid AddressId { get; set; }
    	public string PhoneNumber { get; set; }
    	public string MobileNumber { get; set; }
    	public string Email { get; set; }
    	public Nullable<System.DateTime> DateOfBirth { get; set; }
    
        public virtual Address Address { get; set; }
    }
}
