using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ShareBooks.Application.Controllers;
using ShareBooks.Domain.Models;
using ShareBooks.Services.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace ShareBooks.Tests.UnitTests.ControllerTests
{
    [Trait( "Unit", "Book Controller" )]
    public class BookControllerUnitTests
    {
        [Fact( DisplayName = "Get all books" )]
        public void GetAll( )
        {
            List<BookModel> books = new List<BookModel>( )
            {
                 new BookModel( )
                 {
                    Title = "Title",
                    SubTitle = "SubTitle",
                    Edition = "1",
                    Active = true,
                    Author = "Author",
                    Publisher = "Publisher",
                    YearEdition = "YearEdition"
                 }
            };

            Mock<IBookServices> mockBookServices = new Mock<IBookServices>( );
            Mock<ILogger<BookController>> mockLogger = new Mock<ILogger<BookController>>( );

            mockBookServices
                .Setup( ( a ) => a.GetAll( ) )
                .Returns( books );

            BookController bookController = new BookController( mockBookServices.Object, mockLogger.Object );

            var result = bookController.Get( ).Result;

            result.Should( ).BeOfType<OkObjectResult>( );
        }

        [Fact( DisplayName = "Get all books returns empty" )]
        public void GetAllEmpty( )
        {
            List<BookModel> books = new List<BookModel>( );

            Mock<IBookServices> mockBookServices = new Mock<IBookServices>( );
            Mock<ILogger<BookController>> mockLogger = new Mock<ILogger<BookController>>( );

            mockBookServices
                .Setup( ( a ) => a.GetAll( ) )
                .Returns( books );

            BookController bookController = new BookController( mockBookServices.Object, mockLogger.Object );

            var result = bookController.Get( ).Result;

            result.Should( ).BeOfType<NoContentResult>( );
        }

        [Fact( DisplayName = "Try get all books exception" )]
        public void TryGetAllException( )
        {
            Mock<ILogger<BookController>> mockLogger = new Mock<ILogger<BookController>>( );

            BookController bookController = new BookController( It.IsAny<IBookServices>( ), mockLogger.Object );

            var result = bookController.Get( ).Result;

            result.Should( ).BeOfType<StatusCodeResult>( ).Equals( 500 );
        }

        [Fact( DisplayName = "Get book by keyId" )]
        public void GetByKeyId( )
        {
            BookModel bookModel = new BookModel( )
            {
                Title = "Title",
                SubTitle = "SubTitle",
                Edition = "1",
                Active = true,
                Author = "Author",
                Publisher = "Publisher",
                YearEdition = "YearEdition"
            };

            Mock<IBookServices> mockBookServices = new Mock<IBookServices>( );
            Mock<ILogger<BookController>> mockLogger = new Mock<ILogger<BookController>>( );

            mockBookServices
                .Setup( ( a ) => a.GetByKeyId( It.IsAny<Guid>( ) ) )
                .Returns( bookModel );

            BookController bookController = new BookController( mockBookServices.Object, mockLogger.Object );

            var result = bookController.GetByKeyId( It.IsAny<Guid>( ) ).Result;

            result.Should( ).BeOfType<OkObjectResult>( );
        }

        [Fact( DisplayName = "Get book by keyId returns empty" )]
        public void GetByKeyIdEmpty( )
        {

            Mock<IBookServices> mockBookServices = new Mock<IBookServices>( );
            Mock<ILogger<BookController>> mockLogger = new Mock<ILogger<BookController>>( );

            mockBookServices
                .Setup( ( a ) => a.GetByKeyId( It.IsAny<Guid>( ) ) )
                .Returns( It.IsAny<BookModel>( ) );

            BookController bookController = new BookController( mockBookServices.Object, mockLogger.Object );

            var result = bookController.GetByKeyId( It.IsAny<Guid>( ) ).Result;

            result.Should( ).BeOfType<NoContentResult>( );
        }

        [Fact( DisplayName = "Get book by keyId exception" )]
        public void GetByKeyIdException( )
        {
            Mock<ILogger<BookController>> mockLogger = new Mock<ILogger<BookController>>( );

            BookController bookController = new BookController( It.IsAny<IBookServices>( ), mockLogger.Object );

            var result = bookController.GetByKeyId( It.IsAny<Guid>( ) ).Result;

            result.Should( ).BeOfType<StatusCodeResult>( ).Equals( 500 );
        }

        [Fact( DisplayName = "Insert book" )]
        public void InsertBook( )
        {
            BookModel bookModel = new BookModel( )
            {
                Title = "Title",
                SubTitle = "SubTitle",
                Edition = "1",
                Active = true,
                Author = "Author",
                Publisher = "Publisher",
                YearEdition = "YearEdition"
            };

            Mock<IBookServices> mockBookServices = new Mock<IBookServices>( );
            Mock<ILogger<BookController>> mockLogger = new Mock<ILogger<BookController>>( );

            mockBookServices
                .Setup( ( a ) => a.Insert( It.IsAny<BookModel>( ) ) )
                .Returns( bookModel );

            BookController bookController = new BookController( mockBookServices.Object, mockLogger.Object );

            var result = bookController.Post( bookModel ).Result;

            result.Should( ).BeOfType<OkResult>( );
        }

        [Fact( DisplayName = "Try insert book" )]
        public void TryInsertBook( )
        {
            Mock<IBookServices> mockBookServices = new Mock<IBookServices>( );
            Mock<ILogger<BookController>> mockLogger = new Mock<ILogger<BookController>>( );

            mockBookServices
                .Setup( ( a ) => a.Insert( It.IsAny<BookModel>( ) ) )
                .Returns( It.IsAny<BookModel>( ) );

            BookController bookController = new BookController( mockBookServices.Object, mockLogger.Object );

            var result = bookController.Post( It.IsAny<BookModel>( ) ).Result;

            result.Should( ).BeOfType<StatusCodeResult>( ).Equals( 500 );
        }

        [Fact( DisplayName = "Try insert book exception" )]
        public void TryInsertBookException( )
        {
            Mock<ILogger<BookController>> mockLogger = new Mock<ILogger<BookController>>( );

            BookController bookController = new BookController( It.IsAny<IBookServices>( ), mockLogger.Object );

            var result = bookController.Post( It.IsAny<BookModel>( ) ).Result;

            result.Should( ).BeOfType<StatusCodeResult>( ).Equals( 500 );
        }

        [Fact( DisplayName = "Update book" )]
        public void UpdateBook( )
        {
            BookModel bookModel = new BookModel( )
            {
                Title = "Title",
                SubTitle = "SubTitle",
                Edition = "1",
                Active = true,
                Author = "Author",
                Publisher = "Publisher",
                YearEdition = "YearEdition"
            };

            Mock<IBookServices> mockBookServices = new Mock<IBookServices>( );
            Mock<ILogger<BookController>> mockLogger = new Mock<ILogger<BookController>>( );

            mockBookServices
                .Setup( ( a ) => a.Update( It.IsAny<BookModel>( ) ) )
                .Returns( bookModel );

            BookController bookController = new BookController( mockBookServices.Object, mockLogger.Object );

            var result = bookController.Put( It.IsAny<BookModel>( ) ).Result;

            result.Should( ).BeOfType<OkResult>( );
        }

        [Fact( DisplayName = "Try update book" )]
        public void TryUpdateBook( )
        {
            Mock<IBookServices> mockBookServices = new Mock<IBookServices>( );
            Mock<ILogger<BookController>> mockLogger = new Mock<ILogger<BookController>>( );

            mockBookServices
                .Setup( ( a ) => a.Update( It.IsAny<BookModel>( ) ) )
                .Returns( It.IsAny<BookModel>( ) );

            BookController bookController = new BookController( mockBookServices.Object, mockLogger.Object );

            var result = bookController.Put( It.IsAny<BookModel>( ) ).Result;

            result.Should( ).BeOfType<StatusCodeResult>( ).Equals( 500 );
        }

        [Fact( DisplayName = "Try update book exception" )]
        public void TryUpdateBookException( )
        {
            Mock<ILogger<BookController>> mockLogger = new Mock<ILogger<BookController>>( );

            BookController bookController = new BookController( It.IsAny<IBookServices>( ), mockLogger.Object );

            var result = bookController.Put( It.IsAny<BookModel>( ) ).Result;

            result.Should( ).BeOfType<StatusCodeResult>( ).Equals( 500 );
        }
    }
}