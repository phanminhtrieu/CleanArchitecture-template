using CleanArchitecture.Core.Interfaces.BookServices;
using CleanArchitecture.Core.Repositories;
using CleanArchitecture.Core.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Core.Services.BookServices
{
    public class DeleteBookService : IDeleteBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly ILogger<DeleteBookService> _logger;

        public DeleteBookService(
            IBookRepository bookRepository,
            IUnitOfWork unitOfWork,
            IMediator mediator, 
            ILogger<DeleteBookService> logger)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<int> DeleteBookAsync(int bookId)
        {
            _logger.LogInformation("Deleting Book {bookId}", bookId);
            //Book? aggregateToDelete = await //TODO: add repository

            throw new NotImplementedException();
        }
    }
}
