using Microsoft.EntityFrameworkCore;
using PermissionRequestX.Core.Models;
using PermissionRequestX.Core.Repositories.Interfaces;
using RequestPermission.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PermissionRequestX.Core.Repositories
{
    /// <summary>
    /// Class in charge of interacting with the DbContext.
    /// </summary>
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IPermissionDBContext _DbContext;
        public PermissionRepository(IPermissionDBContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task<PermissionResult> AddPermissionOrUpdateAsync(Permission permission)  
        {
            var ExistingPermission = await _DbContext.Permission.Where(per => per.EmployeeName == permission.EmployeeName
                                      && per.EmployeeLastName == permission.EmployeeLastName
                                      && per.PermissionDate == permission.PermissionDate
                                      && per.PermissionType == permission.PermissionType)
                                      .FirstAsync();
            if (ExistingPermission != null)
            {
                ExistingPermission.EmployeeName = permission.EmployeeName;
                ExistingPermission.EmployeeLastName = permission.EmployeeLastName;
                ExistingPermission.PermissionDate = permission.PermissionDate;
                ExistingPermission.PermissionType = permission.PermissionType;
                var result = _DbContext.Permission.Update(ExistingPermission);
                await _DbContext.SaveChangesAsync(CancellationToken.None);
                return new PermissionResult
                {
                    EmployeeLastName = ExistingPermission.EmployeeLastName,
                    EmployeeName = ExistingPermission.EmployeeName,
                    Id = ExistingPermission.Id,
                    PermissionDate = ExistingPermission.PermissionDate,
                    PermissionType = ExistingPermission.PermissionType,
                    isAdded = false
                };
                
            }
            else 
            {
                var result = _DbContext.Permission.Add(permission);
                await _DbContext.SaveChangesAsync(CancellationToken.None);
                return new PermissionResult
                {
                    EmployeeLastName = ExistingPermission.EmployeeLastName,
                    EmployeeName = ExistingPermission.EmployeeName,
                    Id = ExistingPermission.Id,
                    PermissionDate = ExistingPermission.PermissionDate,
                    PermissionType = ExistingPermission.PermissionType,
                    isAdded = true
                };
            }

        }
        public async Task<IList<Permission>> GetPermissionsAsync() 
        { 
            return await (from per in _DbContext.Permission
                           select new Permission
                           {
                               EmployeeName= per.EmployeeName,
                               EmployeeLastName= per.EmployeeLastName,
                               Id= per.Id,
                               PermissionDate= per.PermissionDate,
                               PermissionType= per.PermissionType
                           }).ToListAsync();
        }
        public async Task<Permission> GetPermissionAsync(int permissionId) 
        { 
            return await (from per in _DbContext.Permission
                          where per.Id == permissionId
                          select new Permission
                           {
                               EmployeeName= per.EmployeeName,
                               EmployeeLastName= per.EmployeeLastName,
                               Id= per.Id,
                               PermissionDate= per.PermissionDate,
                               PermissionType= per.PermissionType
                           }).FirstAsync();
        }
        /// <summary>
        /// Deletes a permission.
        /// </summary>
        /// <param name="permission"></param>
        /// <returns>a boolean indicating success.</returns>
        public async Task<bool> DeletePermissionAsync(Permission permission) 
        {
            var permissionToDelete = _DbContext.Permission.Remove(permission);
            await _DbContext.SaveChangesAsync(CancellationToken.None);
            return permissionToDelete.State == EntityState.Deleted;
        }
    }
}
