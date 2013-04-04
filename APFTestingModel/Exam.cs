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
    
    internal abstract partial class Exam
    {
    	public System.Guid Id { get; set; }
    	public System.Guid TheoryComponentId { get; set; }
    	public Nullable<System.Guid> PracticalComponentId { get; set; }
    	public Nullable<System.Guid> ExaminerId { get; set; }
        private int _ExamStatusId;
    	public int ExamStatusId { get{ return _ExamStatusId; } set{ _ExamStatusId = value; OnExamStatusIdChanged(); } }
    	partial void OnExamStatusIdChanged();
    	

    	public System.DateTime CreatedDate { get; set; }
    	public short ExamStatus { get; set; }
    
        public virtual Examiner Examiner { get; set; }
        public virtual PracticalComponent PracticalComponent { get; set; }
        public virtual TheoryComponent TheoryComponent { get; set; }
    }
}
