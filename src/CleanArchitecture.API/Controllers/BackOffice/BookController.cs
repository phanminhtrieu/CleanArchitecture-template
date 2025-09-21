using CleanArchitecture.Core.Domain.Models.Books;
using CleanArchitecture.UseCases.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace CleanArchitecture.API.Controllers.Backoffice
{
    public class BookController : BaseBackOfficeController
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet("paging")]
        //public async Task<IActionResult > GetBooksByPaging([FromQuery] ManageBookPagingRequest request, CancellationToken cancellationToken)
        //{
        //    var result = await _mediator.Send(new GetBooksByPagingQuery(request), cancellationToken);
        //    return Ok(result);
        //}

        /// <summary>
        /// Get book by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetBookByIdQuery(id), cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Add new Book
        /// </summary>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<IActionResult> CreateBook([FromBody] BookRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new CreateBookCommand(request), cancellationToken);
            return Ok(result);
        }
    }
}
