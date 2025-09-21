using CleanArchitecture.Core.Domain.Entities.BookAggregate.Specifications;
using CleanArchitecture.Core.Domain.Models.Books;
using CleanArchitecture.Core.Interfaces.BookServices;
using CleanArchitecture.Core.Repositories;
using CleanArchitecture.Shared.CrossCuttingConcerns.Dtos.Results;

namespace CleanArchitecture.Core.Services.BookServices
{
    public class GetBookByIdService(IBookRepository _bookRepository) : IGetBookByIdService
    {
        public async Task<ApiResult<BookResponse>> GetBookByIdAsync(int id, CancellationToken cancellationToken)
        {
            var spec = new BookByIdSpec(id);
            var book = await _bookRepository.GetAsync(spec, cancellationToken, null);

            var response = new BookResponse(book.Id, book.Title.Value, book.Author.Value, (int)book.Status);

            return new ApiSuccessResult<BookResponse>(response);
        }
    }
}
