using Dapper.FastCrud;
using Domain.RepositoryContract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    internal class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        // private readonly IConfiguration _config;
        private TimeSpan commandTimeout = TimeSpan.FromSeconds(120);
        private readonly IDbContext dbContext;


        public Repository(IDbContext dbContext)
        {
            dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Func<SqlConnection> Connection
        {
            get
            {
                return new Func<SqlConnection>(()=>new SqlConnection(dbContext.Connection.ToString()));
            }
        }

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
            using (var connection = Connection.Invoke())
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
            using (var connection = Connection.Invoke())
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


        public TEntity Get(TPrimaryKey primaryKey, string condition)
        {
            using (var connection = Connection.Invoke())
            {
                connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    var result = connection.Find<TEntity>(statement =>
                    {
                        statement.AttachToTransaction(transaction)
                                         .WithTimeout(this.commandTimeout)
                                         .Top(1);

                        if (!string.IsNullOrEmpty(condition))
                            statement.Where($"{condition}");


                    })
            .SingleOrDefault();
                    transaction.Commit();
                    return result;

                }
            }
        }


        //      TEntity Get(TPrimaryKey primaryKey, bool excludeDeleted);


        //      TEntity Get(TEntity entity);
    }
}
