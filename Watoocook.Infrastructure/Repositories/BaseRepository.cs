using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBWrapper.Documents;
using System.Linq.Expressions;

namespace MongoDBWrapper.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseDocument, new()
    {
        private IMongoCollection<T> _collection;
        protected IMongoDatabase Db;
        private readonly string _collectionName;

        public IMongoCollection<T> Collection
        {
            get
            {
                if (_collection == null)
                {
                    var collections = Db.ListCollectionNames().ToList();
                    if (!collections.Contains(_collectionName))
                    {
                        Db.CreateCollection(_collectionName);
                    }
                    _collection = Db.GetCollection<T>(_collectionName);
                }
                return _collection;
            }
        }

        public BaseRepository()
        {
            Db = DataBaseAccess.Db;
            _collectionName = typeof(T).ToString().ToLower();
        }

            public Task<bool> Delete(T document)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Get(string id)
        {
            try
            {
                var objectId = new ObjectId(id);
                var document = await Collection.FindAsync(d => d.Oid == objectId);
                return document.FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, new Exception(
                    $"Object {id} in collection {_collectionName} has not been found"));
            }
        }

        public async Task<IList<T>> Get(Expression<Func<T, bool>> expression)
        {
            var documents = await Collection.FindAsync<T>(expression);
            return documents.ToList();
        }

        public async Task<T> Insert(T document)
        {
            await Collection.InsertOneAsync(document);
            return document;
        }

        public async Task<bool> Update(T document)
        {
            var result = await Collection.ReplaceOneAsync(s => s.Oid == document.Oid, document);

            if (result.IsModifiedCountAvailable && result.ModifiedCount == 1)
            {
                return true;
            }
            else
            {
                throw new Exception(
                    $"Update with {document.GetType()} {document.Oid} went wrong : maybe not found or two many suggestions with same id");
            }
        }
    }
}