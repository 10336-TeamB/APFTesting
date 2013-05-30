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
            //This does not generate value property for each option
            //var canopyList = Enum.GetValues(typeof(CanopyType));
            //var harnessList = Enum.GetValues(typeof(HarnessContainerType));

            //CanopyTypeList = new SelectList(canopyList);
            //HarnessContainerTypeList = new SelectList(harnessList);

            var canopyList = Enum.GetValues(typeof(CanopyType)).Cast<CanopyType>().Select(e => e.ToString()).ToList();
            var canopyListValueText = new List<KeyValuePair<string, string>>();
            foreach(var c in canopyList)
            {
                var itemKey = c;
                var itemValue = c;
                if(c.Equals("RamAir"))
                {
                    itemValue = "Ram Air";
                }
                canopyListValueText.Add(new KeyValuePair<string, string>(itemKey, itemValue));
            }
            var harnessList = Enum.GetValues(typeof(HarnessContainerType)).Cast<HarnessContainerType>().Select(e => e.ToString()).ToList();
            //CanopyTypeList = new SelectList(canopyList.Select(x => new { value = x, text = x }).ToList(), "value", "text", CanopyType);
            CanopyTypeList = new SelectList(canopyListValueText, "Key", "Value");

            HarnessContainerTypeList = new SelectList(harnessList.Select(x => new { value = x, text = x }).ToList(), "value", "text", HarnessContainerType);
        }
    }
}