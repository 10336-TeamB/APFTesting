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
    
        internal DbSet<Exam> Exams { get; set; }
        internal DbSet<PossibleAnswer> PossibleAnswers { get; set; }
        internal DbSet<PracticalComponent> PracticalComponents { get; set; }
        internal DbSet<PracticalComponentItem> PracticalComponentItems { get; set; }
        internal DbSet<PracticalComponentItemResult> PracticalComponentItemResults { get; set; }
        internal DbSet<PracticalComponentTemplate> PracticalComponentTemplates { get; set; }
        internal DbSet<Question> Questions { get; set; }
        internal DbSet<SelectedOption> SelectedOptions { get; set; }
        internal DbSet<TheoryComponent> TheoryComponents { get; set; }
        internal DbSet<TheoryComponentFormat> TheoryComponentFormats { get; set; }
    }
}
