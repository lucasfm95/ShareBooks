using ShareBooks.Business.Interfaces;
using ShareBooks.Domain.Entities;
using ShareBooks.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareBooks.Business
{
    public class BookBusiness : IBookBusiness
    {
        private readonly IRepository<BookEntity> _repository;
        public BookBusiness( IRepository<BookEntity> repository )
        {
            _repository = repository; 
        }

        public BookEntity GetByKeyId( Guid keyId )
        {
            //return _repository.FindById( 1 );
            return _repository.FindByKeyId( keyId );
        }

        public BookEntity Insert( BookEntity book )
        {
            book.KeyId = Guid.NewGuid( );
            return _repository.Insert( book );
        }

        public List<BookEntity> ListAll( )
        {
            return _repository.FindAll( );
        }

        public BookEntity Update( BookEntity book )
        {
            throw new NotImplementedException( );
        }
    }
}
