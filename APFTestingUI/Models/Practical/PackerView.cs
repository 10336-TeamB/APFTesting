using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Models.Practical
{
    public class PackerView
    {
        public PackerView(Guid examId, IEnumerable<IAssessmentTaskPacker> packs) 
        {
            ExamId = examId;
            Packs = packs.Select(p => new DemonstratedPackDisplayItem(p));
        }

        public Guid ExamId { get; set; }
        public IEnumerable<DemonstratedPackDisplayItem> Packs { get; set; }
    }
}