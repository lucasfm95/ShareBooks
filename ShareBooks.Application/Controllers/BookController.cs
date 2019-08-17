using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShareBooks.Domain.Models;
using ShareBooks.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ShareBooks.Application.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _bookServices;
        private readonly ILogger<BookController> _logger;
        public BookController( IBookServices bookServices, ILogger<BookController> logger )
        {
            _bookServices = bookServices;
            _logger = logger;
        }

        /// <summary>
        /// Lista todos os livros
        /// </summary>
        /// <returns>Lista de livros</returns>
        [HttpGet]
        [ProducesResponseType( typeof( List<BookModel> ), ( int )HttpStatusCode.OK )]
        public async Task<IActionResult> Get( )
        {
            IActionResult result;
            try
            {
                List<BookModel> bookModels = _bookServices.GetAll( );

                if ( bookModels.Count > 0 )
                {
                    result = Ok( bookModels );
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
        /// Busca um livro
        /// </summary>
        /// <param name="keyId">Identificador único do livro</param>
        /// <returns>Livro</returns>
        [HttpGet( "{keyId}" )]
        [ProducesResponseType( typeof( BookModel ), ( int )HttpStatusCode.OK )]
        public async Task<IActionResult> GetByKeyId( [FromRoute] Guid keyId )
        {
            IActionResult result = null;
            try
            {
                BookModel bookModel = _bookServices.GetByKeyId( keyId );
                if ( bookModel != null )
                {
                    result = Ok( bookModel );
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
        /// Adiciona um livro
        /// </summary>
        /// <returns>Ok Result</returns>
        [HttpPost]
        public async Task<IActionResult> Post( [FromBody] BookModel bookModel )
        {
            IActionResult result;
            try
            {
                if ( _bookServices.Insert( bookModel ) != null )
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
        /// Alterar um livro
        /// </summary>
        /// <param name="bookModel"></param>
        /// <returns>Ok Result</returns>
        [HttpPut]
        public async Task<IActionResult> Put( [FromBody] BookModel bookModel )
        {
            IActionResult result;
            try
            {
                if ( _bookServices.Update( bookModel ) != null )
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