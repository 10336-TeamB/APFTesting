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

        public PackerEdit(Guid examId, IAssessmentTaskPacker task)
        {
            ExamId = examId;
            TaskId = task.Id;
            Date = task.Date.ToShortDateString();
            var canopyTypeComparisonList = Enum.GetValues(typeof(CanopyTypes)).Cast<CanopyTypes>().Select(e => e.ToString()).ToList();
            if (canopyTypeComparisonList.Contains(task.CanopyType))
            {
                CanopyType = task.CanopyType;
            }
            else
            {
                CanopyType = "Other";
                CanopyTypeOther = task.CanopyType;
            }
            //CanopyTypeSerialNumber = task.CanopyTypeSerialNumber;
            var harnessContainerTypeComparisonList = Enum.GetValues(typeof(HarnessContainerTypes)).Cast<HarnessContainerTypes>().Select(e => e.ToString()).ToList();
            if (harnessContainerTypeComparisonList.Contains(task.HarnessContainerType)) 
            {
                HarnessContainerType = task.HarnessContainerType;
            }
            else 
            {
                HarnessContainerType = "Other";
                HarnessContainerTypeOther = task.HarnessContainerType;
            }
            //HarnessContainerSerialNumber = task.HarnessContainerSerialNumber;
            Note = task.Note;
            SupervisorId = task.SupervisorId;

            buildSelectLists();
        }

        public Guid ExamId { get; set; }

        [Required]
        public Guid TaskId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string Date { get; set; }

        [Required]
        [Display(Name="Canopy Type")]
        public string CanopyType { get; set; }
        public SelectList CanopyTypeList { get; set; }
        public string CanopyTypeOther { get; set; }

        //[Required]
        //[Display(Name = "Canopy Serial No.")]
        //public string CanopyTypeSerialNumber { get; set; }

        [Required]
        [Display(Name = "Harness/Container Type")]
        public string HarnessContainerType { get; set; }
        public SelectList HarnessContainerTypeList { get; set; }
        public string HarnessContainerTypeOther { get; set; }

        //[Required]
        //[Display(Name = "Harness/Container Serial No.")]
        //public string HarnessContainerSerialNumber { get; set; }

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
                    //CanopyTypeSerialNumber = CanopyTypeSerialNumber,
                    HarnessContainerType = HarnessContainerType.Equals("Other") ? HarnessContainerTypeOther : HarnessContainerType,
                    //HarnessContainerSerialNumber = HarnessContainerSerialNumber,
                    Note = Note,
                    SupervisorId = SupervisorId
                };
            }
        }

        private void buildSelectLists()
        {
            var canopyList = Enum.GetValues(typeof(CanopyTypes)).Cast<CanopyTypes>().Select(e => e.ToString()).ToList();
            var canopyListValueText = new List<KeyValuePair<string, string>>();
            foreach (var c in canopyList)
            {
                var itemKey = c;
                var itemValue = c;
                if (c.Equals("RamAir"))
                {
                    itemValue = "Ram-Air";
                }
                canopyListValueText.Add(new KeyValuePair<string, string>(itemKey, itemValue));
            }
            
            var harnessList = Enum.GetValues(typeof(HarnessContainerTypes)).Cast<HarnessContainerTypes>().Select(e => e.ToString()).ToList();

            //CanopyTypeList = new SelectList(canopyList.Select(x => new { value = x, text = x }).ToList(), "value", "text", CanopyType);
            CanopyTypeList = new SelectList(canopyListValueText, "Key", "Value", CanopyType);
            HarnessContainerTypeList = new SelectList(harnessList.Select(x => new { value = x, text = x }).ToList(), "value", "text", HarnessContainerType);
        }
    }
}