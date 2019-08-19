using ShareBooks.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareBooks.Services.Interfaces
{
    public interface IReaderServices
    {
        List<ReaderModel> GetAll( );
        ReaderModel GetByKeyId( Guid keyId );
        ReaderModel Insert( ReaderModel reader );
        ReaderModel Update( ReaderModel reader );
    }
}
