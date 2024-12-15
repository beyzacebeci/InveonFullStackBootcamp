using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;

namespace LibraryManagementApp.Components
{
    public class BookSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public BookSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager.BookService.GetAllBooks(false).Count().ToString();
        }
    }
}
