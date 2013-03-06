using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public interface ISelectedAnswer
    {
        //Not implemented yet -- AL
        ISelectedTheoryQuestion Question { get; }
        IPossibleAnswer Answer { get; }
    }
}
