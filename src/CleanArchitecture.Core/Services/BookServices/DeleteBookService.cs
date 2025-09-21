using CleanArchitecture.Core.Domain.Entities.BookAggregate.Specifications;
using CleanArchitecture.Core.Interfaces.BookServices;
using CleanArchitecture.Core.Repositories;
using CleanArchitecture.Core.UnitOfWork;
using CleanArchitecture.Shared.Common.Exceptions;
using CleanArchitecture.Shared.CrossCuttingConcerns.Dtos.Results;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Core.Services.BookServices
{
    public class DeleteBookService(
        IBookRepository _bookRepository,
        IUnitOfWork _unitOfWork,
        ILogger<DeleteBookService> _logger) : IDeleteBookService
    {
        public async Task<ApiResult<int>> DeleteBookAsync(int bookId, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Deleting Book {bookId}");

            var bookByIdSpec = new BookByIdSpec(bookId);
            var book = await _bookRepository.GetAsync(bookByIdSpec);

            var isBookExisted = book != null;

            if (!isBookExisted)
            {
                _logger.LogWarning($"Book {bookId} not found");

                throw UserException.InternalServerException(null);
            }

            _bookRepository.Remove(bookId);

            return new ApiSuccessResult<int>(await _unitOfWork.SaveChangesAsync(cancellationToken));
        }
    }
}
