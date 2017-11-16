using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using EasySystem.Core.Entity;
using System.Data;

namespace EasySystem.Core.Controller
{
    public class SupplierController
    {
        /// <summary>
        /// 新增供货商
        /// </summary>
        /// <param name="Supplier">待新增供货商</param>
        public int AddSupplier(Warehouse_Supplier Supplier)
        {
            int result = 0;
            string cmdText = @"PROC_AddSupplier";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SupplierName",Supplier.SupplierName),
                new SqlParameter("@Contact",Supplier.Contact),
                new SqlParameter("@Phone",Supplier.Phone),
                new SqlParameter("@Result",DbType.Int32)
            };
            parameters[3].Direction = ParameterDirection.Output;
            DBHelper.ExecuteNonQuery(cmdText,parameters,CommandType.StoredProcedure);
            if (parameters[3].Value != null)
            {
                Supplier.SupplierID = Convert.ToInt32(parameters[3].Value);
                return 1;
            }
            return -1;
        }

        /// <summary>
        /// 修改供货商
        /// </summary>
        /// <param name="Supplier">需修改供货商</param>
        public int UpdateSupplier(Warehouse_Supplier Supplier)
        {
            string cmdText = @"UPDATE [EasySystem].[dbo].[Warehouse_Suppliers]
   SET [SupplierName] = @SupplierName
      ,[Contact] = @Contact
      ,[Phone] = @Phone
 WHERE [SupplierID] = @SupplierID";

            SqlParameter[] parameters = new SqlParameter[4]
            {
                new SqlParameter("@SupplierName",Supplier.SupplierName),
                new SqlParameter("@Contact",Supplier.Contact),
                new SqlParameter("@Phone",Supplier.Phone),
                new SqlParameter("@SupplierID",Supplier.SupplierID)
            };
            return DBHelper.ExecuteNonQuery(cmdText, parameters, CommandType.Text);
        }

        /// <summary>
        /// 获取供货商列表
        /// </summary>
        public List<Warehouse_Supplier> GetSuppliers()
        {
            List<Warehouse_Supplier> Suppliers = null;
            string cmdText = "SELECT * FROM Warehouse_Suppliers";
            using (SqlDataReader reader = DBHelper.ExecuteReader(cmdText,CommandType.Text))
            {
                if (reader.HasRows)
                {
                    Suppliers = new List<Warehouse_Supplier>();
                    while (reader.Read())
                    {
                        Warehouse_Supplier Supplier = new Warehouse_Supplier()
                        {
                            SupplierID = Convert.ToInt32(reader["SupplierID"]),
                            SupplierName = reader["SupplierName"] as string,
                            Contact = reader["Contact"] as string,
                            Phone = reader["Phone"] as string,
                        };
                        Suppliers.Add(Supplier);
                    }
                }
            }
            return Suppliers;
        }
        /// <summary>
        /// 获取供货商列表
        /// </summary>
        /// <param name="SupplierName">供货商名称</param>
        public void GetSuppliers(string SupplierName)
        {

        }

    }
}
