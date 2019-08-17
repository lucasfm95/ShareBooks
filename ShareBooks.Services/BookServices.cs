using ShareBooks.Business.Interfaces;
using ShareBooks.Domain.Entities;
using ShareBooks.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareBooks.Services
{
    public class BookServices : IBookServices
    {
        private readonly IBookBusiness _bookBusiness;
        public BookServices( IBookBusiness bookBusiness )
        {
            _bookBusiness = bookBusiness;
        }

        public List<BookEntity> GetAll( )
        {
            return _bookBusiness.ListAll( );
        }

        public BookEntity Insert( BookEntity book )
        {
            throw new NotImplementedException( );
        }

        public BookEntity Update( BookEntity book )
        {
            throw new NotImplementedException( );
        }
    }
}
