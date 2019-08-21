using ShareBooks.Business.Interfaces;
using ShareBooks.Domain.Models;
using ShareBooks.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareBooks.Services
{
    public class BookLoanServices : IBookLoanServices
    {
        private readonly IBookLoanBusiness _bookLoanBusiness;
        public BookLoanServices( IBookLoanBusiness bookLoanBusiness )
        {
            _bookLoanBusiness = bookLoanBusiness;
        }

        public List<BookLoanModel> GetAll( )
        {
            return _bookLoanBusiness.ListAll( );
        }

        public BookLoanModel GetByKeyId( Guid keyId )
        {
            return _bookLoanBusiness.GetByKeyId( keyId );
        }

        public BookLoanModel Insert( BookLoanModel bookLoanModel )
        {
            return _bookLoanBusiness.Insert( bookLoanModel );
        }

        public BookLoanModel Update( BookLoanModel bookLoanModel )
        {
            return _bookLoanBusiness.Update( bookLoanModel );
        }
    }
}
