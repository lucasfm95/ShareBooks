using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShareBooks.Application.ViewModels;
using ShareBooks.Domain.Entities;
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
        private readonly IMapper _mapper;
        private readonly ILogger<BookController> _logger;
        public BookController( IBookServices bookServices, IMapper mapper, ILogger<BookController> logger )
        {
            _bookServices = bookServices;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Lista todos os livros
        /// </summary>
        /// <returns>Lista de livros</returns>
        [HttpGet]
        [ProducesResponseType( typeof( List<BookViewModel> ), ( int )HttpStatusCode.OK )]
        public async Task<IActionResult> Get( )
        {
            IActionResult result;
            try
            {
                List<BookEntity> bookEntities = _bookServices.GetAll( );

                List<BookViewModel> bookViewModels = _mapper.Map<List<BookViewModel>>( bookEntities );

                if ( bookViewModels.Count > 0 )
                {
                    result = Ok( bookViewModels );
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
        [ProducesResponseType( typeof( BookViewModel ), ( int )HttpStatusCode.OK )]
        public async Task<IActionResult> GetByKeyId( [FromRoute] Guid keyId )
        {
            IActionResult result = null;
            try
            {
                BookEntity bookEntity = _bookServices.GetByKeyId( keyId );
                BookViewModel bookViewModel = _mapper.Map<BookViewModel>( bookEntity );
                if ( bookViewModel != null )
                {
                    result = Ok( bookViewModel );
                }
                else
                {
                    result = NoContent( );
                }
            }
            catch ( Exception ex)
            {
                _logger.LogError( ex, ex.Message );
                result = new StatusCodeResult( 500 );
            }

            return result;
        }

        /// <summary>
        /// Adiciona um livro
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post( [FromBody] BookViewModel bookViewModel )
        {
            IActionResult result;
            try
            {
                BookEntity book = _mapper.Map<BookEntity>( bookViewModel );
                if ( _bookServices.Insert( book ) != null )
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