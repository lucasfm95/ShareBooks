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
    /// <summary>
    /// Camada business do reader
    /// </summary>
    public class ReaderBusiness : IReaderBusiness
    {
        private readonly IRepository<ReaderEntity> _repository;
        private readonly IMapper _mapper;

        public ReaderBusiness( IRepository<ReaderEntity> repository, IMapper mapper )
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Busca um leitor chamando o repository e converte para o model
        /// </summary>
        /// <param name="keyId">KeyId do leitor</param>
        /// <returns>Leitor encontrado</returns>
        public ReaderModel GetByKeyId( Guid keyId )
        {
            ReaderEntity readerEntity = _repository.FindByKeyId( keyId );
            return _mapper.Map<ReaderModel>( readerEntity );
        }

        /// <summary>
        /// Converte o model na entidade e chama o repository para inserir
        /// </summary>
        /// <param name="reader">Leitor que será inserido</param>
        /// <returns>Leitor inserido</returns>
        public ReaderModel Insert( ReaderModel reader )
        {
            ReaderEntity readerEntity = _mapper.Map<ReaderEntity>( reader );
            readerEntity.KeyId = Guid.NewGuid( );

            readerEntity = _repository.Insert( readerEntity );

            return _mapper.Map<ReaderModel>( readerEntity );
        }

        /// <summary>
        /// Busca todos leitores e converte lista entidade em model 
        /// </summary>
        /// <returns>Lista de leitores</returns>
        public List<ReaderModel> ListAll( )
        {
            List<ReaderEntity> readerEntity = _repository.FindAll( );

            return _mapper.Map<List<ReaderModel>>( readerEntity );
        }

        /// <summary>
        /// Converte o model em entidade e chama o repository para alterar
        /// </summary>
        /// <param name="reader">Leitor que será alterado</param>
        /// <returns>Leitor Alterado</returns>
        public ReaderModel Update( ReaderModel reader )
        {
            ReaderEntity readerEntity = _mapper.Map<ReaderEntity>( reader );
            readerEntity.Id = _repository.FindByKeyId( readerEntity.KeyId ).Id;

            readerEntity = _repository.Update( readerEntity );

            return _mapper.Map<ReaderModel>( readerEntity );
        }

        /// <summary>
        /// Busca id do leitor de acordo com a keyId
        /// </summary>
        /// <param name="keyId">KeyId do leitor</param>
        /// <returns>Id do leitor</returns>
        public int GetIdBookByKeyId( Guid keyId )
        {
            return _repository.FindByKeyId( keyId ).Id;
        }

        /// <summary>
        /// Busca leitor pelo id
        /// </summary>
        /// <param name="id">Id leitor</param>
        /// <returns>Entidade leitor</returns>
        public ReaderEntity GetReaderById( int id )
        {
            return _repository.FindById( id );
        }
    }
}
