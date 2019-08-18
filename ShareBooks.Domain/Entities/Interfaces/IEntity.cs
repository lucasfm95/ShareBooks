using System;
using System.Collections.Generic;
using System.Text;

namespace ShareBooks.Domain.Entities.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        Guid KeyId { get; }
    }
}
