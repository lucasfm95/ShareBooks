using Dapper.Contrib.Extensions;
using ShareBooks.Domain.Entities.Interfaces;
using System;

namespace ShareBooks.Domain.Entities.Abstract
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
        public Guid KeyId { get; set; }
    }
}
