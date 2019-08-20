using AutoMapper;
using ShareBooks.Business.Interfaces;
using ShareBooks.Domain.Entities;
using ShareBooks.Domain.Models;
using ShareBooks.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareBooks.Business
{
    public class BookLoanBusiness : IBookLoanBusiness
    {
        private readonly IRepository<BookLoanEntity> _repository;
        private readonly IMapper _mapper;

        public BookLoanBusiness( IRepository<BookLoanEntity> repository, IMapper mapper )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public BookLoanModel GetByKeyId( )
        {
            throw new NotImplementedException( );
        }

        public BookLoanModel Insert( BookLoanModel bookLoanModel )
        {
            throw new NotImplementedException( );
        }

        public List<BookLoanModel> ListAll( )
        {
            throw new NotImplementedException( );
        }

        public BookLoanModel Update( BookLoanModel bookLoanModel )
        {
            throw new NotImplementedException( );
        }
    }
}
