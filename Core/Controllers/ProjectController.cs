using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using EasySystem.Core.Entity;
using System.Data;

namespace EasySystem.Core.Controller
{
    public class ProjectController
    {
        /// <summary>
        /// 新增项目
        /// </summary>
        /// <param name="project">待新增项目</param>
        public int AddProject(Business_Project project)
        {
            int result = 0;
            string cmdText = @"PROC_AddProject";
            SqlParameter[] parameters = new SqlParameter[5]
            {
                new SqlParameter("@DesignNo",project.DesignNo),
                new SqlParameter("@ProjectName",project.ProjectName),
                new SqlParameter("@Company",project.Company),
                new SqlParameter("@ProjectLeader",project.ProjectLeader),
                new SqlParameter("@ID",DbType.Int32)
            };
            parameters[4].Direction = ParameterDirection.Output;
            DBHelper.ExecuteNonQuery(cmdText,parameters,CommandType.StoredProcedure);
            if (parameters[4].Value != null)
            {
                project.ProjectID = Convert.ToInt32(parameters[4].Value);
                return 1;
            }
            return -1;
        }

        /// <summary>
        /// 修改项目
        /// </summary>
        /// <param name="project">需修改项目</param>
        public int UpdateProject(Business_Project project)
        {
            string cmdText = @"UPDATE [EasySystem].[dbo].[Business_Projects]
   SET [DesignNo] = @DesignNo
      ,[ProjectName] = @ProjectName
      ,[Company] = @Company
      ,[ProjectLeader] = @ProjectLeader
 WHERE [ProjectID] = @ProjectID";

            SqlParameter[] parameters = new SqlParameter[5]
            {
                new SqlParameter("@DesignNo",project.DesignNo),
                new SqlParameter("@ProjectName",project.ProjectName),
                new SqlParameter("@Company",project.Company),
                new SqlParameter("@ProjectLeader",project.ProjectLeader),
                new SqlParameter("@ProjectID",project.ProjectID)
            };
            return DBHelper.ExecuteNonQuery(cmdText, parameters, CommandType.Text);
        }

        /// <summary>
        /// 获取项目列表
        /// </summary>
        public List<Business_Project> GetProjects()
        {
            List<Business_Project> projects = null;
            string cmdText = "SELECT * FROM Business_Projects";
            using (SqlDataReader reader = DBHelper.ExecuteReader(cmdText,CommandType.Text))
            {
                if (reader.HasRows)
                {
                    projects = new List<Business_Project>();
                    while (reader.Read())
                    {
                        Business_Project project = new Business_Project()
                        {
                            ProjectID = Convert.ToInt32(reader["ProjectID"]),
                            DesignNo = (reader["DesignNo"] as string).TrimEnd(' '),
                            ProjectName = reader["ProjectName"] as string,
                            Company = reader["Company"] as string,
                            ProjectLeader = reader["ProjectLeader"] as string
                        };
                        projects.Add(project);
                    }
                }
            }
            return projects;
        }
        /// <summary>
        /// 获取项目列表
        /// </summary>
        /// <param name="projectName">项目名称</param>
        public void GetProjects(string projectName)
        {

        }

    }
}
