using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryContract
{

    public interface IRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        /// <summary>
        /// Inserts a row into the database, updating its properties based on the database generated fields.
        /// </summary>
        /// <param name= "entity">The entity you wish to insert.</param>
         Task Insert(TEntity entity);

        //      /// <summary>
        //      /// Inserts a range of records in the database.
        //      /// </summary>
        //      /// <param name="entities">The entities you wish to insert.</param>
        //      void InsertRange(IEnumerable<TEntity> entities);



        /// <summary>
        /// Updates a record in the database.
        /// </summary>
        /// <param name="entity">The entity you wish to update.</param>
        Task<bool> Update(TEntity entity);

        //      /// <summary>
        //      /// Updates a range of records in the database.
        //      /// </summary>
        //      /// <param name="entities">The entities you wish to update.</param>
        //      void UpdateRange(IEnumerable<TEntity> entities);
        //      /// <summary>
        ///// Counts all the records in the table.
        ///// </summary>
        ///// <returns>The record count</returns>
        //int Count();

        //      /// <summary>
        //      ///	Check exists any record in the table.
        //      /// </summary>
        //      /// <returns>True if any record exists, Otherwise false</returns>
        //      bool Exists();

        //      /// <summary>
        //      /// Queries the database for a single record based on its primary key.
        //      /// </summary>
        //      /// <param name="primaryKey">Value of primary key field used for filtering.</param>
        //      /// <returns>Returns single record based on its Guid value</returns>
        //      TEntity Get(TPrimaryKey primaryKey);

        //      /// <summary>
        //      /// Queries the database for a single record based on its primary key and deleted filter.
        //      /// </summary>
        //      /// <param name="primaryKey">Value of primary key field used for filtering.</param>
        //      /// <param name="excludeDeleted">Include deleted record.</param>
        //      /// <returns>Returns single record based on its Guid value</returns>
        //      TEntity Get(TPrimaryKey primaryKey, bool excludeDeleted);

        //      /// <summary>
        //      /// Queries the database for a single record based on its primary keys and deleted filter.
        //      /// </summary>
        //      /// <param name="entity">The entity from which the primary keys will be extracted and used for filtering.</param>
        //      /// <returns>Returns single record based on its primary keys</returns>
             TEntity Get(TPrimaryKey primaryKey, string condition);
    }

}
