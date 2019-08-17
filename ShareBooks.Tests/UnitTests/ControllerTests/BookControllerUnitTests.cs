using Microsoft.Extensions.Logging;
using Moq;
using ShareBooks.Application.Controllers;
using ShareBooks.Services.Interfaces;
using Xunit;

namespace ShareBooks.Tests.UnitTests.ControllerTests
{
    [Trait( "Unit", "Book" )]
    public class BookControllerUnitTests
    {
        [Fact( DisplayName = "Insert book" )]
        public void InsertBook( )
        {
            Mock<IBookServices> mockBookServices = new Mock<IBookServices>( );
            Mock<ILogger<BookController>> mockLogger = new Mock<ILogger<BookController>>( );

            BookController bookController = new BookController( mockBookServices.Object, mockLogger.Object );
        }
    }
}
