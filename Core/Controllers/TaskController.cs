using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using EasySystem.Core.Entity;
using System.Data;
using System.Collections.ObjectModel;

namespace EasySystem.Core.Controller
{
    public class TaskController
    {
        /// <summary>
        /// 新增任务
        /// </summary>
        /// <param name="task">待新增任务</param>
        public int AddTask(Business_Task task)
        {
            int result = 0;
            string cmdText = @"PROC_AddTask";
            SqlParameter[] parameters = new SqlParameter[5]
            {
                new SqlParameter("@ProjectID",task.Project.ProjectID),
                new SqlParameter("@DepartmentID",task.Department.DepartmentID),
                new SqlParameter("@Contact",task.Contact),
                new SqlParameter("@BusinessType",task.BusinessType),
                new SqlParameter("@ID",DbType.Int32)
            };
            parameters[4].Direction = ParameterDirection.Output;
            DBHelper.ExecuteNonQuery(cmdText, parameters, CommandType.StoredProcedure);
            if (parameters[4].Value != null)
            {
                task.TaskID = Convert.ToInt32(parameters[4].Value);
                return 1;
            }
            return -1;
        }

        /// <summary>
        /// 修改任务
        /// </summary>
        /// <param name="task">需修改任务</param>
        public int UpdateTask(Business_Task task)
        {
            string cmdText = @"UPDATE [EasySystem].[dbo].[Business_Projects]
   SET [ProjectID] = @ProjectID
      ,[DepartmentID] = @DepartmentID
      ,[Contact] = @Contact
      ,[BusinessType] = @BusinessType
 WHERE [TaskID] = @TaskID";

            SqlParameter[] parameters = new SqlParameter[5]
            {
                new SqlParameter("@ProjectID",task.Project.ProjectID),
                new SqlParameter("@DepartmentID",task.Department.DepartmentID),
                new SqlParameter("@Contact",task.Contact),
                new SqlParameter("@BusinessType",task.BusinessType),
                new SqlParameter("@TaskID",task.TaskID)
            };
            return DBHelper.ExecuteNonQuery(cmdText, parameters, CommandType.Text);
        }

        /// <summary>
        /// 获取任务列表
        /// </summary>
        public List<Business_Task> GetTasks()
        {
            List<Business_Task> tasks = null;
            string cmdText = "SELECT * FROM View_TaskListModel";
            using (SqlDataReader reader = DBHelper.ExecuteReader(cmdText, CommandType.Text))
            {
                if (reader.HasRows)
                {
                    tasks = new List<Business_Task>();
                    while (reader.Read())
                    {
                        Business_Task task = new Business_Task()
                        {
                            TaskID = Convert.ToInt32(reader["TaskID"]),
                            Project = new Business_Project()
                            {
                                ProjectID = Convert.ToInt32(reader["ProjectID"]),
                                DesignNo = (reader["DesignNo"] as string).TrimEnd(' '),
                                ProjectName = reader["ProjectName"] as string,
                                Company = reader["Company"] as string,
                                ProjectLeader = reader["ProjectLeader"] as string
                            },
                            Department = new Common_Department()
                            {
                                DepartmentID = Convert.ToInt32(reader["DepartmentID"]),
                                DepartmentName = reader["DepartmentName"] as string
                            },
                            Contact = reader["Contact"] as string,
                            CostSheetNo = reader["CostSheetNo"] as string,
                            StampSheetNo = reader["StampSheetNo"] as string,
                            HandoverSheetNo = reader["HandoverSheetNo"] as string,
                            BusinessType = (Common_BusinessType)Convert.ToInt32(reader["BusinessType"])
                        };
                        if (reader["FinishDate"] is DBNull)
                        {
                            task.FinishDate = null;
                        }
                        else
                        {
                            task.FinishDate = Convert.ToDateTime(reader["FinishDate"]);
                        }
                        if (reader["TotalPrice"] is DBNull)
                        {
                            task.TotalPrice = null;
                        }
                        else
                        {
                            task.TotalPrice = Convert.ToDecimal(reader["TotalPrice"]);
                        }
                        tasks.Add(task);
                    }


                }
            }
            return tasks;
        }

        /// <summary>
        /// 获取任务列表
        /// </summary>
        public Business_Task GetTask(int taskID)
        {
            Business_Task task = null;
            string cmdText = "SELECT * FROM View_FullTask WHERE TaskID="+taskID;
            using (SqlDataReader reader = DBHelper.ExecuteReader(cmdText, CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        task = new Business_Task()
                        {
                            TaskID = Convert.ToInt32(reader["TaskID"]),
                            Project = new Business_Project()
                            {
                                ProjectID = Convert.ToInt32(reader["ProjectID"]),
                                DesignNo = (reader["DesignNo"] as string).TrimEnd(' '),
                                ProjectName = reader["ProjectName"] as string,
                                Company = reader["Company"] as string,
                                ProjectLeader = reader["ProjectLeader"] as string
                            },
                            Department = new Common_Department()
                            {
                                DepartmentID = Convert.ToInt32(reader["DepartmentID"]),
                                DepartmentName = reader["DepartmentName"] as string
                            },
                            Contact = reader["Contact"] as string,
                            CostSheetNo = reader["CostSheetNo"] as string,
                            StampSheetNo = reader["StampSheetNo"] as string,
                            HandoverSheetNo = reader["HandoverSheetNo"] as string,
                            BusinessType = (Common_BusinessType)Convert.ToInt32(reader["BusinessType"])
                        };
                        if (reader["FinishDate"] is DBNull)
                        {
                            task.FinishDate = null;
                        }
                        else
                        {
                            task.FinishDate = Convert.ToDateTime(reader["FinishDate"]);
                        }
                        if (reader["TotalPrice"] is DBNull)
                        {
                            task.TotalPrice = null;
                        }
                        else
                        {
                            task.TotalPrice = Convert.ToDecimal(reader["TotalPrice"]);
                        }
                    }
                }
            }
            task.Items = GetTaskDetails(taskID);
            return task;
        }

