using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareBooks.Application.ViewModels
{
    public class BookViewModel
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
