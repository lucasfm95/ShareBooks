using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShareBooks.Domain.Entities;
using ShareBooks.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShareBooks.Repository
{
    public class BookRepository : Repository<BookEntity>
    {
        public BookRepository( ILogger<Repository<BookEntity>> logger, IConfiguration configuration ) : base( logger, configuration )
        {
        }

        public override BookEntity FindByKeyId( Guid keyId )
        {
            string sqlQuery = "select id, keyid, title, subtitle, publisher, author, edition, yearedition, active from book where keyid = @KeyId";

            DynamicParameters parameters = new DynamicParameters( );
            parameters.Add( "@KeyId", keyId );

            return base.ExecuteQuery( sqlQuery, parameters ).FirstOrDefault( );
        }
    }
}
