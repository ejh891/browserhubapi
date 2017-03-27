using System.Threading.Tasks;
using MongoDB.Driver;
using browserhubapi.Models;
using System.Collections.Generic;

namespace browserhubapi.Data {
    public interface IBookmarksRepository
    {
        Task<IEnumerable<Bookmark>> GetAllBookmarks();
        Task<Bookmark> GetBookmark(string id);
        Task AddBookmark(Bookmark item);
        Task<DeleteResult> RemoveBookmark(string id);
        Task<ReplaceOneResult> ReplaceBookmark(string id, Bookmark item);
    }
}