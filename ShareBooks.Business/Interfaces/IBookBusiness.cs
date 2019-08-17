using ShareBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareBooks.Business.Interfaces
{
    public interface IBookBusiness
    {
        List<BookEntity> ListAll( );
        BookEntity Insert( BookEntity book );
        BookEntity Update( BookEntity book );
    }
}
