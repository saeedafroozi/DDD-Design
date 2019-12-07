using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Domain.RepositoryContract
{
    public interface IDbContext
    {
        IDbConnection Connection { get;}
    }
}
