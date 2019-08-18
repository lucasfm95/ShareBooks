using FluentAssertions;
using Moq;
using ShareBooks.Business;
using ShareBooks.Domain.Entities;
using ShareBooks.Domain.Models;
using ShareBooks.Repository.Interfaces;
using ShareBooks.Tests.Config;
using System;
using System.Collections.Generic;
using Xunit;

namespace ShareBooks.Tests.UnitTests.BusinessTests
{
    [Trait( "Unit", "Book Business" )]
    public class BookBusinessUnitTests
    {
        [Fact( DisplayName = "Get all books" )]
        public void GetAll( )
        {
            List<BookEntity> bookEntities = new List<BookEntity>( );

            Mock<IRepository<BookEntity>> mockRepository = new Mock<IRepository<BookEntity>>( );

            mockRepository
                .Setup( ( a ) => a.FindAll( ) )
                .Returns( bookEntities );

            BookBusiness bookBusiness = new BookBusiness( mockRepository.Object, AutoMapperConfigTest.GetInstance( ) );

            var result = bookBusiness.ListAll( );

            result.Should( ).BeOfType<List<BookModel>>( );
        }

        [Fact( DisplayName = "Get book by keyId" )]
        public void GetByKeyId( )
        {
            BookEntity bookEntity = new BookEntity( );

            Mock<IRepository<BookEntity>> mockRepository = new Mock<IRepository<BookEntity>>( );

            mockRepository
                .Setup( ( a ) => a.FindByKeyId( It.IsAny<Guid>( ) ) )
                .Returns( bookEntity );

            BookBusiness bookBusiness = new BookBusiness( mockRepository.Object, AutoMapperConfigTest.GetInstance( ) );

            var result = bookBusiness.GetByKeyId( It.IsAny<Guid>( ) );

            result.Should( ).BeOfType<BookModel>( );
        }

        [Fact( DisplayName = "Insert book" )]
        public void InsertBook( )
        {
            BookModel bookModel = new BookModel( );
            BookEntity bookEntity = new BookEntity( );

            Mock<IRepository<BookEntity>> mockRepository = new Mock<IRepository<BookEntity>>( );

            mockRepository
                .Setup( ( a ) => a.Insert( It.IsAny<BookEntity>( ) ) )
                .Returns( bookEntity );

            BookBusiness bookBusiness = new BookBusiness( mockRepository.Object, AutoMapperConfigTest.GetInstance( ) );

            var result = bookBusiness.Insert( bookModel );

            result.Should( ).BeOfType<BookModel>( );
        }

        [Fact( DisplayName = "Update book" )]
        public void UpdateBook( )
        {
            BookModel bookModel = new BookModel( );
            BookEntity bookEntity = new BookEntity( );

            Mock<IRepository<BookEntity>> mockRepository = new Mock<IRepository<BookEntity>>( );

            mockRepository
                .Setup( ( a ) => a.FindByKeyId( It.IsAny<Guid>( ) ) )
                .Returns( bookEntity );

            mockRepository
                .Setup( ( a ) => a.Update( It.IsAny<BookEntity>( ) ) )
                .Returns( bookEntity );

            BookBusiness bookBusiness = new BookBusiness( mockRepository.Object, AutoMapperConfigTest.GetInstance( ) );

            var result = bookBusiness.Update( bookModel );

            result.Should( ).BeOfType<BookModel>( );
        }
    }
}
