using System.Collections.Generic;

namespace architectureTest.Models.CoreModel
{
    public interface IFallible
    {
        List<IValidationError> Failure { get; }
    }
}
