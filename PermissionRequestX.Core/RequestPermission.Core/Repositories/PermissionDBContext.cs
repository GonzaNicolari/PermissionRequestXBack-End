using Microsoft.EntityFrameworkCore;
using PermissionRequestX.Core.Models;
using PermissionRequestX.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PermissionRequestX.Core.Repositories
{
    public class PermissionDBContext : DbContext, IPermissionDBContext
    {
        public DbSet<Permission> Permission { get; set; }
        public DbSet<PermissionType> PermissionType { get; set; }
        public PermissionDBContext(DbContextOptions<PermissionDBContext> options) : base(options)
        {

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>().ToTable("Permission");
            modelBuilder.Entity<PermissionType>().ToTable("PermissionType");
        }
    }
}
