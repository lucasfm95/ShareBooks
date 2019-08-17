using ShareBooks.Business.Interfaces;
using ShareBooks.Domain.Models;
using ShareBooks.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace ShareBooks.Services
{
    /// <summary>
    /// Camada service do book
    /// </summary>
    public class BookServices : IBookServices
    {
        private readonly IBookBusiness _bookBusiness;
        public BookServices( IBookBusiness bookBusiness )
        {
            _bookBusiness = bookBusiness;
        }

        /// <summary>
        /// Busca todos os livros chamando a camada business
        /// </summary>
        /// <returns>Lista de livros</returns>
        public List<BookModel> GetAll( )
        {
            return _bookBusiness.ListAll( );
        }

        /// <summary>
        /// Busca um livro pelo guid chamando a camada business
        /// </summary>
        /// <param name="keyId">KeyId do livro</param>
        /// <returns>Livro encontrado</returns>
        public BookModel GetByKeyId( Guid keyId )
        {
            return _bookBusiness.GetByKeyId( keyId );
        }

        /// <summary>
        /// Inseri um livro chamando a camada de business 
        /// </summary>
        /// <param name="book">Livro que será inserido</param>
        /// <returns>Livro inserido</returns>
        public BookModel Insert( BookModel book )
        {
            return _bookBusiness.Insert( book );
        }

        /// <summary>
        /// Alterar um livro chamando a camada de business
        /// </summary>
        /// <param name="book">Livro que será alterado</param>
        /// <returns>Livro alterado</returns>
        public BookModel Update( BookModel book )
        {
            return _bookBusiness.Update( book );
        }
    }
}
