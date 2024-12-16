using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IBookService _bookService;
        private readonly IAuthService _authService;
        private readonly IRoleService _roleService;


        public ServiceManager(IBookService bookService, IAuthService authService, IRoleService roleService)
        {
            _bookService = bookService;
            _authService = authService;
            _roleService = roleService;
        }

        public IBookService BookService => _bookService;
        public IAuthService AuthService => _authService;
        public IRoleService RoleService => _roleService;


    }
}
