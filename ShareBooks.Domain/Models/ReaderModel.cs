using ShareBooks.Domain.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareBooks.Domain.Models
{
    public class ReaderModel : Model
    {
        public string Name { get; set; }
        public string IdentityDocument { get; set; }
        public string Email { get; set; }
    }
}
