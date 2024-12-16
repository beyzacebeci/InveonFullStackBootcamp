using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace LibraryManagementApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

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
        public IActionResult Create([FromForm] BookDtoForInsertion productDto)
        {
            if (ModelState.IsValid)
            {
                _manager.BookService.CreateBook(productDto);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm] BookDtoForUpdate book)
        {
            if (ModelState.IsValid)
            {
                _manager.BookService.UpdateOneBook(book);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpDelete]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.BookService.DeleteOneBook(id);
            return RedirectToAction("Index");
        }
    }
}
