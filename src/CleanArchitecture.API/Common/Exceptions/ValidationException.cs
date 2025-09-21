using CleanArchitecture.API.Common.Errors;

namespace CleanArchitecture.API.Common.Exceptions
{
    public class ValidationException(ErrorResponse errorResponse) : Exception
    {
        public ErrorResponse ErrorResponse { get; private set; } = errorResponse;
    }
}
