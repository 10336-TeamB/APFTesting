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
    
    internal partial class AssessmentTaskPacker
    {
        public System.Guid Id { get; set; }
        public System.Guid PracticalComponentId { get; set; }
        public System.DateTime Date { get; set; }
        public string CanopyType { get; set; }
        public string CanopyTypeSerialNumber { get; set; }
        public string SupervisorId { get; set; }
        public string HarnessContainerType { get; set; }
        public string HarnessContainerSerialNumber { get; set; }
        public string Note { get; set; }
    
        public virtual PracticalComponentPacker PracticalComponentPacker { get; set; }
    }
}