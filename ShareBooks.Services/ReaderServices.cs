using ShareBooks.Business.Interfaces;
using ShareBooks.Domain.Models;
using ShareBooks.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareBooks.Services
{
    /// <summary>
    /// Camada service do reader
    /// </summary>
    public class ReaderServices : IReaderServices
    {
        private readonly IReaderBusiness _readerBusiness;
        public ReaderServices( IReaderBusiness readerBusiness  )
        {
            _readerBusiness = readerBusiness;
        }

        /// <summary>
        /// Busca todos os leitores chamando a camada business
        /// </summary>
        /// <returns>Lista de leitores</returns>
        public List<ReaderModel> GetAll( )
        {
            return _readerBusiness.ListAll( );
        }

        /// <summary>
        /// Busca um leitores pelo guid chamando a camada business
        /// </summary>
        /// <param name="keyId">KeyId do leitor</param>
        /// <returns>Leitor encontrado</returns>
        public ReaderModel GetByKeyId( Guid keyId )
        {
            return _readerBusiness.GetByKeyId( keyId );
        }

        /// <summary>
        /// Inseri um leitor chamando a camada de business 
        /// </summary>
        /// <param name="reader">Leitor que será inserido</param>
        /// <returns>Leitor inserido</returns>
        public ReaderModel Insert( ReaderModel reader )
        {
            return _readerBusiness.Insert( reader );
        }

        /// <summary>
        /// Alterar um leitor chamando a camada de business
        /// </summary>
        /// <param name="reader">Leitor que será alterado</param>
        /// <returns>Leitor alterado</returns>
        public ReaderModel Update( ReaderModel reader )
        {
            return _readerBusiness.Update( reader );
        }
    }
}