        /// <summary>
        /// 获取任务列表
        /// </summary>
        public List<Business_TaskListModel> GetTaskListModel()
        {
            List<Business_TaskListModel> tasks = null;
            string cmdText = "SELECT * FROM View_TaskListModel ORDER BY TaskID";
            using (SqlDataReader reader = DBHelper.ExecuteReader(cmdText, CommandType.Text))
            {
                if (reader.HasRows)
                {
                    tasks = new List<Business_TaskListModel>();
                    while (reader.Read())
                    {
                        DateTime? finishDate = null;
                        if (reader["FinishDate"] is DBNull)
                        {
                            finishDate = null;
                        }
                        else
                        {
                            finishDate = Convert.ToDateTime(reader["FinishDate"]);
                        }
                        Business_TaskListModel task = new Business_TaskListModel
                        (
                            Convert.ToInt32(reader["TaskID"]),
                            finishDate,
                            reader["ProjectName"] as string,
                            reader["DepartmentName"] as string,
                            reader["A0"] is DBNull ? 0 : Convert.ToInt32(reader["A0"]),
                            reader["A1"] is DBNull ? 0 : Convert.ToInt32(reader["A1"]),
                            reader["A2"] is DBNull ? 0 : Convert.ToInt32(reader["A2"]),
                            reader["A3"] is DBNull ? 0 : Convert.ToInt32(reader["A3"]),
                            reader["CostSheetNo"] as string,
                            reader["StampSheetNo"] as string,
                            reader["HandoverSheetNo"] as string,
                            Convert.ToInt32(reader["BusinessType"])
                        );
                        tasks.Add(task);
                    }
                }
            }
            return tasks;
        }

        /// <summary>
        /// 获取任务明细
        /// </summary>
        /// <param name="task">任务名称</param>
        public ObservableCollection<Business_TaskItem> GetTaskDetails(int taskID)
        {
            ObservableCollection<Business_TaskItem> taskItems = null;
            string cmdText = "SELECT * FROM Business_TaskItems WHERE TaskID="+taskID;
            using (SqlDataReader reader = DBHelper.ExecuteReader(cmdText, CommandType.Text))
            {
                if (reader.HasRows)
                {
                    taskItems = new ObservableCollection<Business_TaskItem>();
                    while (reader.Read())
                    {
                        Business_TaskItem item = new Business_TaskItem()
                        {
                            TaskItemID = Convert.ToInt64(reader["TaskItemID"]),
                            ItemName = reader["ItemName"] as string,
                            Subject = reader["Subject"] as string,
                            Copies = Convert.ToInt32(reader["Copies"]),
                            Description = reader["Description"] as string
                        };
                        if (reader["A0"] is DBNull)
                        {
                            item.A0 = null;
                        }
                        else
                        {
                            item.A0 = Convert.ToInt32(reader["A0"]);
                        }
                        if (reader["A1"] is DBNull)
                        {
                            item.A1 = null;
                        }
                        else
                        {
                            item.A1 = Convert.ToInt32(reader["A1"]);
                        }
                        if (reader["A2"] is DBNull)
                        {
                            item.A2 = null;
                        }
                        else
                        {
                            item.A2 = Convert.ToInt32(reader["A2"]);
                        }
                        if (reader["A3"] is DBNull)
                        {
                            item.A3 = null;
                        }
                        else
                        {
                            item.A3 = Convert.ToInt32(reader["A3"]);
                        }
                        taskItems.Add(item);
                    }
                }
            }
            return taskItems;
        }

        public int InsertItem(Business_TaskItem item)
        {
            //string cmdText = @"Proc_InsertTaskItem";
            //SqlParameter[] parameters = new SqlParameter[]
            //{
            //    new SqlParameter("@TaskID",item.Task.TaskID),
            //    new SqlParameter("@ItemName",item.ItemName),
            //    new SqlParameter("@Subject",item.Subject),
            //    new SqlParameter("@A0",item.A0),
            //    new SqlParameter("@A1",item.A0),
            //    new SqlParameter("@A2",item.A0),
            //    new SqlParameter("@A3",item.A0),
            //    new SqlParameter("@Copies",item.Copies),
            //    new SqlParameter("@Description",item.Description),
            //    new SqlParameter("@ID",DbType.Int32)
            //};
            return 0;
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