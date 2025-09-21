﻿using CleanArchitecture.API.Common.Errors;
using CleanArchitecture.API.Common.Errors.Messages;

namespace CleanArchitecture.API.Common.Exceptions
{
    public static class UserException
    {
        public static UserFriendlyException UserAlreadyExistsException(string field)
            => new(ErrorCode.BadRequest, string.Format(UserErrorMessage.AlreadyExists, field), string.Format(UserErrorMessage.AlreadyExists, field));

        public static UserFriendlyException UserUnauthorizedException()
            => new(ErrorCode.Unauthorized, UserErrorMessage.Unauthorized, UserErrorMessage.Unauthorized);

        public static UserFriendlyException InternalException(Exception? exception)
            => new(ErrorCode.Internal, ErrorMessage.InternalError, ErrorMessage.InternalError, exception);

        public static UserFriendlyException BadRequestException(string errorMessage)
            => new(ErrorCode.BadRequest, errorMessage, errorMessage);
    }
}
