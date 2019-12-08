using DataAccess.DBContext;
using Domain.DataModel;
using Domain.RepositoryContract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    internal sealed class GoodRepository: Repository<Good, int>,IGoodRepository
    {
        private readonly IConfiguration _config;
        public GoodRepository(IConfiguration config) :base(config)
        {

        }
        public async Task<IEnumerable<Good>> GetAllGoods()
        {
           return await base.GetAllAsync();
        }

    }
}
