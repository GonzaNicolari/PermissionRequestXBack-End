using PermissionRequestX.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RequestPermission.Core.Models
{
    public class PermissionResult : Permission
    {
        public bool isAdded { get; set; }
    }
}
