using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class Address
    {
        public Address(string Address1, string Address2, string Suburb, string Postcode)
        {
            this.Address1 = Address1;
            this.Address2 = Address2;
            this.Suburb = Suburb;
            this.Postcode = Postcode;
        }
    }
}
