using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Common_Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int? ParentDepartmentID { get; set; }
        public Common_Department ParentDepartment { get; set; }
    }
}
