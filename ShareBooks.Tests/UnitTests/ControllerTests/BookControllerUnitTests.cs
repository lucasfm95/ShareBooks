using Microsoft.Extensions.Logging;
using Moq;
using ShareBooks.Application.Controllers;
using ShareBooks.Business.Interfaces;
using ShareBooks.Tests.Config;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShareBooks.Tests.UnitTests.ControllerTests
{
    [Trait("Unit", "Book")]
    public class BookControllerUnitTests
    {
        [Fact(DisplayName = "Insert book")]
        public void InsertBook( )
        {
            Mock<IBookBusiness> mockBookBusiness = new Mock<IBookBusiness>( );
            //Mock<ILogger<BookController>> mockLogger = new Mock<ILogger<BookController>>( );

            //BookController bookController = new BookController( mockBookBusiness.Object, AutoMapperConfigTest.GetInstance( ), mockLogger.Object );
        }
    }
}
