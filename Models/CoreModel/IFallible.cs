using System.Collections.Generic;

namespace MediatrRailwayExample.Models.CoreModel
{
    public interface IFallible
    {
        List<IValidationError> Failure { get; }
    }
}
