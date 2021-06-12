using Microsoft.EntityFrameworkCore;
using PermissionRequestX.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PermissionRequestX.Core.Repositories.Interfaces
{
    public interface IPermissionDBContext
    {
        DbSet<Permission> Permission { get; set; }
        DbSet<PermissionType> PermissionType { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
