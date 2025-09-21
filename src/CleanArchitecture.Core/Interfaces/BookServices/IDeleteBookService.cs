namespace CleanArchitecture.Core.Interfaces.BookServices
{
    public interface IDeleteBookService
    {
        public Task<int> DeleteBookAsync(int bookId);
    }
}
