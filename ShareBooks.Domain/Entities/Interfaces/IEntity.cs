using System;
using System.Collections.Generic;
using System.Text;

namespace ShareBooks.Domain.Entities.Interfaces
{
    public interface IEntity
    {
        long Id { get; set; }
        Guid Key { get; }
    }
}
