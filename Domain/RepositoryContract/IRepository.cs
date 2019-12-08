using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryContract
{

    public interface IRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        IDbConnection dbConnection { get;}
        Task<IEnumerable<TEntity>> GetAllAsync();
    }

}
