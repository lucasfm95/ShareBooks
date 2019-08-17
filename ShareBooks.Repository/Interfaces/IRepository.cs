using Dapper;
using ShareBooks.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareBooks.Repository.Interfaces
{
    public interface IRepository <T> where T : Entity
    {
        List<T> FindAll( );
        T FindById( int id );
        T FindByKeyId( Guid keyId );
        List<T> ExecuteQuery( string query, DynamicParameters parameters = null );
        T Insert( T obj );
        T Update( T obj );
        
    }
}
