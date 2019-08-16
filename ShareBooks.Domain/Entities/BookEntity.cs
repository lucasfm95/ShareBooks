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
    }
}
