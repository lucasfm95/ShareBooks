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
    }
}