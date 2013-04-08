using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class Address : IAddress
    {
        public Address(string address1, string address2, string suburb, string state, string postcode)
        {
            this.Address1 = address1;
            this.Address2 = address2;
            this.Suburb = suburb;
            this.State = state;
            this.Postcode = postcode;
        }
    }
}
