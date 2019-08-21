using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShareBooks.Domain.Entities;
using ShareBooks.Repository.Abstract;
using System;
using System.Linq;

namespace ShareBooks.Repository
{
    public class BookLoanRepository : Repository<BookLoanEntity>
    {
        public BookLoanRepository( ILogger<Repository<BookLoanEntity>> logger, IConfiguration configuration ) : base( logger, configuration )
        {
        }

        public override BookLoanEntity FindByKeyId( Guid keyId )
        {
            string sqlQuery = "select id, keyid, bookid, readerid, bookloandate, bookloanfeedback, expectedreturndate, returndate, returnfeedback from bookloan where keyid = @KeyId";

            DynamicParameters parameters = new DynamicParameters( );
            parameters.Add( "@KeyId", keyId );

            return base.ExecuteQuery( sqlQuery, parameters ).FirstOrDefault( );
        }
    }
}
