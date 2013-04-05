using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APFTestingModel;
using System.ComponentModel.DataAnnotations;

namespace APFTestingUI.Models.Practical
{
    public class PackerEdit
    {
        public PackerEdit() {
            buildSelectLists();
        }

        public PackerEdit(Guid examId, IAssessmentTaskPacker pack)
        {
            ExamId = examId;
            PackId = pack.Id;
            Date = pack.Date.ToShortDateString();
            var canopyTypeComparisonList = Enum.GetValues(typeof(CanopyTypes)).Cast<CanopyTypes>().Select(e => e.ToString()).ToList();
            if (canopyTypeComparisonList.Contains(pack.CanopyType))
            {
                CanopyType = pack.CanopyType;
            }
            else
            {
                CanopyType = "Other";
                CanopyTypeOther = pack.CanopyType;
            }
            CanopyTypeSerialNumber = pack.CanopyTypeSerialNumber;
            var harnessContainerTypeComparisonList = Enum.GetValues(typeof(HarnessContainerTypes)).Cast<HarnessContainerTypes>().Select(e => e.ToString()).ToList();
            if (harnessContainerTypeComparisonList.Contains(pack.HarnessContainerType)) 
            {
                HarnessContainerType = pack.HarnessContainerType;
            }
            else 
            {
                HarnessContainerType = "Other";
                HarnessContainerTypeOther = pack.HarnessContainerType;
            }
            HarnessContainerSerialNumber = pack.HarnessContainerSerialNumber;
            Note = pack.Note;
            SupervisorId = pack.SupervisorId;

            buildSelectLists();
        }

        public Guid ExamId { get; set; }

        [Required]
        public Guid PackId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string Date { get; set; }

        [Required]
        [Display(Name="Canopy Type")]
        public string CanopyType { get; set; }
        public SelectList CanopyTypeList { get; set; }
        public string CanopyTypeOther { get; set; }

        [Required]
        [Display(Name = "Canopy Serial No.")]
        public string CanopyTypeSerialNumber { get; set; }

        [Required]
        [Display(Name = "Harness/Container Type")]
        public string HarnessContainerType { get; set; }
        public SelectList HarnessContainerTypeList { get; set; }
        public string HarnessContainerTypeOther { get; set; }

        [Required]
        [Display(Name = "Harness/Container Serial No.")]
        public string HarnessContainerSerialNumber { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Note { get; set; }

        [Required]
        [Display(Name = "Intructor/Rigger No.")]
        public string SupervisorId { get; set; }

        public PackerPracticalResult Values
        {
            get
            {
                return new PackerPracticalResult
                {
                    Date = DateTime.Parse(Date),
                    CanopyType = CanopyType,
                    CanopyTypeSerialNumber = CanopyTypeSerialNumber,
                    HarnessContainerType = HarnessContainerType,
                    HarnessContainerSerialNumber = HarnessContainerSerialNumber,
                    Note = Note,
                    SupervisorId = SupervisorId
                };
            }
        }

        private void buildSelectLists()
        {
            var canopyList = Enum.GetValues(typeof(CanopyTypes));
            var harnessList = Enum.GetValues(typeof(HarnessContainerTypes));

            CanopyTypeList = new SelectList(canopyList, CanopyType);
            HarnessContainerTypeList = new SelectList(harnessList, HarnessContainerType);
        }
    }
}