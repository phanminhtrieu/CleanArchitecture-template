using CleanArchitecture.Core.Domain.Models.Books;
using CleanArchitecture.Core.Interfaces.BookServices;
using CleanArchitecture.Shared.CrossCuttingConcerns.Dtos.Results;

namespace CleanArchitecture.Core.Services.BookServices
{
    public class UpdateBookService : IUpdateBookService
    {
        public Task<ApiResult<int>> UpdateBookAsyn(BookRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
