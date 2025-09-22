using CleanArchitecture.Core.Interfaces.BookServices;
using CleanArchitecture.Core.Interfaces.MailServices;
using CleanArchitecture.Core.Services.BookServices;
using CleanArchitecture.Core.Services.MailServices;
using CleanArchitecture.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Core
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServiceDI(this IServiceCollection services, AppSettings appSettings)
        {
            // Application Service
            //Book
            services.AddTransient<IListBooksByPagingService, ListBooksByPagingService>();
            services.AddTransient<IListBooksService, ListBooksService>();
            services.AddTransient<IGetBookByIdService, GetBookByIdService>();
            services.AddTransient<ICreateBookService, CreateBookService>();
            services.AddTransient<IUpdateBookService, UpdateBookService>();
            services.AddTransient<IDeleteBookService, DeleteBookService>();

            // Email
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
