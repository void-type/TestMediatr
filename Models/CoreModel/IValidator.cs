using System.Collections.Generic;

namespace MediatrRailwayExample.Models.CoreModel
{
    public interface IValidator<TValidatable>
    {
        IEnumerable<IValidationError> Validate(TValidatable validatable);
    }
}
