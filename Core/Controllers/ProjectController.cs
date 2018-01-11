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
        EasySystemDBContext context = new EasySystemDBContext();
        /// <summary>
        /// 新增项目
        /// </summary>
        /// <param name="project">待新增项目</param>
        public int AddProject(Business_Project project)
        {
            context.Business_Projects.Add(project);
            return context.SaveChanges();
        }

        /// <summary>
        /// 修改项目
        /// </summary>
        /// <param name="project">需修改项目</param>
        public int UpdateProject(Business_Project project)
        {
            Business_Project old = context.Business_Projects.Find(project.ProjectID);
            context.Entry<Business_Project>(old).CurrentValues.SetValues(project);            
            return context.SaveChanges();
        }

        /// <summary>
        /// 获取项目列表
        /// </summary>
        public List<Business_Project> GetProjects()
        {
            return context.Business_Projects.ToList();
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
