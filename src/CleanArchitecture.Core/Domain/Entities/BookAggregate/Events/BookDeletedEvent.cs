using CleanArchitecture.Core.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Core.Domain.Entities.BookAggregate.Events
{
    internal sealed class BookDeletedEvent : DomainEventBase
    {
        public int BookId { get; }

        public BookDeletedEvent(int bookId) 
        { 
            BookId = bookId;
        }
    }

    internal class BookDeletedEventHandler : INotificationHandler<BookDeletedEvent>
    {
        private readonly ILogger<BookDeletedEventHandler> _logger;

        public BookDeletedEventHandler(ILogger<BookDeletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(BookDeletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Deleted event: {notification.BookId}");

            // Send an email or something else ...

            return Task.CompletedTask;
        }
    }
}
