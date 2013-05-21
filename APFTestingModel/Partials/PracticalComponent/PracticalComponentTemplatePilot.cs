using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class PracticalComponentTemplatePilot : IPracticalComponentTemplatePilot
    {
        public PracticalComponentTemplatePilot(List<AssessmentTaskPilot> tasks)
        {
            AssessmentTaskPilots = tasks;
        }

        public bool AllowEditOrDelete
        {
            get { return PracticalComponentPilots.Count == 0 && !IsActive; }
        }

        public IEnumerable<IAssessmentTaskPilot> Tasks
        {
            get { return AssessmentTaskPilots; }
        }

        internal void Edit(List<AssessmentTaskPilot> selectedTasks)
        {

            if (!AllowEditOrDelete)
            {
                throw new BusinessRuleException("Can not edit an active or used template");
            }
            List<AssessmentTaskPilot> deleteList = new List<AssessmentTaskPilot>();
            foreach (var task in AssessmentTaskPilots)
            {
                if (selectedTasks.Contains(task))
                {
                    selectedTasks.Remove(task);
                }
                else
                {
                    deleteList.Add(task);
                }
            }
            deleteList.ForEach(t => AssessmentTaskPilots.Remove(t));
            AssessmentTaskPilots = AssessmentTaskPilots.Union(selectedTasks).ToList();
        }
    }
}
