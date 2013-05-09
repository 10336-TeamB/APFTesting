using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APFTestingModel;

namespace APFTestingUI.Areas.Administration.Models.ExaminerManagement
{
    public class Index
    {
        public IEnumerable<IExaminer> Examiners { get; set; }

        public Index(IEnumerable<IExaminer> examiners)
        {
            Examiners = examiners;
        }
    }
}