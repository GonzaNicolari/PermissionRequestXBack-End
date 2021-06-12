using PermissionRequestX.Core.Models;
using RequestPermission.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermissionRequestX.Core.Repositories.Interfaces
{
    public interface IPermissionRepository
    {
        Task<PermissionResult> AddPermissionOrUpdateAsync(Permission permission);
        Task<IList<Permission>> GetPermissionsAsync();
        Task<bool> DeletePermissionAsync(Permission permission);
        Task<Permission> GetPermissionAsync(int permissionId);
    }
}
