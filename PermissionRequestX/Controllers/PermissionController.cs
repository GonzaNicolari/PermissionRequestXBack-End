using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PermissionRequestX.Core.Repositories.Interfaces;
using PermissionRequestX.Core.Models;
using RequestPermission.Core.Models;

namespace PermissionRequestX.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PermissionController : ControllerBase
    {
        private readonly ILogger<PermissionController> _logger;
        private readonly IPermissionRepository _permissionRepository;

        public PermissionController(ILogger<PermissionController> logger, IPermissionRepository permissionRepository)
        {
            _logger = logger;
            _permissionRepository = permissionRepository;
        }

        [HttpPost]
        [Route("Permissions")]
        public async Task<PermissionResult> AddPermissionAsync(Permission input)
        {
            if (input != null)
            {
                return await _permissionRepository.AddPermissionOrUpdateAsync(input);

            }
            else 
            {
                return await Task.FromResult<PermissionResult>(null);
            }
        }
        [HttpGet]
        [Route("Permissions")]
        public async Task<IList<Permission>> GetPermissionsAsync()
        {
            return await _permissionRepository.GetPermissionsAsync();
        }
        [HttpGet]
        [Route("Permissions")]
        public async Task<Permission> GetPermissionsAsync(int permissionId)
        {
            return await _permissionRepository.GetPermissionAsync(permissionId);
        }
        [HttpDelete]
        [Route("Permissions")]
        public async Task<bool> DeletePermissionsAsync(Permission permission)
        {
            return await _permissionRepository.DeletePermissionAsync(permission);
        }
    }
}
