using Microsoft.AspNetCore.Identity;
using Services.Contracts;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class RoleManager : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        public RoleManager(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IEnumerable<IdentityRole>> GetAllRolesAsync()
        {
            return _roleManager.Roles.ToList();
        }

        public async Task<IdentityResult> CreateRoleAsync(RoleDto roleDto)
        {
            var role = new IdentityRole
            {
                Name = roleDto.Name
            };

            var result = await _roleManager.CreateAsync(role);
            return result;
        }

        public async Task<IdentityResult> UpdateRoleAsync(string roleId, RoleDto roleDto)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role != null)
            {
                role.Name = roleDto.Name;
                var result = await _roleManager.UpdateAsync(role);
                return result;
            }

            return IdentityResult.Failed(new IdentityError { Description = "Role not found" });
        }

        public async Task<IdentityResult> DeleteRoleAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
                return result;
            }

            return IdentityResult.Failed(new IdentityError { Description = "Role not found" });
        }

        public async Task<IdentityResult> AssignRoleToUserAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            }

            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result;
        }

        public async Task<IdentityResult> RemoveRoleFromUserAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            }

            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            return result;
        }
    }
}
