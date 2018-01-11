using EasySystem.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Controller
{
    public class EasySystemDBContext : DbContext
    {
        public DbSet<Common_Department> Common_Departments { get; set; }
        public DbSet<Business_Project> Business_Projects { get; set; }
        public DbSet<Business_Task> Business_Tasks { get; set; }
        public DbSet<Business_TaskItem> Business_TaskItems { get; set; }
        public DbSet<Business_StampSheet> Business_StampSheets { get; set; }
        public DbSet<Business_StampSheetItem> Business_StampSheetItems { get; set; }
        public DbSet<Business_HandoverSheet> Business_HandoverSheets { get; set; }
        public DbSet<Business_HandoverSheetItem> Business_HandoverSheetItems { get; set; }
        public DbSet<Business_CostSheet> Business_CostSheets { get; set; }
        public DbSet<Business_CostSheetItem> Business_CostSheetItems { get; set; }

        public EasySystemDBContext() : base("name=connectionString") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class EasySystemInitializer : DropCreateDatabaseIfModelChanges<EasySystemDBContext>
    {
        protected override void Seed(EasySystemDBContext context)
        {
            Random r = new Random();
            #region 部门数据
            Common_Department[] departments = new Common_Department[]
            {
                new Common_Department(){DepartmentName="市政分院"},
                new Common_Department(){DepartmentName="建筑分院"},
                new Common_Department(){DepartmentName="景观分院"}
            };
            context.Common_Departments.AddRange(departments);
            context.SaveChanges();
            #endregion
            #region 项目数据
            for (int i = 1; i < 31; i++)
            {
                Business_Project project = new Business_Project()
                {
                    ProjectName = "项目" + i,
                    ProjectLeader = "某某某",
                    Company = "建设单位" + i,
                    DesignNo = "2017S0" + i.ToString().PadLeft(2, '0')
                };
                context.Business_Projects.Add(project);
            }
            for (int i = 1; i < 31; i++)
            {
                Business_Project project = new Business_Project()
                {
                    ProjectName = "项目" + (i + 30),
                    ProjectLeader = "某某某",
                    Company = "建设单位" + (i + 30),
                    DesignNo = "2017J0" + i.ToString().PadLeft(2, '0')
                };
                context.Business_Projects.Add(project);
            }
            context.SaveChanges();
            #endregion
            #region 业务类型
            List<Business_ServiceType> serviceTypes = new List<Business_ServiceType>();

            #endregion
            #region 任务数据
            List<Business_Task> tasks = new List<Business_Task>();
            for (int i = 1; i < 31; i++)
            {
                tasks.Add(new Business_Task()
                {
                    ProjectID = i,
                    DepartmentID = 1,
                    BusinessType = Common_BusinessType.Inside,
                    Contact = "某某某"
                });
            }
            for (int i = 31; i < 61; i++)
            {
                tasks.Add(new Business_Task()
                {
                    ProjectID = i,
                    DepartmentID = 2,
                    BusinessType = Common_BusinessType.Inside,
                    Contact = "某某某"
                });
            }
            context.Business_Tasks.AddRange(tasks);
            context.SaveChanges();

            List<Business_TaskItem> taskItems = new List<Business_TaskItem>();
            for (int i = 1; i < 31; i++)
            {
                taskItems.Add(new Business_TaskItem()
                {
                    TaskID = i,
                    ItemName = "第一册",
                    Subject = "道路、景观、照明",
                    A1 = r.Next(1, 6),
                    A2 = r.Next(1, 21),
                    A3 = r.Next(80, 200),
                    Copies = 9
                });
                taskItems.Add(new Business_TaskItem()
                {
                    TaskID = i,
                    ItemName = "第二册",
                    Subject = "排水",
                    A1 = r.Next(1, 6),
                    A2 = r.Next(1, 11),
                    A3 = r.Next(50, 100),
                    Copies = 9
                });
                taskItems.Add(new Business_TaskItem()
                {
                    TaskID = i,
                    ItemName = "第三册",
                    Subject = "桥梁",
                    A2 = r.Next(1, 6),
                    A3 = r.Next(30, 70),
                    Copies = 9
                });
            }
            for (int i = 31; i < 61; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    taskItems.Add(new Business_TaskItem()
                    {
                        TaskID = i,
                        ItemName = j + "#栋",
                        Subject = "建筑",
                        A0 = r.Next(1, 6),
                        A1 = r.Next(10, 20),
                        Copies=8
                    });
                    taskItems.Add(new Business_TaskItem()
                    {
                        TaskID = i,
                        ItemName = j + "#栋",
                        Subject = "结构",
                        A0 = r.Next(1, 6),
                        A1 = r.Next(10, 20),
                        Copies = 8
                    });
                    taskItems.Add(new Business_TaskItem()
                    {
                        TaskID = i,
                        ItemName = j + "#栋",
                        Subject = "给排水",
                        A0 = r.Next(1, 6),
                        A1 = r.Next(10, 20),
                        Copies = 8
                    });
                    taskItems.Add(new Business_TaskItem()
                    {
                        TaskID = i,
                        ItemName = j + "#栋",
                        Subject = "电气",
                        A0 = r.Next(1, 6),
                        A1 = r.Next(10, 20),
                        Copies = 8
                    });
                    taskItems.Add(new Business_TaskItem()
                    {
                        TaskID = i,
                        ItemName = j + "#栋",
                        Subject = "暖通",
                        A0 = r.Next(1, 6),
                        A1 = r.Next(10, 20),
                        Copies = 8
                    });
                }
            }
            context.Business_TaskItems.AddRange(taskItems);
            context.SaveChanges();
            #endregion

            base.Seed(context);
        }
    }
}
