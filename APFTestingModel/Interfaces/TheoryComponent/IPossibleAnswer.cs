using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPossibleAnswer
    {
        string Description { get; }
        int DisplayOrderIndex { get; }
        bool IsCorrect { get; }
        bool IsChecked { get; }
    }
}
