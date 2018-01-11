using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using EasySystem.Core.Entity;
using System.Data;
using System.Collections.ObjectModel;
using System.Data.Linq;

namespace EasySystem.Core.Controller
{
    public class TaskController
    {
        EasySystemDBContext context = new EasySystemDBContext();
        /// <summary>
        /// 新增任务
        /// </summary>
        /// <param name="task">待新增任务</param>
        public int AddTask(Business_Task task)
        {
            context.Business_Tasks.Add(task);
            return context.SaveChanges();
        }

        /// <summary>
        /// 修改任务
        /// </summary>
        /// <param name="task">需修改任务</param>
        public int UpdateTask(Business_Task task)
        {
            Business_Task old = context.Business_Tasks.Find(task.TaskID);
            context.Entry(old).CurrentValues.SetValues(task);
            return context.SaveChanges();
        }

        /// <summary>
        /// 获取任务列表
        /// </summary>
        public List<Business_Task> GetTasks()
        {
            return context.Business_Tasks.ToList();
        }

        /// <summary>
        /// 获取任务列表
        /// </summary>
        public Business_Task GetTask(long taskID)
        {
            return context.Business_Tasks.Include("Project").Include("Department").Include("Items").First(t=>t.TaskID==taskID);
        }

        /// <summary>
        /// 获取任务列表
        /// </summary>
        public List<Business_TaskListModel> GetTaskListModel()
        {
            var query = from t in context.Business_Tasks
                        join i in context.Business_TaskItems
                        on t equals i.Task into b
                        select new Business_TaskListModel(){
                            TaskID=t.TaskID,
                        FinishDate=t.FinishDate,
                        ProjectName=t.Project.ProjectName,
                        DepartmentName=t.Department.DepartmentName,
                        A0=b.Sum(a => a.A0),
                        A1=b.Sum(a => a.A1),
                        A2=b.Sum(a => a.A2),
                        A3=b.Sum(a => a.A3),
                        CostSheetNo=t.CostSheetNo,
                        StampSheetNo=t.StampSheetNo,
                        HandoverSheetNo=t.HandoverSheetNo,
                        BusinessType=(Common_BusinessType)t.BusinessType };
            return query.ToList();
        }

        public int SaveItem(Business_TaskItem item)
        {
            if (item.TaskItemID > 0)
            {
                Business_TaskItem old = context.Business_TaskItems.Find(item.TaskItemID);
                context.Entry(old).CurrentValues.SetValues(item);
            }
            else
            {
                context.Business_TaskItems.Add(item);
            }
            return context.SaveChanges();
        }

        public void InsertData()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ProjectID");
            table.Columns.Add("DepartmentID");
            table.Columns.Add("Contact");
            table.Columns.Add("BusinessType");
            for (int i = 1; i <= 60; i++)
            {
                DataRow row = table.NewRow();
                row[0] = i;
                row[1] = 1;
                row[2] = "某某某";
                row[3] = 0;
                table.Rows.Add(row);
            }
            SqlBulkCopy copy = new SqlBulkCopy(DBHelper.connString);
            copy.DestinationTableName = "Business_Tasks";
            copy.BatchSize = 60;
            copy.ColumnMappings.Add("ProjectID", "ProjectID");
            copy.ColumnMappings.Add("DepartmentID", "DepartmentID");
            copy.ColumnMappings.Add("Contact", "Contact");
            copy.ColumnMappings.Add("BusinessType", "BusinessType");
            copy.WriteToServer(table);
            copy.Close();
        }

        public void InsertData2()
        {
            DataTable table = new DataTable();
            table.Columns.Add("TaskID");
            table.Columns.Add("ItemName");
            table.Columns.Add("Subject");
            table.Columns.Add("A0");
            table.Columns.Add("A1");
            table.Columns.Add("A2");
            table.Columns.Add("A3");
            table.Columns.Add("Copies");
            Random r = new Random((int)DateTime.Now.Ticks);
            for (int i = 1; i <= 30; i++)
            {
                DataRow row = table.NewRow();
                row[0] = i;
                row[1] = "第一册";
                row[2] = "道路、景观、照明";
                row[3] = null;
                row[4] = r.Next(0, 5);
                row[5] = r.Next(0, 10);
                row[6] = r.Next(15, 200);
                row[7] = r.Next(1, 10);
                table.Rows.Add(row);
                row = table.NewRow();
                row[0] = i;
                row[1] = "第二册";
                row[2] = "给排水";
                row[3] = null;
                row[4] = r.Next(0, 5);
                row[5] = r.Next(0, 10);
                row[6] = r.Next(15, 200);
                row[7] = r.Next(1, 10);
                table.Rows.Add(row);
                row = table.NewRow();
                row[0] = i;
                row[1] = "第三册";
                row[2] = "地道";
                row[3] = null;
                row[4] = r.Next(0, 5);
                row[5] = r.Next(0, 10);
                row[6] = r.Next(15, 200);
                row[7] = r.Next(1, 10);
                table.Rows.Add(row);
            }
            for (int i = 31; i <= 60; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    DataRow row = table.NewRow();
                    row[0] = i;
                    row[1] = j + "#";
                    row[2] = "建筑";
                    row[3] = r.Next(1, 15);
                    row[4] = r.Next(1, 30);
                    row[5] = r.Next(0, 3);
                    row[6] = null;
                    row[7] = r.Next(1, 10);
                    table.Rows.Add(row);
                    row = table.NewRow();
                    row[0] = i;
                    row[1] = j + "#";
                    row[2] = "结构";
                    row[3] = r.Next(1, 15);
                    row[4] = r.Next(1, 30);
                    row[5] = r.Next(0, 3);
                    row[6] = null;
                    row[7] = r.Next(1, 10);
                    table.Rows.Add(row);
                    row = table.NewRow();
                    row[0] = i;
                    row[1] = j + "#";
                    row[2] = "给排水";
                    row[3] = r.Next(1, 15);
                    row[4] = r.Next(1, 30);
                    row[5] = r.Next(0, 3);
                    row[6] = null;
                    row[7] = r.Next(1, 10);
                    table.Rows.Add(row);
                    row = table.NewRow();
                    row[0] = i;
                    row[1] = j + "#";
                    row[2] = "电气";
                    row[3] = r.Next(1, 15);
                    row[4] = r.Next(1, 30);
                    row[5] = r.Next(0, 3);
                    row[6] = null;
                    row[7] = r.Next(1, 10);
                    table.Rows.Add(row);
                    row = table.NewRow();
                    row[0] = i;
                    row[1] = j + "#";
                    row[2] = "暖通";
                    row[3] = r.Next(1, 15);
                    row[4] = r.Next(1, 30);
                    row[5] = r.Next(0, 3);
                    row[6] = null;
                    row[7] = r.Next(1, 10);
                    table.Rows.Add(row);
                }
            }
            SqlBulkCopy copy = new SqlBulkCopy(DBHelper.connString);
            copy.DestinationTableName = "Business_TaskItems";
            copy.BatchSize = 60;
            copy.ColumnMappings.Add("TaskID", "TaskID");
            copy.ColumnMappings.Add("ItemName", "ItemName");
            copy.ColumnMappings.Add("Subject", "Subject");
            copy.ColumnMappings.Add("A0", "A0");
            copy.ColumnMappings.Add("A1", "A1");
            copy.ColumnMappings.Add("A2", "A2");
            copy.ColumnMappings.Add("A3", "A3");
            copy.ColumnMappings.Add("Copies", "Copies");
            copy.WriteToServer(table);
            copy.Close();
        }
    }
}