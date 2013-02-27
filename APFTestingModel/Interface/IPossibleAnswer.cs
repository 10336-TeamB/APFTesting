using System;

namespace APFTestingModel
{
    public interface IPossibleAnswer
    {
        Guid Id { get; }
        string Description { get; }
        int Order { get; }
    }
}
