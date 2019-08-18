using AutoMapper;
using ShareBooks.Application.AutoMapper.Profiles;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ShareBooks.Application.AutoMapper
{
    [ExcludeFromCodeCoverage]
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings( )
        {
            return new MapperConfiguration( ps =>
            {
                ps.AddProfile( new DomainToModel( ) );
                ps.AddProfile( new ModelToDomain( ) );
            } );
        }
    }
}
