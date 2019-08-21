using AutoMapper;
using ShareBooks.Business.Interfaces;
using ShareBooks.Domain.Entities;
using ShareBooks.Domain.Models;
using ShareBooks.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace ShareBooks.Business
{
    /// <summary>
    /// Camada business do book
    /// </summary>
    public class BookBusiness : IBookBusiness
    {
        private readonly IRepository<BookEntity> _repository;
        private readonly IMapper _mapper;
        public BookBusiness( IRepository<BookEntity> repository, IMapper mapper )
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Busca um livro chamando o repository e converte para o model
        /// </summary>
        /// <param name="keyId">KeyId do livro</param>
        /// <returns>Livro encontrado</returns>
        public BookModel GetByKeyId( Guid keyId )
        {
            BookEntity bookEntity = _repository.FindByKeyId( keyId );
            return _mapper.Map<BookModel>( bookEntity );
        }

        /// <summary>
        /// Converte o model na entidade e chama o repository para inserir
        /// </summary>
        /// <param name="book">Livro que será inserido</param>
        /// <returns>Livro inserido</returns>
        public BookModel Insert( BookModel book )
        {
            BookEntity bookEntity = _mapper.Map<BookEntity>( book );
            bookEntity.KeyId = Guid.NewGuid( );

            bookEntity = _repository.Insert( bookEntity );

            return _mapper.Map<BookModel>( bookEntity );
        }

        /// <summary>
        /// Busca todos livros e converte lista entidade em model 
        /// </summary>
        /// <returns>Lista de livros</returns>
        public List<BookModel> ListAll( )
        {
            List<BookEntity> bookEntities = _repository.FindAll( );

            return _mapper.Map<List<BookModel>>( bookEntities );
        }

        /// <summary>
        /// Converte o model em entidade e chama o repository para alterar
        /// </summary>
        /// <param name="book">Livro que será alterado</param>
        /// <returns>Livro Alterado</returns>
        public BookModel Update( BookModel book )
        {
            BookEntity bookEntity = _mapper.Map<BookEntity>( book );
            bookEntity.Id = _repository.FindByKeyId( bookEntity.KeyId ).Id;

            bookEntity = _repository.Update( bookEntity );

            return _mapper.Map<BookModel>( bookEntity );
        }

        /// <summary>
        /// Busca id do livro de acordo com a keyId
        /// </summary>
        /// <param name="keyId">KeyId do livro</param>
        /// <returns>Id do livro</returns>
        public int GetIdBookByKeyId( Guid keyId )
        {
            return _repository.FindByKeyId( keyId ).Id;
        }

        /// <summary>
        /// Busca livro pelo id
        /// </summary>
        /// <param name="id">Id livro</param>
        /// <returns>Entidade livro</returns>
        public BookEntity GetBookById( int id )
        {
            return _repository.FindById( id );
        }
    }
}
