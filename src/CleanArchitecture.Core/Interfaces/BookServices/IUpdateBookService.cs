using CleanArchitecture.Core.Domain.Models.Books;
using CleanArchitecture.Shared.CrossCuttingConcerns.Dtos.Results;

namespace CleanArchitecture.Core.Interfaces.BookServices
{
    public interface IUpdateBookService
    {
        public Task<ApiResult<int>> UpdateBookAsyn(BookRequest request, CancellationToken cancellationToken);
    }
}
