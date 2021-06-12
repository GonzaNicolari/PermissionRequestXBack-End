using PermissionRequestX.Core.Models;
using PermissionRequestX.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestPermission.Core
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(IPermissionDBContext context)
        {

            // Look for any students.
            if (context.Permission.Any())
            {
                return;   // DB has been seeded
            }

            var permissions = new Permission[]
            {
            new Permission{EmployeeName="Carson",EmployeeLastName="Alexander",PermissionDate=DateTime.Parse("2005-09-01"),PermissionType = 1},
            new Permission{EmployeeName="Meredith",EmployeeLastName="Alonso",PermissionDate=DateTime.Parse("2002-09-01"),PermissionType = 1},
            new Permission{EmployeeName="Arturo",EmployeeLastName="Anand",PermissionDate=DateTime.Parse("2003-09-01"),PermissionType = 1},
            new Permission{EmployeeName="Gytis",EmployeeLastName="Barzdukas",PermissionDate=DateTime.Parse("2002-09-01"),PermissionType = 1},
            new Permission{EmployeeName="Yan",EmployeeLastName="Li",PermissionDate=DateTime.Parse("2002-09-01"),PermissionType = 1},
            new Permission{EmployeeName="Peggy",EmployeeLastName="Justice",PermissionDate=DateTime.Parse("2001-09-01"),PermissionType = 1},
            new Permission{EmployeeName="Laura",EmployeeLastName="Norman",PermissionDate=DateTime.Parse("2003-09-01"),PermissionType = 1},
            new Permission{EmployeeName="Nino",EmployeeLastName="Olivetto",PermissionDate=DateTime.Parse("2005-09-01"),PermissionType = 1}
            };
            foreach (Permission s in permissions)
            {
                context.Permission.Add(s);
            }
            await context.SaveChangesAsync();


        }
    }
}
