using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Models.Practical
{
    public class PackerView
    {
        public PackerView(Guid examId, IEnumerable<IAssessmentTaskPacker> packs, bool isCompetent) 
        {
            ExamId = examId;
            Packs = packs.Select(p => new DemonstratedPackDisplayItem(p)).ToList().OrderBy(p => p.Date);
            IsCompetent = isCompetent;
        }

        public Guid ExamId { get; set; }
        public IEnumerable<DemonstratedPackDisplayItem> Packs { get; set; }
        public bool IsCompetent { get; set; }

    }
}