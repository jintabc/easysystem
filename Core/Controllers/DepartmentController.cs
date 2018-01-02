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
        public List<Common_Department> GetDepartments()
        {
            List<Common_Department> departments = null;
            string cmdText = "SELECT * FROM Common_Departments";
            using (SqlDataReader reader = DBHelper.ExecuteReader(cmdText,CommandType.Text))
            {
                if (reader.HasRows)
                {
                    departments = new List<Common_Department>();
                    Common_Department department;
                    while (reader.Read())
                    {
                        department = new Common_Department()
                        {
                            DepartmentID = Convert.ToInt32(reader["DepartmentID"]),
                            DepartmentName = reader["DepartmentName"].ToString()
                        };
                        //读取上级部门
                        //if(!reader["ParentDepartmentID"] is DBNull)
                        //{
                        //    department.ParentDepartment = new Common_Department();
                        //    depar
                        //}
                        departments.Add(department);
                    }
                }
            }


            return departments;
        }
    }
}
