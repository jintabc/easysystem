using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class EasySystemDBContext : DbContext
    {
        public DbSet<Business_Task> Business_Tasks { get; set; }
        public DbSet<Business_TaskItem> Business_TaskItems { get; set; }
        public DbSet<Business_Project> Business_Projects { get; set; }
        public DbSet<Common_Department> Common_Departments { get; set; }

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
                    ProjectName = "项目" + i + 30,
                    ProjectLeader = "某某某",
                    Company = "建设单位" + i + 30,
                    DesignNo = "2017J0" + i.ToString().PadLeft(2, '0')
                };
                context.Business_Projects.Add(project);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
