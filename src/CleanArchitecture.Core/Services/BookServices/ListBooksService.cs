using CleanArchitecture.Core.Domain.Models.Books;
using CleanArchitecture.Core.Interfaces.BookServices;
using CleanArchitecture.Core.Repositories;
using CleanArchitecture.Shared.CrossCuttingConcerns.Dtos.Results;

namespace CleanArchitecture.Core.Services.BookServices
{
    public class ListBooksService(IBookRepository _bookRepository) : IListBooksService
    {
        public async Task<ApiResult<List<BookResponse>>> ListBooksAsync(CancellationToken cancellationToken)
        {
            var query = await _bookRepository.ListAsNoTrackingAsync(null, cancellationToken);
            var books = query.Select(b => new BookResponse(b.Id, b.Title.Value, b.Author.Value, (int)b.Status)).ToList();

            return new ApiSuccessResult<List<BookResponse>>(books);
        }
    }
}
