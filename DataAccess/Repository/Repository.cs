using Dapper.FastCrud;
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
    internal class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        private readonly IConfiguration _config;
        private TimeSpan commandTimeout = TimeSpan.FromSeconds(120);
        private readonly Func<SqlConnection> _dbConnectionFactory;


        public Repository(Func<SqlConnection> dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory ?? throw new ArgumentNullException(nameof(dbConnectionFactory));
        }

        //public IDbConnection Connection
        //{
        //    get
        //    {
        //        return new SqlConnection(_config.GetConnectionString("MyConnectionString"));
        //    }
        //}

        public async Task Insert(TEntity entity)
        {
            //using (IDbConnection conn = Connection)
            //{
            //   // string sQuery = "SELECT ID, FirstName, LastName, DateOfBirth FROM Employee WHERE ID = @ID";
            //    conn.Open();
            //    var result = await conn.QueryAsync<Employee>(sQuery, new { ID = id });
            //    return result.FirstOrDefault();
            //}
            //Connection.Insert(entity, statement => statement.AttachToTransaction(Transaction).WithTimeout(commandTimeout));
            using (var connection = _dbConnectionFactory.Invoke())
            {
                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        //var result = await command(connection, transaction, Constants.CommandTimeout);
                        await connection.InsertAsync(entity, statement => statement.AttachToTransaction(transaction).WithTimeout(commandTimeout));
                        transaction.Commit();

                        /// return result;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        //Logger.Instance.Error(ex);
                        throw;
                    }
                }
            }
        }


        //      void InsertRange(IEnumerable<TEntity> entities);




        public async Task<bool> Update(TEntity entity)
        {
            using (var connection = _dbConnectionFactory.Invoke())
            {
                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var result = await connection.UpdateAsync(entity, statement => statement.AttachToTransaction(transaction).WithTimeout(commandTimeout));

                        transaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        //Logger.Instance.Error(ex);
                        throw;
                    }
                }
            }
        }


        //      void UpdateRange(IEnumerable<TEntity> entities);

        //int Count();


        //      bool Exists();


        TEntity Get(TPrimaryKey primaryKey)
        {
            using (var connection = _dbConnectionFactory.Invoke())
            {
                connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    var result = connection.Find(statement=> statement.Top(1));
                    transaction.Commit();
                    return result;

                }
            }
        }


        //      TEntity Get(TPrimaryKey primaryKey, bool excludeDeleted);


        //      TEntity Get(TEntity entity);
    }
}
