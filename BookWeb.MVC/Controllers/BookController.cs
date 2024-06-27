using BookWeb.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookWeb.MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly HttpClient _httpClient;
        public BookController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:44327/api/");
        }
        public async Task<IActionResult> Index()
        {
            var books = await _httpClient.GetFromJsonAsync<IEnumerable<BookViewModel>>("Book");
            return View(books);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookViewModel book)
        {
            await _httpClient.PostAsJsonAsync("Book", book);

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View(new BookViewModel());
        }

        public IActionResult DeleteBook(int id)
        {
            _httpClient.DeleteAsync($"Book/{id}");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(BookViewModel book)
        {
            _httpClient.PutAsJsonAsync("Book", book);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _httpClient.GetFromJsonAsync<BookViewModel>($"Book/{id}");
            return View(book);
        }
    }
}
