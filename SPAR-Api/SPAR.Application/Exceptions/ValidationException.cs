namespace SPAR.Application.Exceptions;

public class ValidationException  : Exception
{
    public IEnumerable<string> ValidationErrors { get; }

    public ValidationException(IEnumerable<string> validationErrors)
    {
        ValidationErrors = validationErrors;
    }
}