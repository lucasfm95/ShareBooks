using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShareBooks.Domain.Models;
using ShareBooks.Services.Interfaces;

namespace ShareBooks.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookLoanController : ControllerBase
    {
        private readonly IBookLoanServices _bookLoanServices;
        private readonly ILogger<BookLoanController> _logger;
        public BookLoanController( IBookLoanServices bookLoanServices, ILogger<BookLoanController> logger )
        {
            _bookLoanServices = bookLoanServices;
            _logger = logger;
        }

        /// <summary>
        /// Lista todos os empréstimos 
        /// </summary>
        /// <returns>Lista de empréstimos</returns>
        [HttpGet]
        [ProducesResponseType( typeof( List<BookLoanModel> ), ( int )HttpStatusCode.OK )]
        public async Task<IActionResult> Get( )
        {
            IActionResult result;
            try
            {
                List<BookLoanModel> bookLoanModels = _bookLoanServices.GetAll( );

                if ( bookLoanModels.Any() )
                {
                    result = Ok( bookLoanModels );
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
        /// Busca um empréstimo
        /// </summary>
        /// <param name="keyId">Identificador único do empréstimo</param>
        /// <returns>Empréstimo</returns>
        [HttpGet( "{keyId}" )]
        [ProducesResponseType( typeof( BookLoanModel ), ( int )HttpStatusCode.OK )]
        public async Task<IActionResult> GetByKeyId( [FromRoute] Guid keyId )
        {
            IActionResult result = null;
            try
            {
                BookLoanModel bookLoanModel = _bookLoanServices.GetByKeyId( keyId );
                if ( bookLoanModel != null )
                {
                    result = Ok( bookLoanModel );
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
        /// Adiciona um empréstimo
        /// </summary>
        /// <param name="readerModel">Empréstimo que será inserido</param>
        /// <returns>Ok Result</returns>
        [HttpPost]
        public async Task<IActionResult> Post( [FromBody] BookLoanModel bookLoanModel )
        {
            IActionResult result;
            try
            {
                if ( _bookLoanServices.Insert( bookLoanModel ) != null )
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
        /// Alterar um empréstimo
        /// </summary>
        /// <param name="readerModel">Empréstimo para ser alterado</param>
        /// <returns>Ok Result</returns>
        [HttpPut]
        public async Task<IActionResult> Put( [FromBody] BookLoanModel bookLoanModel )
        {
            IActionResult result;
            try
            {
                if ( _bookLoanServices.Update( bookLoanModel ) != null )
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