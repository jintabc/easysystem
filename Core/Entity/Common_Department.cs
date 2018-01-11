using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Common_Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [StringLength(30)]
        public string DepartmentName { get; set; }
        
        public int? ParentDepartmentID { get; set; }

        [ForeignKey("ParentDepartmentID")]
        public Common_Department ParentDepartment { get; set; }
        
        public List<Common_Department> SubDepartments { get; set; }
    }
}
