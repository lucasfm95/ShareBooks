using System;
using System.Collections.Generic;
using System.Text;

namespace ShareBooks.Domain.Models
{
    public class BookLoanModel
    {
        public Guid BookKeyId { get; set; }
        public Guid ReaderKeyId { get; set; }
        public DateTime BookLoanDate { get; set; }
        public string BookLoanFeedback { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string ReturnFeedback { get; set; }
    }
}
