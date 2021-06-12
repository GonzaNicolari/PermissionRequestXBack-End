using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionRequestX.Core.Models
{
    [Table("Permission")]
    public class Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string EmployeeName { get; set; }
        [MaxLength(150)]
        public string EmployeeLastName { get; set; }
        public int PermissionType { get; set; }
        public DateTime PermissionDate { get; set; }

    }
}
