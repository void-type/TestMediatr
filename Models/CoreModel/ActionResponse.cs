using System.Collections.Generic;

namespace architectureTest.Models.CoreModel
{
    public class ActionResponse<TSuccess> : IActionResponse
    {
        public List<IValidationError> Failure { get; } = new List<IValidationError>();

        public TSuccess Success { get; set; }

        public ActionResponse<TSuccess> AddFailure(string errorMessage, string fieldName = null)
        {
            Failure.Add(new ValidationError(errorMessage, fieldName));
            return this;
        }
    }
}
