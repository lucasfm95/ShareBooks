using ShareBooks.Domain.Models;
using System;
using System.Collections.Generic;

namespace ShareBooks.Business.Interfaces
{
    public interface IBookBusiness
    {
        List<BookModel> ListAll( );
        BookModel GetByKeyId( Guid keyId );
        BookModel Insert( BookModel book );
        BookModel Update( BookModel book );
    }
}
