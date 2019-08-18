using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ShareBooks.Application.AutoMapper;
using ShareBooks.Business;
using ShareBooks.Business.Interfaces;
using ShareBooks.Domain.Entities;
using ShareBooks.Repository;
using ShareBooks.Repository.Interfaces;
using ShareBooks.Services;
using ShareBooks.Services.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace ShareBooks.Application.Middlewares
{
    /// <summary>
    /// Classe de injeção de dependência no container DI
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionMiddleware
    {
        /// <summary>
        /// Adiciona todas as dependências do projeto no container de DI
        /// </summary>
        /// <param name="services">Container Services</param>
        public static void AddDependencyInjection( this IServiceCollection services )
        {
            MapperConfiguration mapperConfig = AutoMapperConfig.RegisterMappings( );

            services.AddSingleton( mapperConfig.CreateMapper( ) );

            #region Repositories

            services.AddSingleton<IRepository<BookEntity>, BookRepository>( );

            #endregion

            #region Business

            services.AddTransient<IBookBusiness, BookBusiness>( );

            #endregion

            #region Services

            services.AddTransient<IBookServices, BookServices>( );

            #endregion
        }
    }
}
