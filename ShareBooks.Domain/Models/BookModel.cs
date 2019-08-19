using ShareBooks.Domain.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareBooks.Domain.Models
{
    public class BookModel : Model
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
