using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace LibraryManagementApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly IServiceManager _manager;

        public RoleController(IServiceManager manager)
        {
            _manager = manager;
        }

        // Gösterim için tüm rolleri alır
        public async Task<IActionResult> Index()
        {
            var roles = await _manager.RoleService.GetAllRolesAsync();
            return View(roles);
        }

        // Yeni rol oluşturma sayfasını gösterir
        public IActionResult Create()
        {
            return View();
        }

        // Yeni rol oluşturur
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleDto roleDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _manager.RoleService.CreateRoleAsync(roleDto);
                if (result.Succeeded)
                {
                    TempData["SuccessMessage"] = "Role created successfully!";
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(roleDto);
        }

        // Rol güncelleme sayfasını gösterir
        public async Task<IActionResult> Update(string roleId)
        {
            var role = await _manager.RoleService.GetAllRolesAsync();
            var existingRole = role.FirstOrDefault(r => r.Id == roleId);

            if (existingRole == null)
            {
                TempData["ErrorMessage"] = "Role not found!";
                return RedirectToAction("Index");
            }

            var roleDto = new RoleDto { Name = existingRole.Name };
            return View(roleDto);
        }

        // Rol günceller
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string roleId, RoleDto roleDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _manager.RoleService.UpdateRoleAsync(roleId, roleDto);
                if (result.Succeeded)
                {
                    TempData["SuccessMessage"] = "Role updated successfully!";
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(roleDto);
        }

        public async Task<IActionResult> Delete(string roleId)
        {
            var result = await _manager.RoleService.DeleteRoleAsync(roleId);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Role deleted successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete the role!";
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AssignRoleToUser()
        {
            var users =  _manager.AuthService.GetAllUsers();
            var roles = await _manager.RoleService.GetAllRolesAsync();
            ViewBag.Users = users;
            ViewBag.Roles = roles;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignRoleToUser(string userId, string roleName)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(roleName))
            {
                TempData["ErrorMessage"] = "User or Role cannot be empty!";
                return RedirectToAction("AssignRoleToUser");
            }

            var result = await _manager.RoleService.AssignRoleToUserAsync(userId, roleName);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Role assigned to user successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to assign role to user!";
            }

            return RedirectToAction("AssignRoleToUser");
        }

        // Kullanıcıdan rol kaldırma işlemi
        public async Task<IActionResult> RemoveRoleFromUser(string userId, string roleName)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(roleName))
            {
                TempData["ErrorMessage"] = "User or Role cannot be empty!";
                return RedirectToAction("AssignRoleToUser");
            }

            var result = await _manager.RoleService.RemoveRoleFromUserAsync(userId, roleName);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Role removed from user successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to remove role from user!";
            }

            return RedirectToAction("AssignRoleToUser");
        }
    }
}
