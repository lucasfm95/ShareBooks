using AutoMapper;
using ShareBooks.Application.ViewModels;
using ShareBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareBooks.Application.AutoMapper.Profiles
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel( )
        {
            CreateMap<BookEntity, BookViewModel>( );
        }
    }
}
