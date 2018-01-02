using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using EasySystem.Core.Entity;
using System.Data;

namespace EasySystem.Core.Controller
{
    public class InventoryController
    {
        /// <summary>
        /// 新增项目
        /// </summary>
        /// <param name="inventory">待新增项目</param>
        public int AddInventory(Warehouse_Inventory inventory)
        {
            int result = 0;
            string cmdText = @"Proc_AddInventory";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@WarehouseID",inventory.WarehouseID),
                new SqlParameter("@GoodsID",inventory.GoodsID),
                new SqlParameter("@Quantity",inventory.Quantity),
                new SqlParameter("@MinStorage",inventory.MinStorage),
                new SqlParameter("@Result",DbType.Int32)
            };
            parameters[4].Direction = ParameterDirection.Output;
            DBHelper.ExecuteNonQuery(cmdText, parameters, CommandType.StoredProcedure);
            if (parameters[4].Value != null)
            {
                inventory.InventoryID = Convert.ToInt32(parameters[4].Value);
                return 1;
            }
            return -1;
        }

        public int AddInventoryList(List<Warehouse_Inventory> inventoryList)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("InventoryID", typeof(int));
            dt.Columns.Add("WarehouseID", typeof(int));
            dt.Columns.Add("GoodsID", typeof(int));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("MinStorage", typeof(int));
            DataRow row = null;
            foreach (Warehouse_Inventory i in inventoryList)
            {
                row = dt.NewRow();
                row[1] = i.WarehouseID;
                row[2] = i.Goods.GoodsID;
                row[3] = i.Quantity;
                row[4] = i.MinStorage;
                dt.Rows.Add(row);
            }
            using (SqlConnection conn = new SqlConnection(DBHelper.connString))
            {
                SqlBulkCopy bulkCopy = new SqlBulkCopy(conn);
                bulkCopy.DestinationTableName = "Warehouse_Inventory";
                bulkCopy.BatchSize = dt.Rows.Count;
                conn.Open();
                bulkCopy.WriteToServer(dt);
            }
            return 1;
        }
        /// <summary>
        /// 修改项目
        /// </summary>
        /// <param name="inventory">需修改项目</param>
        public int UpdateInventory(Warehouse_Inventory inventory)
        {
            string cmdText = @"UPDATE [EasySystem].[dbo].[Warehouse_Inventory]
   SET [WarehouseID] = @WarehouseID
      ,[GoodsID] = @GoodsID
      ,[Quantity] = @Quantity
      ,[MinStorage] = @MinStorage
 WHERE [InventoryID] = @InventoryID";

            SqlParameter[] parameters = new SqlParameter[5]
            {
                new SqlParameter("@WarehouseID",inventory.WarehouseID),
                new SqlParameter("@GoodsID",inventory.GoodsID),
                new SqlParameter("@Quantity",inventory.Quantity),
                new SqlParameter("@MinStorage",inventory.MinStorage),
                new SqlParameter("@InventoryID",inventory.InventoryID)
            };
            return DBHelper.ExecuteNonQuery(cmdText, parameters, CommandType.Text);
        }

        /// <summary>
        /// 获取项目列表
        /// </summary>
        public List<Warehouse_Inventory> GetInventoryList()
        {
            List<Warehouse_Inventory> Inventorys = null;
            string cmdText = "SELECT * FROM View_Warehouse_Inventory";
            using (SqlDataReader reader = DBHelper.ExecuteReader(cmdText, CommandType.Text))
            {
                if (reader.HasRows)
                {
                    Inventorys = new List<Warehouse_Inventory>();
                    while (reader.Read())
                    {
                        Warehouse_Inventory inventory = new Warehouse_Inventory()
                        {
                            InventoryID = Convert.ToInt32(reader["InventoryID"]),
                            WarehouseID = Convert.ToInt32(reader["WarehouseID"]),
                            WarehouseName = reader["WarehouseName"] as string,
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            MinStorage = Convert.ToInt32(reader["MinStorage"]),
                            GoodsID = Convert.ToInt32(reader["GoodsID"])
                        };
                        inventory.Goods = new Warehouse_Goods()
                        {
                            GoodsID = Convert.ToInt32(reader["GoodsID"]),
                            GoodsName = reader["GoodsName"] as string,
                            Specification = reader["Specification"] as string,
                            Unit = reader["Unit"] as string
                        };
                        Inventorys.Add(inventory);
                    }
                }
            }
            return Inventorys;
        }
        /// <summary>
        /// 获取项目列表
        /// </summary>
        /// <param name="InventoryName">项目名称</param>
        public void GetInventorys(string InventoryName)
        {

        }

    }
}
