using AutoMapper;
using ShareBooks.Domain.Entities;
using ShareBooks.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareBooks.Application.AutoMapper.Profiles
{
    public class DomainToModel : Profile
    {
        public DomainToModel( )
        {
            CreateMap<BookEntity, BookModel>( );
            CreateMap<ReaderEntity, ReaderModel>( );
            CreateMap<BookLoanEntity, BookLoanModel>( );
        }
    }
}
