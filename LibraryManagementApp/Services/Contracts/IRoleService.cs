using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Services.Contracts
    {
        public interface IRoleService
        {
            Task<IEnumerable<IdentityRole>> GetAllRolesAsync();

            Task<IdentityResult> CreateRoleAsync(RoleDto roleDto);

            Task<IdentityResult> UpdateRoleAsync(string roleId, RoleDto roleDto);

            Task<IdentityResult> DeleteRoleAsync(string roleId);

            Task<IdentityResult> AssignRoleToUserAsync(string userId, string roleName);

            Task<IdentityResult> RemoveRoleFromUserAsync(string userId, string roleName);
        }
    }



