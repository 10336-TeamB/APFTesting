﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal abstract class ExamState
    {
        internal virtual void FetchFirstQuestion(Action action)
        {
            throw new BusinessRuleException("Action is invalid");
        }

        internal virtual void FetchNextQuestion(Action action)
        {
            throw new BusinessRuleException("Action is invalid");
        }

        internal virtual void FetchPreviousQuestion(Action action)
        {
            throw new BusinessRuleException("Action is invalid");
        }

        internal virtual void FetchCurrentQuestion(Action action)
        {
            throw new BusinessRuleException("Action is invalid");
        }

        internal virtual void FetchSpecificQuestion(Action action)
        {
            throw new BusinessRuleException("Action is invalid");
        }

        internal virtual void AnswerQuestion(Action action)
        {
            throw new BusinessRuleException("Action is invalid");
        }

        internal virtual void VoidExam(Action action)
        {
            throw new BusinessRuleException("Action is invalid");
        }

        internal virtual void SubmitTheoryComponent(Action action)
        {
            throw new BusinessRuleException("Action is invalid");
        }

        internal virtual void StartTheoryComponent(Action action)
        {
            throw new BusinessRuleException("Action is invalid");
        }

        internal virtual void FetchTheoryComponentFormat(Action action)
        {
            throw new BusinessRuleException("Action is invalid");
        }

        internal virtual void FetchTheoryExamResult(Action action)
        {
            throw new BusinessRuleException("Action is invalid");
        }

        internal virtual void FetchPracticalExamResult(Action a)
        {
            throw new BusinessRuleException("Action is invalid");
        }

        internal virtual void AddPracticalComponentResult(Action a)
        {
            throw new BusinessRuleException("Action is invalid");
        }

        internal virtual void SubmitPilotPracticalResults(Action action)
        {
            throw new BusinessRuleException("Action is invalid");
        }

        internal virtual void EditPackerPracticalResult(Action action)
        {
            throw new BusinessRuleException("Action is invalid");
        }

        internal virtual void FinalisePractical(Action action)
        {
            throw new BusinessRuleException("Action is invalid");
        }

        internal virtual void FinaliseExam(Action action)
        {
            throw new BusinessRuleException("Action is invalid");
        }

        internal virtual void ArchiveExam(Action action)
        {
            throw new BusinessRuleException("Action is invalid");
        }
        
    }
}
