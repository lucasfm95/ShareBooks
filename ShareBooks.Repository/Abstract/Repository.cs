using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShareBooks.Domain.Entities.Abstract;
using ShareBooks.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ShareBooks.Repository.Abstract
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly ILogger<Repository<T>> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        protected Repository( ILogger<Repository<T>> logger, IConfiguration configuration )
        {
            _logger = logger;
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString( "DefaultConnection" );
        }

        /// <summary>
        /// Executa uma consulta de acordo com a query informada
        /// </summary>
        /// <param name="query">Query SQL</param>
        /// <param name="parameters">Parametros da query SQL</param>
        /// <returns>Lista da entidade</returns>
        public List<T> ExecuteQuery( string query, DynamicParameters parameters = null )
        {
            try
            {
                using ( SqlConnection connection = new Utilities.ConnectionFactory( ).GetConnection( _connectionString ) )
                {
                    if ( parameters == null )
                        return connection.Query<T>( query ).ToList( );

                    return connection.Query<T>( query, parameters ).ToList( );
                }
            }
            catch ( Exception ex )
            {
                _logger.LogError( ex, ex.Message );
                throw;
            }
        }

        /// <summary>
        /// Busca todos o registro de uma mesma entidade
        /// </summary>
        /// <returns>Lista da entidade</returns>
        public virtual List<T> FindAll( )
        {
            try
            {
                using ( SqlConnection connection = new Utilities.ConnectionFactory( ).GetConnection( _connectionString ) )
                {
                    return connection.GetAll<T>( ).ToList( );
                }
            }
            catch ( Exception ex )
            {
                _logger.LogError( ex, ex.Message );
                throw;
            }
        }

        /// <summary>
        /// Busca um registo da entidade pelo id
        /// </summary>
        /// <param name="id">Id do registro</param>
        /// <returns>Entidade encontrada</returns>
        public T FindById( int id )
        {
            try
            {
                using ( SqlConnection connection = new Utilities.ConnectionFactory( ).GetConnection( _connectionString ) )
                {
                    return connection.Get<T>( id );
                }
            }
            catch ( Exception ex )
            {
                _logger.LogError( ex, ex.Message );
                throw;
            }
        }

        /// <summary>
        /// Inseri entidade
        /// </summary>
        /// <param name="obj">Entidade</param>
        /// <returns>Entidade inserida</returns>
        public virtual T Insert( T obj )
        {
            try
            {
                using ( SqlConnection connection = new Utilities.ConnectionFactory( ).GetConnection( _connectionString ) )
                {
                    connection.Insert( obj );
                    return obj;
                }
            }
            catch ( Exception ex )
            {
                _logger.LogError( ex, ex.Message );
                throw;
            }
        }

        /// <summary>
        /// Altera entidade
        /// </summary>
        /// <param name="obj">Entidade</param>
        /// <returns>Entidade alterada</returns>
        public virtual T Update( T obj )
        {
            try
            {
                using ( SqlConnection connection = new Utilities.ConnectionFactory( ).GetConnection( _connectionString ) )
                {
                    connection.Update( obj );
                    return obj;
                }
            }
            catch ( Exception ex )
            {
                _logger.LogError( ex, ex.Message );
                throw;
            }
        }

        /// <summary>
        /// Busca entidade pelo keyId
        /// </summary>
        /// <param name="keyId">KeyId</param>
        /// <returns>Entidade encontrada</returns>
        public abstract T FindByKeyId( Guid keyId );
    }
}
