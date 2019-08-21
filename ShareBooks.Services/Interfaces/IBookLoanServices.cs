using ShareBooks.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareBooks.Services.Interfaces
{
    public interface IBookLoanServices
    {
        List<BookLoanModel> GetAll( );
        BookLoanModel GetByKeyId( Guid keyId );
        BookLoanModel Insert( BookLoanModel bookLoanModel );
        BookLoanModel Update( BookLoanModel bookLoanModel );
    }
}
