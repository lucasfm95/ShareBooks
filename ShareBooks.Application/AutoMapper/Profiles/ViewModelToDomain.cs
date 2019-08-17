using AutoMapper;
using ShareBooks.Application.ViewModels;
using ShareBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareBooks.Application.AutoMapper.Profiles
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain( )
        {
            CreateMap<BookViewModel, BookEntity>( );
        }
    }
}
