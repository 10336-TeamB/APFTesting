using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public interface IAddress
    {
        string Address1 { get; }
        string Address2 { get; }
        string Suburb { get; }
        string State { get; }
        string Postcode { get; }

        string ToHtmlString();
    }
}
