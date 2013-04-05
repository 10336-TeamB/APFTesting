using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APFTestingModel;
using System.ComponentModel.DataAnnotations;

namespace APFTestingUI.Models.Practical
{
    public class PackerInput
    {
        public PackerInput() {
            buildSelectLists();
        }

        public PackerInput(Guid examId)
        {
            ExamId = examId;
            buildSelectLists();
        }

        public Guid ExamId { get; set; }

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
                    CanopyType = CanopyType.Equals("Other") ? CanopyTypeOther : CanopyType,
                    CanopyTypeSerialNumber = CanopyTypeSerialNumber,
                    HarnessContainerType = HarnessContainerType.Equals("Other") ? HarnessContainerTypeOther : HarnessContainerType,
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

            CanopyTypeList = new SelectList(canopyList);
            HarnessContainerTypeList = new SelectList(harnessList);
        }
    }
}