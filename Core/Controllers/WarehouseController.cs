using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using EasySystem.Core.Entity;
using System.Data;

namespace EasySystem.Core.Controller
{
    public class WarehouseController
    {
        /// <summary>
        /// 新增项目
        /// </summary>
        /// <param name="warehouse">待新增项目</param>
        public int AddWarehouse(Warehouse_Warehouse warehouse)
        {
            int result = 0;
            string cmdText = @"PROC_AddWarehouse";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@WarehouseName",warehouse.WarehouseName),
                new SqlParameter("@Result",DbType.Int32)
            };
            parameters[4].Direction = ParameterDirection.Output;
            DBHelper.ExecuteNonQuery(cmdText, parameters, CommandType.StoredProcedure);
            if (parameters[1].Value != null)
            {
                warehouse.WarehouseID = Convert.ToInt32(parameters[1].Value);
                return 1;
            }
            return -1;
        }

        /// <summary>
        /// 修改项目
        /// </summary>
        /// <param name="warehouse">需修改项目</param>
        public int UpdateWarehouse(Warehouse_Warehouse warehouse)
        {
            string cmdText = @"UPDATE [EasySystem].[dbo].[Warehouse_Warehouse]
   SET [WarehouseName] = @WarehouseName
 WHERE [WarehouseID] = @WarehouseID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@WarehouseName",warehouse.WarehouseName),
                new SqlParameter("@WarehouseID",warehouse.WarehouseID)
            };
            return DBHelper.ExecuteNonQuery(cmdText, parameters, CommandType.Text);
        }

        /// <summary>
        /// 获取项目列表
        /// </summary>
        public List<Warehouse_Warehouse> GetWarehouses()
        {
            List<Warehouse_Warehouse> Warehouses = null;
            string cmdText = "SELECT * FROM Warehouse_Warehouse";
            using (SqlDataReader reader = DBHelper.ExecuteReader(cmdText, CommandType.Text))
            {
                if (reader.HasRows)
                {
                    Warehouses = new List<Warehouse_Warehouse>();
                    while (reader.Read())
                    {
                        Warehouse_Warehouse warehouse = new Warehouse_Warehouse()
                        {
                            WarehouseID = Convert.ToInt32(reader["WarehouseID"]),
                            WarehouseName = reader["WarehouseName"] as string
                        };
                        Warehouses.Add(warehouse);
                    }
                }
            }
            return Warehouses;
        }
        /// <summary>
        /// 获取项目列表
        /// </summary>
        /// <param name="WarehouseName">项目名称</param>
        public void GetWarehouses(string WarehouseName)
        {

        }

    }
}
