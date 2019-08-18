using ShareBooks.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareBooks.Business.Interfaces
{
    public interface IReaderBusiness
    {
        List<ReaderModel> ListAll( );
        ReaderModel GetByKeyId( Guid keyId );
        ReaderModel Insert( ReaderModel reader );
        ReaderModel Update( ReaderModel reader );
    }
}
