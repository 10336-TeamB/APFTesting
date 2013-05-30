using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Models.Practical
{
    public class PackerView
    {
        public PackerView(Guid examId, IEnumerable<IAssessmentTaskPacker> packs, bool isCompetent, int requiredNumberOfTasks) 
        {
            ExamId = examId;
            Packs = packs.Select(p => new DemonstratedPackDisplayItem(p)).ToList().OrderBy(p => p.Date);
            IsCompetent = isCompetent;
            TasksRemaining = requiredNumberOfTasks - Packs.Count();
            if (TasksRemaining<0)
            {
                TasksRemaining = 0;
            }
        }

        public Guid ExamId { get; set; }
        public IEnumerable<DemonstratedPackDisplayItem> Packs { get; set; }
        public bool IsCompetent { get; set; }
        public int TasksRemaining { get; set; }

    }
}