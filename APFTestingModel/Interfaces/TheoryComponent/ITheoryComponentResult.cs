using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public interface ITheoryComponentResult
    {
        decimal Score { get; }
        bool IsCompetent { get; }
    }
}
