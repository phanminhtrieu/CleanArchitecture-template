using CleanArchitecture.Core.Domain.Entities.BookAggregate;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Interfaces.BookServices;
using CleanArchitecture.Core.Services.BookServices;
using CleanArchitecture.Shared;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Core
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, AppSettings appSettings)
        {
            // Application Service
            //Book
            services.AddTransient<ICreateBookService, CreateBookService>();
            services.AddTransient<IDeleteBookService, DeleteBookService>();
            services.AddTransient<IGetBookByIdService, GetBookByIdService>();

            return services;
        }
    }
}
