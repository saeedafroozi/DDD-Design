using DataAccess.DBContext;
using Domain.DataModel;
using Domain.RepositoryContract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.Repository
{
    internal class GoodRepository: Repository<Good, int>,IGoodRepository
    {
        //private readonly IConfiguration _config;
        public GoodRepository(IDbContext dbContext) :base(dbContext)
        {

        }


        public Good Get(int id) {
            return base.Get(id,string.Empty);
        }
    }
}
