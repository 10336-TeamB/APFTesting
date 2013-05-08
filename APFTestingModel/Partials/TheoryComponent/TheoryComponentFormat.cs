using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal abstract partial class TheoryComponentFormat : ITheoryComponentFormat
    {
        public TheoryComponentFormat(int numberOfQuestions, int passMark, int timeLimit)
        {
            NumberOfQuestions = numberOfQuestions;
            PassMark = passMark;
            TimeLimit = timeLimit;
        }

        public bool AllowEditOrDelete
        {
            get
            {
                return (TheoryComponents.Count == 0 && !IsActive);
            }
        }

        public void Edit(int numberOfQuestions, int passMark, int timeLimit)
        {
            // Check if active
            if (IsActive)
            {
                throw new BusinessRuleException("Error: Cannot edit an active template");
            }

            //Check if any associations
            if (!AllowEditOrDelete)
            {
                throw new BusinessRuleException("Error: Can not edit template that has been used");
            }

            //If no associations then edit
            NumberOfQuestions = numberOfQuestions;
            PassMark = passMark;
            TimeLimit = timeLimit;
        }

        public void Delete(Facade facade)
        {
            if (IsActive)
            {
                throw new BusinessRuleException("Error: Cannot delete an active template");
            }
            if (!AllowEditOrDelete)
            {
                throw new BusinessRuleException("Error: Can not delete template that has been used");
            }
            facade.deleteTheoryExamFormat(this);
        }

        public bool Activate()
        {
            IsActive = true;
            return IsActive;
        }
        public bool Deactivate()
        {
            IsActive = false;
            return !IsActive;
        }
    }
}
