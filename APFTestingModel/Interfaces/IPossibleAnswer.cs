using System;

namespace APFTestingModel.Interfaces
{
    public interface IPossibleAnswer
    {
        Guid Id { get; }
        string Description { get; }
        int Order { get; }
    }
}
