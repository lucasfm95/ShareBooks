using ShareBooks.Domain.Entities.Abstract;
using ShareBooks.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Text;
using Dapper.Contrib;
using Microsoft.Extensions.Configuration;
using Dapper.Contrib.Extensions;
using System.Linq;
using Dapper;

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

        public virtual List<T> FindAll( )
        {
            try
            {
                using ( SqlConnection connection = new Utilities.ConnectionFactory( ).GetConnection( _connectionString ) )
                {
                    return connection.GetAll<T>( ).ToList( );
                }
            }
            catch ( Exception ex)
            {
                _logger.LogError( ex, ex.Message );
                throw;
            }
        }

        public T FindById( int id )
        {
            try
            {
                using ( SqlConnection connection = new Utilities.ConnectionFactory().GetConnection( _connectionString ) )
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
            catch ( Exception ex)
            {
                _logger.LogError( ex, ex.Message );
                throw;
            }
        }

        public virtual T Update( T obj )
        {
            throw new NotImplementedException( );
        }

        public virtual T FindByKeyId( Guid keyId )
        {
            throw new NotImplementedException( );
        }
    }
}
