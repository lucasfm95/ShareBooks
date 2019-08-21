using AutoMapper;
using ShareBooks.Business.Interfaces;
using ShareBooks.Domain.Entities;
using ShareBooks.Domain.Models;
using ShareBooks.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareBooks.Business
{
    public class BookLoanBusiness : IBookLoanBusiness
    {
        private readonly IRepository<BookLoanEntity> _repository;
        private readonly IMapper _mapper;
        private readonly IBookBusiness _bookBusiness;
        private readonly IReaderBusiness _readerBusiness;

        public BookLoanBusiness( IRepository<BookLoanEntity> repository, IMapper mapper, IBookBusiness bookBusiness, IReaderBusiness readerBusiness )
        {
            _repository = repository;
            _mapper = mapper;
            _bookBusiness = bookBusiness;
            _readerBusiness = readerBusiness;
        }

        public BookLoanModel GetByKeyId( Guid keyId )
        {
            BookLoanEntity bookLoan = _repository.FindByKeyId( keyId );

            return ConvertEntityToModel( bookLoan );
        }

        public BookLoanModel Insert( BookLoanModel bookLoanModel )
        {
            BookLoanEntity bookLoanEntity = _mapper.Map<BookLoanEntity>( bookLoanModel );
            bookLoanEntity.KeyId = Guid.NewGuid( );
            bookLoanEntity.BookId = _bookBusiness.GetIdBookByKeyId( bookLoanModel.BookKeyId );
            bookLoanEntity.ReaderId = _readerBusiness.GetIdBookByKeyId( bookLoanModel.ReaderKeyId );
            bookLoanEntity.ReturnDate = null;
            bookLoanEntity.ReturnFeedback = null;

            bookLoanEntity = _repository.Insert( bookLoanEntity );

            BookLoanModel bookLoan = _mapper.Map<BookLoanModel>( bookLoanEntity );
            bookLoan.BookKeyId = bookLoanModel.BookKeyId;
            bookLoan.ReaderKeyId = bookLoanModel.ReaderKeyId;

            return bookLoan;
        }

        public List<BookLoanModel> ListAll( )
        {
            List<BookLoanEntity> bookLoanEntities = _repository.FindAll( );

            List<BookLoanModel> bookLoanModels = new List<BookLoanModel>( );

            foreach ( BookLoanEntity bookLoan in bookLoanEntities )
            {
                bookLoanModels.Add( ConvertEntityToModel( bookLoan ) );
            }

            return bookLoanModels;
        }

        public BookLoanModel Update( BookLoanModel bookLoanModel )
        {
            BookLoanEntity bookLoanEntity = _repository.FindByKeyId( bookLoanModel.KeyId );

            bookLoanEntity.ReturnDate = bookLoanModel.ReturnDate;
            bookLoanEntity.ReturnFeedback = bookLoanModel.ReturnFeedback;

            bookLoanEntity = _repository.Update( bookLoanEntity );

            BookLoanModel bookLoan = _mapper.Map<BookLoanModel>( bookLoanEntity );

            bookLoan.BookKeyId = bookLoanModel.BookKeyId;
            bookLoan.ReaderKeyId = bookLoanModel.ReaderKeyId;

            return bookLoan;
        }

        private BookLoanModel ConvertEntityToModel( BookLoanEntity bookLoanEntity )
        {
            BookLoanModel bookLoanModel = _mapper.Map<BookLoanModel>( bookLoanEntity );

            bookLoanModel.BookKeyId = _bookBusiness.GetBookById( bookLoanEntity.BookId ).KeyId;
            bookLoanModel.ReaderKeyId = _readerBusiness.GetReaderById( bookLoanEntity.ReaderId ).KeyId;

            return bookLoanModel;
        }
    }
}
