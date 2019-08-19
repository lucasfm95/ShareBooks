using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ShareBooks.Application.Controllers;
using ShareBooks.Domain.Models;
using ShareBooks.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShareBooks.Tests.UnitTests.ControllerTests
{
    [Trait( "Unit", "Reader Controller" )]
    public class ReaderControllerUnitTests
    {
        [Fact( DisplayName = "Get all readers" )]
        public void GetAll( )
        {
            List<ReaderModel> readerModels = new List<ReaderModel>( )
            {
                new ReaderModel( )
                {
                    Name = "Lucas Felipe Martins",
                    IdentityDocument = "12345678901",
                    Email = "luucasmartins@hotmail.com",
                }
            };

            Mock<IReaderServices> mockReaderServices = new Mock<IReaderServices>( );
            Mock<ILogger<ReaderController>> mockLogger = new Mock<ILogger<ReaderController>>( );

            mockReaderServices
                .Setup( ( a ) => a.GetAll( ) )
                .Returns( readerModels );

            ReaderController readerController = new ReaderController( mockReaderServices.Object, mockLogger.Object );

            var result = readerController.Get( ).Result;

            result.Should( ).BeOfType<OkObjectResult>( );
        }

        [Fact( DisplayName = "Get all reader empty" )]
        public void GetAllEmpty( )
        {
            List<ReaderModel> readerModels = new List<ReaderModel>( );

            Mock<IReaderServices> mockReaderServices = new Mock<IReaderServices>( );
            Mock<ILogger<ReaderController>> mockLogger = new Mock<ILogger<ReaderController>>( );

            mockReaderServices
                .Setup( ( a ) => a.GetAll( ) )
                .Returns( readerModels );

            ReaderController readerController = new ReaderController( mockReaderServices.Object, mockLogger.Object );

            var result = readerController.Get( ).Result;

            result.Should( ).BeOfType<NoContentResult>( );
        }

        [Fact( DisplayName = "Try get all readers exception" )]
        public void TryGetAllException( )
        {
            Mock<ILogger<ReaderController>> mockLogger = new Mock<ILogger<ReaderController>>( );

            ReaderController readerController = new ReaderController( It.IsAny<IReaderServices>( ), mockLogger.Object );

            var result = readerController.Get( ).Result;

            result.Should( ).BeOfType<StatusCodeResult>( ).Equals( 500 );
        }

        [Fact( DisplayName = "Get reader by keyId" )]
        public void GetByKeyId( )
        {
            ReaderModel readerModel = new ReaderModel( )
            {
                Name = "Lucas Felipe Martins",
                IdentityDocument = "12345678901",
                Email = "luucasmartins@hotmail.com",
            };

            Mock<IReaderServices> mockReaderServices = new Mock<IReaderServices>( );
            Mock<ILogger<ReaderController>> mockLogger = new Mock<ILogger<ReaderController>>( );

            mockReaderServices
                .Setup( ( a ) => a.GetByKeyId( It.IsAny<Guid>( ) ) )
                .Returns( readerModel );

            ReaderController readerController = new ReaderController( mockReaderServices.Object, mockLogger.Object );

            var result = readerController.GetByKeyId( It.IsAny<Guid>( ) ).Result;

            result.Should( ).BeOfType<OkObjectResult>( );
        }

        [Fact( DisplayName = "Get reader by keyId return empty" )]
        public void GetByKeyIdEmpty( )
        {
            Mock<IReaderServices> mockReaderServices = new Mock<IReaderServices>( );
            Mock<ILogger<ReaderController>> mockLogger = new Mock<ILogger<ReaderController>>( );

            mockReaderServices
                .Setup( ( a ) => a.GetByKeyId( It.IsAny<Guid>( ) ) )
                .Returns( It.IsAny<ReaderModel>( ) );

            ReaderController readerController = new ReaderController( mockReaderServices.Object, mockLogger.Object );

            var result = readerController.GetByKeyId( It.IsAny<Guid>( ) ).Result;

            result.Should( ).BeOfType<NoContentResult>( );
        }

        [Fact( DisplayName = "Try get by keyId exception" )]
        public void TryGetByKeyIdException( )
        {
            Mock<ILogger<ReaderController>> mockLogger = new Mock<ILogger<ReaderController>>( );

            ReaderController readerController = new ReaderController( It.IsAny<IReaderServices>( ), mockLogger.Object );

            var result = readerController.GetByKeyId( It.IsAny<Guid>( ) ).Result;

            result.Should( ).BeOfType<StatusCodeResult>( ).Equals( 500 );
        }

        [Fact( DisplayName = "Insert reader" )]
        public void InsertReader( )
        {
            ReaderModel readerModel = new ReaderModel( )
            {
                Name = "Lucas Felipe Martins",
                IdentityDocument = "12345678901",
                Email = "luucasmartins@hotmail.com",
            };

            Mock<IReaderServices> mockReaderServices = new Mock<IReaderServices>( );
            Mock<ILogger<ReaderController>> mockLogger = new Mock<ILogger<ReaderController>>( );

            mockReaderServices
                .Setup( ( a ) => a.Insert( It.IsAny<ReaderModel>( ) ) )
                .Returns( readerModel );

            ReaderController readerController = new ReaderController( mockReaderServices.Object, mockLogger.Object );

            var result = readerController.Post( readerModel ).Result;

            result.Should( ).BeOfType<OkResult>( );
        }

        [Fact( DisplayName = "Try insert reader" )]
        public void TryInsertReader( )
        {
            Mock<IReaderServices> mockReaderServices = new Mock<IReaderServices>( );
            Mock<ILogger<ReaderController>> mockLogger = new Mock<ILogger<ReaderController>>( );

            mockReaderServices
                .Setup( ( a ) => a.Insert( It.IsAny<ReaderModel>( ) ) )
                .Returns( It.IsAny<ReaderModel>( ) ); ;

            ReaderController readerController = new ReaderController( mockReaderServices.Object, mockLogger.Object );

            var result = readerController.Post( It.IsAny<ReaderModel>( ) ).Result;

            result.Should( ).BeOfType<StatusCodeResult>( ).Equals( 500 );
        }

        [Fact( DisplayName = "Try insert reader exception" )]
        public void TryInsertReaderException( )
        {
            Mock<ILogger<ReaderController>> mockLogger = new Mock<ILogger<ReaderController>>( );

            ReaderController readerController = new ReaderController( It.IsAny<IReaderServices>( ), mockLogger.Object );

            var result = readerController.Post( It.IsAny<ReaderModel>( ) ).Result;

            result.Should( ).BeOfType<StatusCodeResult>( ).Equals( 500 );
        }

        [Fact( DisplayName = "Update Reader" )]
        public void UpdateReader( )
        {
            ReaderModel readerModel = new ReaderModel( )
            {
                Name = "Lucas Felipe Martins",
                IdentityDocument = "12345678901",
                Email = "luucasmartins@hotmail.com",
            };

            Mock<IReaderServices> mockReaderServices = new Mock<IReaderServices>( );
            Mock<ILogger<ReaderController>> mockLogger = new Mock<ILogger<ReaderController>>( );

            mockReaderServices
                .Setup( ( a ) => a.Update( It.IsAny<ReaderModel>( ) ) )
                .Returns( readerModel );

            ReaderController readerController = new ReaderController( mockReaderServices.Object, mockLogger.Object );

            var result = readerController.Put( It.IsAny<ReaderModel>( ) ).Result;

            result.Should( ).BeOfType<OkResult>( );
        }

        [Fact( DisplayName = "Try update reader" )]
        public void TryUpdateReader( )
        {
            Mock<IReaderServices> mockReaderServices = new Mock<IReaderServices>( );
            Mock<ILogger<ReaderController>> mockLogger = new Mock<ILogger<ReaderController>>( );

            mockReaderServices
                .Setup( ( a ) => a.Update( It.IsAny<ReaderModel>( ) ) )
                .Returns( It.IsAny<ReaderModel>( ) );

            ReaderController readerController = new ReaderController( mockReaderServices.Object, mockLogger.Object );

            var result = readerController.Put( It.IsAny<ReaderModel>( ) ).Result;

            result.Should( ).BeOfType<StatusCodeResult>( ).Equals( 500 );
        }

        [Fact(DisplayName = "Try update reader exception")]
        public void TryUpdateReaderException( )
        {
            Mock<ILogger<ReaderController>> mockLogger = new Mock<ILogger<ReaderController>>( );

            ReaderController readerController = new ReaderController( It.IsAny<IReaderServices>( ), mockLogger.Object );

            var result = readerController.Put( It.IsAny<ReaderModel>( ) ).Result;

            result.Should( ).BeOfType<StatusCodeResult>( ).Equals( 500 );
        }
    }
}
