using AutoMapper;
using ShareBooks.Domain.Entities;
using ShareBooks.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareBooks.Application.AutoMapper.Profiles
{
    public class ModelToDomain : Profile
    {
        public ModelToDomain( )
        {
            CreateMap<BookModel, BookEntity>( );
            CreateMap<ReaderModel, ReaderEntity>( );
        }
    }
}
