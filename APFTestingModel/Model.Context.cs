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
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Exam> Exams { get; set; }
        public DbSet<PossibleAnswer> PossibleAnswers { get; set; }
        public DbSet<PracticalComponent> PracticalComponents { get; set; }
        public DbSet<PracticalComponentItem> PracticalComponentItems { get; set; }
        public DbSet<PracticalComponentItemResult> PracticalComponentItemResults { get; set; }
        public DbSet<PracticalComponentTemplate> PracticalComponentTemplates { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<SelectedOption> SelectedOptions { get; set; }
        public DbSet<TheoryComponent> TheoryComponents { get; set; }
        public DbSet<TheoryComponentFormat> TheoryComponentFormats { get; set; }
        public DbSet<Examiner> Examiners { get; set; }
        public DbSet<Candidate> Candidates { get; set; }

    }
}
