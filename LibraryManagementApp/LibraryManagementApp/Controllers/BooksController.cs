using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Services.Contracts;
using System.Net.Http.Headers;

namespace LibraryManagementApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.BookService.GetAllBooks(false);
            return View(model);
           
        }

        public IActionResult Get([FromRoute(Name ="id")]int id)
        {
            var model = _manager.BookService.GetOneBook(id,false);
            return View(model);

        }

    }
}
