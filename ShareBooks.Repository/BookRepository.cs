using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShareBooks.Domain.Entities;
using ShareBooks.Repository.Abstract;
using System;
using System.Linq;

namespace ShareBooks.Repository
{
    /// <summary>
    /// Implementação do repository do book
    /// </summary>
    public class BookRepository : Repository<BookEntity>
    {
        public BookRepository( ILogger<Repository<BookEntity>> logger, IConfiguration configuration ) : base( logger, configuration )
        {
        }

        /// <summary>
        /// Busca um livro pelo keyId 
        /// </summary>
        /// <param name="keyId">KeyId</param>
        /// <returns>Entidade encontrada</returns>
        public override BookEntity FindByKeyId( Guid keyId )
        {
            string sqlQuery = "select id, keyid, title, subtitle, publisher, author, edition, yearedition, active from book where keyid = @KeyId";

            DynamicParameters parameters = new DynamicParameters( );
            parameters.Add( "@KeyId", keyId );

            return base.ExecuteQuery( sqlQuery, parameters ).FirstOrDefault( );
        }
    }
}
