using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    interface ITheoryComponentFormat
    {
        Guid Id { get; }
        int NumberOfQuestions { get; }
        int PassMark { get; }
        bool IsActive { get; }
        int TimeLimit { get; }
    }
}
