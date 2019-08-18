using ShareBooks.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareBooks.Domain.Entities
{
    public sealed class ReaderEntity : Entity
    {
        public string Name { get; set; }
        public string RegisterNumber { get; set; }
        public DateTime DateBirth { get; set; }
    }
}
