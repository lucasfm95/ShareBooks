using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShareBooks.Domain.Models;
using ShareBooks.Services;
using ShareBooks.Services.Interfaces;

namespace ShareBooks.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderController : ControllerBase
    {
        private readonly IReaderServices _readerServices;
        private readonly ILogger<ReaderController> _logger;

        public ReaderController( IReaderServices readerServices, ILogger<ReaderController> logger )
        {
            _readerServices = readerServices;
            _logger = logger;
        }

        /// <summary>
        /// Lista todos os leitores
        /// </summary>
        /// <returns>Lista de leitores</returns>
        [HttpGet]
        [ProducesResponseType( typeof( List<ReaderModel> ), ( int )HttpStatusCode.OK )]
        public async Task<IActionResult> Get( )
        {
            IActionResult result;
            try
            {
                List<ReaderModel> readerModels = _readerServices.GetAll( );

                if ( readerModels.Count > 0 )
                {
                    result = Ok( readerModels );
                }
                else
                {
                    result = NoContent( );
                }
            }
            catch ( Exception ex )
            {
                _logger.LogError( ex, ex.Message );
                result = new StatusCodeResult( 500 );
            }

            return result;
        }

        /// <summary>
        /// Busca um leitor
        /// </summary>
        /// <param name="keyId">Identificador único do leitor</param>
        /// <returns>Leitor</returns>
        [HttpGet( "{keyId}" )]
        [ProducesResponseType( typeof( ReaderModel ), ( int )HttpStatusCode.OK )]
        public async Task<IActionResult> GetByKeyId( [FromRoute] Guid keyId )
        {
            IActionResult result = null;
            try
            {
                ReaderModel readerModel = _readerServices.GetByKeyId( keyId );
                if ( readerModel != null )
                {
                    result = Ok( readerModel );
                }
                else
                {
                    result = NoContent( );
                }
            }
            catch ( Exception ex )
            {
                _logger.LogError( ex, ex.Message );
                result = new StatusCodeResult( 500 );
            }

            return result;
        }

        /// <summary>
        /// Adiciona um leitor
        /// </summary>
        /// <param name="readerModel">Leitor que será inserido</param>
        /// <returns>Ok Result</returns>
        [HttpPost]
        public async Task<IActionResult> Post( [FromBody] ReaderModel readerModel )
        {
            IActionResult result;
            try
            {
                if ( _readerServices.Insert( readerModel ) != null )
                {
                    result = Ok( );
                }
                else
                {
                    result = new StatusCodeResult( 500 );
                }
            }
            catch ( Exception ex )
            {
                _logger.LogError( ex, ex.Message );
                result = new StatusCodeResult( 500 );
            }

            return result;
        }

        /// <summary>
        /// Alterar um leitor
        /// </summary>
        /// <param name="readerModel">Leitor para ser alterado</param>
        /// <returns>Ok Result</returns>
        [HttpPut]
        public async Task<IActionResult> Put( [FromBody] ReaderModel readerModel )
        {
            IActionResult result;
            try
            {
                if ( _readerServices.Update( readerModel ) != null )
                {
                    result = Ok( );
                }
                else
                {
                    result = new StatusCodeResult( 500 );
                }
            }
            catch ( Exception ex )
            {
                _logger.LogError( ex, ex.Message );
                result = new StatusCodeResult( 500 );
            }

            return result;
        }
    }
}