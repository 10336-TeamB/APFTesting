using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APFTestingModel;

namespace APFTestingUI.Areas.Administration.Models.TheoryFormat
{
    public class FormatDisplayItem
    {
        public FormatDisplayItem(ITheoryComponentFormat format)
        {
            Id = format.Id;
            NumberOfQuestions = format.NumberOfQuestions;
            PassMark = format.PassMark;
            IsActive = format.IsActive;
            TimeLimit = format.TimeLimit;
            AllowEditOrDelete = format.AllowEditOrDelete;
        }

        public Guid Id { get; set; }
        public int NumberOfQuestions { get; set; }
        public int PassMark { get; set; }
        public bool IsActive { get; set; }
        public int TimeLimit { get; set; }
        public bool AllowEditOrDelete { get; set; }
    }
}