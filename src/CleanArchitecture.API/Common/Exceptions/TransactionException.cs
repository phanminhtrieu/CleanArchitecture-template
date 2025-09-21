using CleanArchitecture.API.Common.Errors;
using CleanArchitecture.API.Common.Errors.Messages;

namespace CleanArchitecture.API.Common.Exceptions
{
    public static class TransactionException
    {
        public static UserFriendlyException TransactionNotCommitException()
            => throw new UserFriendlyException(ErrorCode.Internal, ErrorMessage.TransactionNotCommit, ErrorMessage.TransactionNotCommit);

        public static UserFriendlyException TransactionNotExecuteException(Exception ex)
            => throw new UserFriendlyException(ErrorCode.Internal, ErrorMessage.TransactionNotExecute, ErrorMessage.TransactionNotExecute, ex);
    }
}
