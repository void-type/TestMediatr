using System.Collections.Generic;

namespace architectureTest.Models.CoreModel
{
    public interface IValidator<TValidatable>
    {
        IEnumerable<IValidationError> Validate(TValidatable validatable);
    }
}
