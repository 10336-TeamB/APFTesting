using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APFTestingUI.Models.Practical
{
    public class DemonstratedPackDisplayItem
    {
        public DemonstratedPackDisplayItem(IAssessmentTaskPacker pack)
        {
            Id = pack.Id;
            Date = pack.Date.ToShortDateString();
            CanopyType = pack.CanopyType;
            //CanopyTypeSerialNumber = pack.CanopyTypeSerialNumber;
            HarnessContainerType = pack.HarnessContainerType;
            //HarnessContainerSerialNumber = pack.HarnessContainerSerialNumber;
            Note = pack.Note;
            SupervisorId = pack.SupervisorId;
        }

        public Guid Id { get; set; }
        public string Date { get; set; }
        public string CanopyType { get; set; }
        //public string CanopyTypeSerialNumber { get; set; }
        public string HarnessContainerType { get; set; }
        //public string HarnessContainerSerialNumber { get; set; }
        public string Note { get; set; }
        public string SupervisorId { get; set; }
    }
}
