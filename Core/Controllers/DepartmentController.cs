using EasySystem.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Controller
{
    public class DepartmentController
    {
        EasySystemDBContext context = new EasySystemDBContext();

        public List<Common_Department> GetDepartments()
        {
            return context.Common_Departments.ToList();
        }
    }
}
