namespace architectureTest.Models.CoreModel
{
    public class ValidationError : IValidationError
    {
        public ValidationError() { }

        public ValidationError(string errorMessage, string fieldName = null)
        {
            ErrorMessage = errorMessage;
            FieldName = fieldName;
        }

        public string ErrorMessage { get; set; }
        public string FieldName { get; set; }
    }

    public interface IValidationError
    {
        string ErrorMessage { get; set; }
        string FieldName { get; set; }
    }
}
