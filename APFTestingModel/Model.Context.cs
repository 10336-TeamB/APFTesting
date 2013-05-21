﻿

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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class APFTestingDBEntities : DbContext
{
    public APFTestingDBEntities()
        : base("name=APFTestingDBEntities")
    {
	
		Addresses = Set<Address>();	

		Answers = Set<Answer>();	

		AssessmentTasks = Set<AssessmentTask>();	

		Exams = Set<Exam>();	

		People = Set<Person>();	

		PossibleAnswers = Set<PossibleAnswer>();	

		PracticalComponents = Set<PracticalComponent>();	

		PracticalComponentTemplates = Set<PracticalComponentTemplate>();	

		SelectedAssessmentTasks = Set<SelectedAssessmentTask>();	

		SelectedTheoryQuestions = Set<SelectedTheoryQuestion>();	

		TheoryComponents = Set<TheoryComponent>();	

		TheoryComponentFormats = Set<TheoryComponentFormat>();	

		TheoryQuestions = Set<TheoryQuestion>();	

		ExaminerAuthorities = Set<ExaminerAuthority>();	

		Users = Set<User>();	



    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    internal DbSet<Address> Addresses { get; set; }

    internal DbSet<Answer> Answers { get; set; }

    internal DbSet<AssessmentTask> AssessmentTasks { get; set; }

    internal DbSet<Exam> Exams { get; set; }

    internal DbSet<Person> People { get; set; }

    internal DbSet<PossibleAnswer> PossibleAnswers { get; set; }

    internal DbSet<PracticalComponent> PracticalComponents { get; set; }

    internal DbSet<PracticalComponentTemplate> PracticalComponentTemplates { get; set; }

    internal DbSet<SelectedAssessmentTask> SelectedAssessmentTasks { get; set; }

    internal DbSet<SelectedTheoryQuestion> SelectedTheoryQuestions { get; set; }

    internal DbSet<TheoryComponent> TheoryComponents { get; set; }

    internal DbSet<TheoryComponentFormat> TheoryComponentFormats { get; set; }

    internal DbSet<TheoryQuestion> TheoryQuestions { get; set; }

    internal DbSet<ExaminerAuthority> ExaminerAuthorities { get; set; }

    internal DbSet<User> Users { get; set; }

}

}

