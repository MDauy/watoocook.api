using System.Linq.Expressions;

namespace MongoDBWrapper.Repositories
{
    /// <summary>
    /// Generic BaseRepository to use to access any collection.
    /// </summary>
    /// <typeparam name="T">Any Document type.</typeparam>
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Get T object from id.
        /// </summary>
        /// <param name="id">ObjectId</param>
        /// <returns>Searched Document.</returns>
        Task<T> Get(string id);

        /// <summary>
        /// Insert complete DAO to targeted collection.
        /// </summary>
        /// <param name="document">DAO to insert.</param>
        /// <returns>Inserted DAO.</returns>
        Task<T> Insert(T document);

        /// <summary>
        /// Delete specidif document from database.
        /// </summary>
        /// <param name="document">Document to delete.</param>
        /// <returns>Deletion success.</returns>
        Task<bool> Delete(T document);

        /// <summary>
        /// Update complete document.
        /// </summary>
        /// <param name="document">Document to update.</param>
        /// <returns>Update success.</returns>
        Task<bool> Update(T document);

        /// <summary>
        /// Get documents corresponding to a statement.
        /// </summary>
        /// <param name="expression">Statement that must be verified to retrieve documents.</param>
        /// <returns>Corresponding documents.</returns>
        Task<IList<T>> Get(Expression<Func<T, bool>> expression);
    }
}
