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

    internal class BookDeletedEventHandler(ILogger<BookDeletedEventHandler> _logger) : INotificationHandler<BookDeletedEvent>
    {
        public Task Handle(BookDeletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Book Deleted event: {notification.BookId}");

            // Send an email or something else ...

            return Task.CompletedTask;
        }
    }
}
