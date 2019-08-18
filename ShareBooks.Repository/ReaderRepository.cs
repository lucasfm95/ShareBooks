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
    public class ReaderRepository : Repository<ReaderEntity>
    {
        public ReaderRepository( ILogger<Repository<ReaderEntity>> logger, IConfiguration configuration ) : base( logger, configuration )
        {
        }

        /// <summary>
        /// Busca leitor pelo keyId
        /// </summary>
        /// <param name="keyId">KeyId</param>
        /// <returns>Leitor encontrado</returns>
        public override ReaderEntity FindByKeyId( Guid keyId )
        {
            string sqlQuery = "select id, keyid, name, identitydocument, email from reader where keyid = @KeyId";

            DynamicParameters parameters = new DynamicParameters( );
            parameters.Add( "@KeyId", keyId );

            return base.ExecuteQuery( sqlQuery, parameters ).FirstOrDefault( );
        }
    }
}
