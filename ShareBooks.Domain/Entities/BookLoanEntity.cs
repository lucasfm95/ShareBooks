using ShareBooks.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShareBooks.Domain.Entities
{
    [Table( "BookLoan" )]
    public sealed class BookLoanEntity : Entity
    {
        public int BookId { get; set; }
        public int ReaderId { get; set; }
        public DateTime BookLoanDate { get; set; }
        public string BookLoanFeedback { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string ReturnFeedback { get; set; }
    }
}
