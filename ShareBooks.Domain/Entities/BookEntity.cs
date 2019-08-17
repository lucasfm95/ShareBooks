﻿using ShareBooks.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareBooks.Domain.Entities
{
    public sealed class BookEntity : Entity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public string Edition { get; set; }
        public string YearEdition { get; set; }
        public bool Active { get; set; }
    }
}
