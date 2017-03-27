using System.Threading.Tasks;
using browserhubapi.Data;
using browserhubapi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace browserhubapi.Controllers
{
    [Route("api/[controller]")]
    public class BookmarksController : Controller
    {
        private readonly IBookmarksRepository _bookmarksRepository;

        public BookmarksController(IBookmarksRepository bookmarksRepository)
        {
            _bookmarksRepository = bookmarksRepository;
        }

        // GET api/bookmarks
        [HttpGet]
        public async Task<string> Get()
        {
            var bookmarks = await _bookmarksRepository.GetAllBookmarks();
            return JsonConvert.SerializeObject(bookmarks);
        }

        // GET api/bookmarks/{id}
        [HttpGet("{id}")]
        public async Task<string> Get(string id)
        {
            var bookmark = await _bookmarksRepository.GetBookmark(id) ?? new Bookmark();
            return JsonConvert.SerializeObject(bookmark);
        }

        // POST api/bookmarks
        [HttpPost]
        public void Post([FromBody]Bookmark bookmark)
        {
            _bookmarksRepository.AddBookmark(bookmark);
        }

        // PUT api/bookmarks/{id}
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Bookmark bookmark)
        {
            _bookmarksRepository.ReplaceBookmark(id, bookmark);
        }

        // DELETE api/bookmarks/{id}
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _bookmarksRepository.RemoveBookmark(id);
        }
    }
}
