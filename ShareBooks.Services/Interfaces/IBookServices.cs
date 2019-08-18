using ShareBooks.Domain.Models;
using System;
using System.Collections.Generic;

namespace ShareBooks.Services.Interfaces
{
    public interface IBookServices
    {
        List<BookModel> GetAll( );
        BookModel GetByKeyId( Guid keyId );
        BookModel Insert( BookModel book );
        BookModel Update( BookModel book );
    }
}
