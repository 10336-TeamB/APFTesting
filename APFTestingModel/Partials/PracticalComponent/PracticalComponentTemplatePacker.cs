using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class PracticalComponentTemplatePacker : IPracticalComponentTemplatePacker
    {

        #region Constructors

        public PracticalComponentTemplatePacker(int numOfRequiredAssessmentTasks)
        {
            NumOfRequiredAssessmentTasks = numOfRequiredAssessmentTasks;
        }

        #endregion



        #region Properties

        public bool AllowEditOrDelete
        {
            get { return PracticalComponentPackers.Count == 0 && !IsActive; }
        }

        #endregion



        #region Methods

        internal void Edit(int numOfRequiredAssessmentTasks)
        {
            if (!AllowEditOrDelete)
            {
                throw new BusinessRuleException("Can not edit a template that is active or has been used.");
            }
            NumOfRequiredAssessmentTasks = numOfRequiredAssessmentTasks;
        }

        internal void Delete(deleteEntityDelegate<PracticalComponentTemplatePacker> deleteEntity)
        {
            if (!AllowEditOrDelete)
            {
                throw new BusinessRuleException("Can not delete a template that is active or has been used.");
            }
            deleteEntity(this);
        }

        internal bool Activate()
        {
            IsActive = true;
            return IsActive;
        }

        internal bool Deactivate()
        {
            IsActive = false;
            return !IsActive;
        }

        #endregion
        
    }
}
