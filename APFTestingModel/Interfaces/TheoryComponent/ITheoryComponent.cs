using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public interface ITheoryComponent
    {
        Guid Id { get; }
        Guid FormatId { get; }
        int CurrentQuestionIndex { get; }
        decimal Score { get; }
        DateTime Date { get; }
        IEnumerable<ISelectedTheoryQuestion> SelectedTheoryQuestions { get; }
        bool IsCompetent { get; }
    }
}
