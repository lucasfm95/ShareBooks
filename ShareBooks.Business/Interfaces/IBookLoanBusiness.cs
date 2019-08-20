using ShareBooks.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareBooks.Business.Interfaces
{
    public interface IBookLoanBusiness
    {
        List<BookLoanModel> ListAll( );
        BookLoanModel GetByKeyId( );
        BookLoanModel Insert( BookLoanModel bookLoanModel );
        BookLoanModel Update( BookLoanModel bookLoanModel );
    }
}
