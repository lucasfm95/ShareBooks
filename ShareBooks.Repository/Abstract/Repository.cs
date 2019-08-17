using ShareBooks.Domain.Entities.Abstract;
using ShareBooks.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareBooks.Repository.Abstract
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        public List<T> FindAll( )
        {
            throw new NotImplementedException( );
        }

        public T Insert( T obj )
        {
            throw new NotImplementedException( );
        }

        public T Update( T obj )
        {
            throw new NotImplementedException( );
        }
    }
}
