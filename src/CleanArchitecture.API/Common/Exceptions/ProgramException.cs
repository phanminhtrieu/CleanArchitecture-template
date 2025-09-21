using CleanArchitecture.API.Common.Errors;
using CleanArchitecture.API.Common.Errors.Messages;

namespace CleanArchitecture.API.Common.Exceptions
{
    public static class ProgramException
    {
        public static UserFriendlyException AppsettingNotSetException()
            => new(ErrorCode.Internal, ErrorMessage.AppConfigurationMessage, ErrorMessage.InternalError);
    }
}
