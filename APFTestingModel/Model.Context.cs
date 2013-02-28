﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class APFTestingEntities : DbContext
    {
        public APFTestingEntities()
            : base("name=APFTestingEntities")
        {
    		Candidates = Set<Candidate>();	
    		Exams = Set<Exam>();	
    		Examiners = Set<Examiner>();	
    		PossibleAnswers = Set<PossibleAnswer>();	
    		PracticalComponents = Set<PracticalComponent>();	
    		PracticalComponentItems = Set<PracticalComponentItem>();	
    		PracticalComponentItemResults = Set<PracticalComponentItemResult>();	
    		PracticalComponentTemplates = Set<PracticalComponentTemplate>();	
    		SelectedAnswers = Set<SelectedAnswer>();	
    		TheoryComponents = Set<TheoryComponent>();	
    		TheoryComponentFormats = Set<TheoryComponentFormat>();	
    		TheoryQuestions = Set<TheoryQuestion>();	
    
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        internal DbSet<Candidate> Candidates { get; set; }
        internal DbSet<Exam> Exams { get; set; }
        internal DbSet<Examiner> Examiners { get; set; }
        internal DbSet<PossibleAnswer> PossibleAnswers { get; set; }
        internal DbSet<PracticalComponent> PracticalComponents { get; set; }
        internal DbSet<PracticalComponentItem> PracticalComponentItems { get; set; }
        internal DbSet<PracticalComponentItemResult> PracticalComponentItemResults { get; set; }
        internal DbSet<PracticalComponentTemplate> PracticalComponentTemplates { get; set; }
        internal DbSet<SelectedAnswer> SelectedAnswers { get; set; }
        internal DbSet<TheoryComponent> TheoryComponents { get; set; }
        internal DbSet<TheoryComponentFormat> TheoryComponentFormats { get; set; }
        internal DbSet<TheoryQuestion> TheoryQuestions { get; set; }
    }
}
