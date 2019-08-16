using ShareBooks.Domain.Entities.Interfaces;
using System;

namespace ShareBooks.Domain.Entities.Abstract
{
    public abstract class Entity : IEntity
    {
        public long Id { get; set; }
        public Guid Key { get; }

        protected Entity( )
        {
            Key = Guid.NewGuid( );
        }
    }
}
