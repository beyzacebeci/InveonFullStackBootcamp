using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace LibraryManagementApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly IServiceManager _manager;

        public BookController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.BookService.GetAllBooks(false);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public IActionResult Create([FromForm] Book book)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _manager.BookService.CreateBook(product);
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            var model = _manager.BookService.GetOneBook(id, false);
            return View(model);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Update(Book book)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _manager.BookService.UpdateOneBook(book);
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}


        //[HttpGet]
        //public IActionResult Delete([FromRoute(Name = "id")] int id)
        //{
        //    _manager.BookService.DeleteOneBook(id);
        //    return RedirectToAction("Index");
        //}
    }
}
