using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class Address : IAddress
    {
        public Address(string address1, string address2, string suburb, string state, string postcode)
        {
            if (!Regex.IsMatch(postcode, @"^[0-9]{4}$")) {
                throw new BusinessRuleException("Postcode must have 4 digits");
            }
            this.Address1 = address1;
            this.Address2 = address2;
            this.Suburb = suburb;
            this.State = state;
            this.Postcode = postcode;
        }

        public string ToHtmlString()
        {
            var br = "<br />";
            string retStr;

            retStr = Address1 + br;
            if (Address2 != null)
            {
                retStr += Address2 + br;
            }

            retStr += String.Format("{1}, {2}{0}{3}", br, Suburb, Postcode, State);
            return retStr;
        }
    }
}
