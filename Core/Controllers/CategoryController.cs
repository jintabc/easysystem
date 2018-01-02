using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using EasySystem.Core.Entity;
using System.Data;

namespace EasySystem.Core.Controller
{
    public class CategoryController
    {
        /// <summary>
        /// 新增货品类别
        /// </summary>
        /// <param name="Category">待新增货品类别</param>
        public int AddCategory(Warehouse_Category Category)
        {
            int result = 0;
            string cmdText = @"PROC_AddCategory";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CategoryName",Category.CategoryName),
                new SqlParameter("@ParentID",Category.ParentID),
                new SqlParameter("@Result",DbType.Int32)
            };
            parameters[2].Direction = ParameterDirection.Output;
            DBHelper.ExecuteNonQuery(cmdText, parameters, CommandType.StoredProcedure);
            if (parameters[2].Value != null)
            {
                Category.CategoryID = Convert.ToInt32(parameters[2].Value);
                return 1;
            }
            return -1;
        }

        /// <summary>
        /// 修改货品类别
        /// </summary>
        /// <param name="Category">需修改货品类别</param>
        public int UpdateCategory(Warehouse_Category Category)
        {
            string cmdText = @"UPDATE [EasySystem].[dbo].[Warehosue_Categories]
   SET [CategoryName] = @CategoryName
      ,[ParentID] = @ParentID
 WHERE [CategoryID] = @CategoryID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CategoryName",Category.CategoryName),
                new SqlParameter("@ParentID",Category.ParentID),
                new SqlParameter("@CategoryID",Category.CategoryID)
            };
            return DBHelper.ExecuteNonQuery(cmdText, parameters, CommandType.Text);
        }

        /// <summary>
        /// 获取货品类别列表
        /// </summary>
        public List<Warehouse_Category> GetCategories()
        {
            List<Warehouse_Category> Categories = null;
            string cmdText = "SELECT * FROM View_Warehouse_Categories";
            using (SqlDataReader reader = DBHelper.ExecuteReader(cmdText, CommandType.Text))
            {
                if (reader.HasRows)
                {
                    Categories = new List<Warehouse_Category>();
                    while (reader.Read())
                    {
                        Warehouse_Category Category = new Warehouse_Category()
                        {
                            CategoryID = Convert.ToInt32(reader["CategoryID"]),
                            CategoryName = reader["CategoryName"] as string,
                            ParentID = reader["ParentID"] is DBNull ? -1 : Convert.ToInt32(reader["ParentID"])
                        };
                        Categories.Add(Category);
                    }
                }
            }
            return Categories;
        }
        /// <summary>
        /// 获取货品类别列表
        /// </summary>
        /// <param name="CategoryName">货品类别名称</param>
        public void GetCategories(string CategoryName)
        {

        }

    }
}
