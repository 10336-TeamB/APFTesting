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

        public void Edit(int numberOfQuestions, int passMark, int timeLimit, int availableQuestions)
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

            // Validate new details
            validateExamFormatDetails(numberOfQuestions, passMark, timeLimit, availableQuestions);
            // If no associations and new details are valid then edit
            NumberOfQuestions = numberOfQuestions;
            PassMark = passMark;
            TimeLimit = timeLimit;
        }

        private void validateExamFormatDetails(int numberOfQuestions, int passMark, int timeLimit, int availableQuestions)
        {
            if (numberOfQuestions <= 0)
            {
                throw new BusinessRuleException("Theory exam format must have at least one question.");
            }
            if (numberOfQuestions > availableQuestions)
            {
                throw new BusinessRuleException(String.Format("Format cannot have {0} questions. Only {1} questions are available", numberOfQuestions, availableQuestions));
            }
            if (passMark <= 0 || passMark > 100)
            {
                throw new BusinessRuleException("Pass mark must be between 0 and 100.");
            }
            if (timeLimit < 0 || timeLimit > 120)
            {
                throw new BusinessRuleException("Time limit must be between 0 and 120 minutes.");
            }
        }

        public void Delete(deleteEntityDelegate<TheoryComponentFormat> delete)
        {
            if (IsActive)
            {
                throw new BusinessRuleException("Cannot delete an active template");
            }
            if (!AllowEditOrDelete)
            {
                throw new BusinessRuleException("Cannot delete template that has been used");
            }
            delete(this);
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
