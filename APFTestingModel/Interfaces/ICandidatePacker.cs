using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public interface ICandidatePacker
    {
        Guid Id { get; }
        string FirstName { get; }
        string LastName { get; }
        string MobileNumber { get; }
        string APFNumber { get; }
    }
}
