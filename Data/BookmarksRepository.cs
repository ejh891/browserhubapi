using System.Collections.Generic;
using System.Threading.Tasks;
using browserhubapi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace browserhubapi.Data {
    public class BookmarksRepository : IBookmarksRepository
    {
        private readonly BrowserHubDbContext _context = null;

        public BookmarksRepository(IOptions<Settings> settings)
        {
            _context = new BrowserHubDbContext(settings);
        }

        public async Task<IEnumerable<Bookmark>> GetAllBookmarks()
        {
            return await _context.Bookmarks.Find(_ => true).ToListAsync();
        }

        public async Task<Bookmark> GetBookmark(string id)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<Bookmark>.Filter.Eq("ObjectId", objectId);
            return await _context.Bookmarks
                                .Find(filter)
                                .FirstOrDefaultAsync();
        }

        public async Task AddBookmark(Bookmark item)
        {
            await _context.Bookmarks.InsertOneAsync(item);
        }

        public async Task<DeleteResult> RemoveBookmark(string id)
        {
            var objectId = new ObjectId(id);
            return await _context.Bookmarks.DeleteOneAsync(
                        Builders<Bookmark>.Filter.Eq("ObjectId", objectId));
        }

        public async Task<ReplaceOneResult> ReplaceBookmark(string id, Bookmark item)
        {
            var objectId = new ObjectId(id);
            item.ObjectId = objectId;

            return await _context.Bookmarks
                                .ReplaceOneAsync(Builders<Bookmark>.Filter.Eq("ObjectId", objectId)
                                                    , item
                                                    , new UpdateOptions { IsUpsert = true });
        }
    }
}