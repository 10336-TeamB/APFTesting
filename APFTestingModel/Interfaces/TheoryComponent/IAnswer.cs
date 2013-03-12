using System;

namespace APFTestingModel
{
    public interface IAnswer
    {
        Guid Id { get; }
        string Description { get; }
        int DisplayOrderIndex { get; }
        bool IsCorrect { get; }
    }
}
