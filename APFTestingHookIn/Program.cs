using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APFTestingServices;
using System.IO;

namespace APFTestingHookIn
{
    class Program
    {
        static void Main(string[] args)
        {
            PDFGenerator pdf = new PDFGenerator();

            List<KeyValuePair<string, string>> examDetails = new List<KeyValuePair<string, string>>();

            examDetails.Add(new KeyValuePair<string, string>("Name", String.Format("{0} {1}", "John", "Carmack")));
            examDetails.Add(new KeyValuePair<string, string>("D.O.B.", "20/08/1970"));
            examDetails.Add(new KeyValuePair<string, string>("ARN", "654123"));
            examDetails.Add(new KeyValuePair<string, string>("Phone Number", "0452199039"));
            examDetails.Add(new KeyValuePair<string, string>("Mobile Number", "0452199039"));
            examDetails.Add(new KeyValuePair<string, string>("Address 1", "8/28 Subway Road"));
            examDetails.Add(new KeyValuePair<string, string>("Address 2", ""));
            examDetails.Add(new KeyValuePair<string, string>("Suburb", "Rockdale, Sydney"));
            examDetails.Add(new KeyValuePair<string, string>("State", "NSW"));
            examDetails.Add(new KeyValuePair<string, string>("Email", "i.am.carmack@gmail.com"));
            examDetails.Add(new KeyValuePair<string, string>("Pilot License Type", "ATPL"));
            examDetails.Add(new KeyValuePair<string, string>("Instrument Rating", "Yes"));
            examDetails.Add(new KeyValuePair<string, string>("Valid BFR", "Yes"));
            examDetails.Add(new KeyValuePair<string, string>("Pilot Medical Type", "Class One"));
            examDetails.Add(new KeyValuePair<string, string>("Pilot Medical Expiry Date", "NEVER!!!"));
            examDetails.Add(new KeyValuePair<string, string>("Score", "100/100(100%) - Pass"));

            MemoryStream memStream = pdf.CreatePDF(examDetails, "123456", 1, 0);
            FileStream fs = new FileStream("C:/Users/p406/Desktop/test.pdf", FileMode.Truncate, FileAccess.Write);
            fs.Write(memStream.ToArray(), 0, memStream.ToArray().Count());
        }
    }
}
