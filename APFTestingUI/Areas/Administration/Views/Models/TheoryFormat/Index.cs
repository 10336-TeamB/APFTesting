using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Areas.Administration.Models.TheoryFormat
{
    public class Index
    {
        public Index(ITheoryComponentFormat[][] formats)
        {
            for (var typeIndex = 0; typeIndex < formats.Length; typeIndex++)
            {
                var tempList = new List<FormatDisplayItem>();
                for (var i = 0; i < formats[typeIndex].Length; i++)
                {
                    tempList.Add(new FormatDisplayItem(formats[typeIndex][i]));
                }
                if (typeIndex == 0)
                {
                    PilotFormats = tempList;
                }
                else
                {
                    PackerFormats = tempList;
                }
            }
        }

        public IEnumerable<FormatDisplayItem> PilotFormats { get; set; }
        public IEnumerable<FormatDisplayItem> PackerFormats { get; set; }
    }
}