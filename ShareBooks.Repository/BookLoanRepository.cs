using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShareBooks.Domain.Entities;
using ShareBooks.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareBooks.Repository
{
    public class BookLoanRepository : Repository<BookLoanEntity>
    {
        public BookLoanRepository( ILogger<Repository<BookLoanEntity>> logger, IConfiguration configuration ) : base( logger, configuration )
        {
        }

        public override BookLoanEntity FindByKeyId( Guid keyId )
        {
            throw new NotImplementedException( );
        }
    }
}
