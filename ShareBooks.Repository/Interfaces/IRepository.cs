using ShareBooks.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareBooks.Repository.Interfaces
{
    public interface IRepository <T> where T : Entity
    {
        List<T> FindAll( );
        T Insert( T obj );
        T Update( T obj );
    }
}
