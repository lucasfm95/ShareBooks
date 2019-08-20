using FluentAssertions;
using Moq;
using ShareBooks.Business;
using ShareBooks.Domain.Entities;
using ShareBooks.Domain.Models;
using ShareBooks.Repository.Interfaces;
using ShareBooks.Tests.Config;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShareBooks.Tests.UnitTests.BusinessTests
{
    [Trait("Unit", "Reader Business")]
    public class ReaderBusinessUnitTests
    {
        [Fact( DisplayName = "Get all readers" )]
        public void GetAll( )
        {
            List<ReaderEntity> readerEntities = new List<ReaderEntity>( );

            Mock<IRepository<ReaderEntity>> mockRepository = new Mock<IRepository<ReaderEntity>>( );

            mockRepository
                .Setup( ( a ) => a.FindAll( ) )
                .Returns( readerEntities );

            ReaderBusiness readerBusiness = new ReaderBusiness( mockRepository.Object, AutoMapperConfigTest.GetInstance( ) );

            var result = readerBusiness.ListAll( );

            result.Should( ).BeOfType<List<ReaderModel>>( );
        }

        [Fact( DisplayName = "Get reader by keyId" )]
        public void GetByKeyId( )
        {
            ReaderEntity readerEntity = new ReaderEntity( );

            Mock<IRepository<ReaderEntity>> mockRepository = new Mock<IRepository<ReaderEntity>>( );

            mockRepository
                .Setup( ( a ) => a.FindByKeyId( It.IsAny<Guid>( ) ) )
                .Returns( readerEntity );

            ReaderBusiness readerBusiness = new ReaderBusiness( mockRepository.Object, AutoMapperConfigTest.GetInstance( ) );

            var result = readerBusiness.GetByKeyId( It.IsAny<Guid>( ) );

            result.Should( ).BeOfType<ReaderModel>( );
        }

        [Fact( DisplayName = "Insert reader" )]
        public void InsertReader( )
        {
            ReaderModel readerModel = new ReaderModel( );
            ReaderEntity readerEntity = new ReaderEntity( );

            Mock<IRepository<ReaderEntity>> mockRepository = new Mock<IRepository<ReaderEntity>>( );

            mockRepository
                .Setup( ( a ) => a.Insert( It.IsAny<ReaderEntity>( ) ) )
                .Returns( readerEntity );

            ReaderBusiness readerBusiness = new ReaderBusiness( mockRepository.Object, AutoMapperConfigTest.GetInstance( ) );

            var result = readerBusiness.Insert( readerModel );

            result.Should( ).BeOfType<ReaderModel>( );
        }

        [Fact( DisplayName = "Update reader" )]
        public void UpdateReader( )
        {
            ReaderModel readerModel = new ReaderModel( );
            ReaderEntity readerEntity = new ReaderEntity( );

            Mock<IRepository<ReaderEntity>> mockRepository = new Mock<IRepository<ReaderEntity>>( );

            mockRepository
                .Setup( ( a ) => a.FindByKeyId( It.IsAny<Guid>( ) ) )
                .Returns( readerEntity );

            mockRepository
                .Setup( ( a ) => a.Update( It.IsAny<ReaderEntity>( ) ) )
                .Returns( readerEntity );

            ReaderBusiness readerBusiness = new ReaderBusiness( mockRepository.Object, AutoMapperConfigTest.GetInstance( ) );

            var result = readerBusiness.Update( readerModel );

            result.Should( ).BeOfType<ReaderModel>( );
        }
    }
}
