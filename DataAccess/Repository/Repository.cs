using Dapper.FastCrud;
using Domain.DataModel;
using Domain.RepositoryContract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    internal abstract class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        private readonly IConfiguration _config;

        public Repository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection dbConnection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("Default"));
            }
        }
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            using (var conn = dbConnection)
            {
                var result = await dbConnection.FindAsync<TEntity>();
                return result;
            }
        }



    }
}
