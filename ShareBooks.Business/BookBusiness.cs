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

        public BookEntity Insert( BookEntity book )
        {
            throw new NotImplementedException( );
        }

        public List<BookEntity> ListAll( )
        {
            //return _repository.FindAll( );

            return new List<BookEntity>( )
            {
                new BookEntity( )
                {
                    Title = "teste Lucas"
                }
            };
        }

        public BookEntity Update( BookEntity book )
        {
            throw new NotImplementedException( );
        }
    }
}
