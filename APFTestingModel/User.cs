
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
    
internal partial class User
{

    public User()
    {

        this.Administrators = new HashSet<Administrator>();

        this.Examiners = new HashSet<Examiner>();

    }


	public int UserId { get; set; }

	public string UserName { get; set; }



    public virtual ICollection<Administrator> Administrators { get; set; }

    public virtual ICollection<Examiner> Examiners { get; set; }

}

}
