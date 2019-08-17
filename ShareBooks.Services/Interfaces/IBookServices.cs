using ShareBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareBooks.Services.Interfaces
{
    public interface IBookServices
    {
        List<BookEntity> GetAll( );
        BookEntity Insert( BookEntity book );
        BookEntity Update( BookEntity book );
    }
}
