using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using EasySystem.Core.Entity;
using System.Data;

namespace EasySystem.Core.Controller
{
    public class GoodsController
    {
        /// <summary>
        /// 新增项目
        /// </summary>
        /// <param name="goods">待新增项目</param>
        public int AddGoods(Warehouse_Goods goods)
        {
            int result = 0;
            string cmdText = @"PROC_AddGoods";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@GoodsName",goods.GoodsName),
                new SqlParameter("@Specification",goods.Specification),
                new SqlParameter("@Unit",goods.Unit),
                new SqlParameter("@CategoryID",goods.CategoryID),
                new SqlParameter("@SupplierID",goods.SupplierID),
                new SqlParameter("@UnitPrice",goods.UnitPrice),
                new SqlParameter("@Result",DbType.Int32)
            };
            parameters[4].Direction = ParameterDirection.Output;
            DBHelper.ExecuteNonQuery(cmdText, parameters, CommandType.StoredProcedure);
            if (parameters[4].Value != null)
            {
                goods.GoodsID = Convert.ToInt32(parameters[4].Value);
                return 1;
            }
            return -1;
        }

        /// <summary>
        /// 修改项目
        /// </summary>
        /// <param name="goods">需修改项目</param>
        public int UpdateGoods(Warehouse_Goods goods)
        {
            string cmdText = @"UPDATE [EasySystem].[dbo].[Warehouse_Goods]
   SET [GoodsName] = @GoodsName
      ,[Specification] = @Specification
      ,[Unit] = @Unit
      ,[CategoryID] = @CategoryID
      ,[SupplierID] = @SupplierID
      ,[UnitPrice] = @UnitPrice
 WHERE [GoodsID] = @GoodsID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@GoodsName",goods.GoodsName),
                new SqlParameter("@Specification",goods.Specification),
                new SqlParameter("@Unit",goods.Unit),
                new SqlParameter("@CategoryID",goods.CategoryID),
                new SqlParameter("@SupplierID",goods.SupplierID),
                new SqlParameter("@UnitPrice",goods.UnitPrice),
                new SqlParameter("@GoodsID",goods.GoodsID)
            };
            return DBHelper.ExecuteNonQuery(cmdText, parameters, CommandType.Text);
        }

        /// <summary>
        /// 获取项目列表
        /// </summary>
        public List<Warehouse_Goods> GetGoods()
        {
            List<Warehouse_Goods> Goodss = null;
            string cmdText = "SELECT * FROM View_Warehouse_Goods";
            using (SqlDataReader reader = DBHelper.ExecuteReader(cmdText, CommandType.Text))
            {
                if (reader.HasRows)
                {
                    Goodss = new List<Warehouse_Goods>();
                    while (reader.Read())
                    {
                        Warehouse_Goods goods = new Warehouse_Goods()
                        {
                            GoodsID = Convert.ToInt32(reader["GoodsID"]),
                            GoodsName = reader["GoodsName"] as string,
                            Specification = reader["Specification"] as string,
                            Unit = reader["Unit"] as string,
                            CategoryID = Convert.ToInt32(reader["CategoryID"]),
                            CategoryName = reader["CategoryName"] as string,
                            SupplierID = Convert.ToInt32(reader["SupplierID"]),
                            SupplierName = reader["SupplierName"] as string,
                            UnitPrice = Convert.ToDouble(reader["UnitPrice"]),
                        };
                        Goodss.Add(goods);
                    }
                }
            }
            return Goodss;
        }
        /// <summary>
        /// 获取项目列表
        /// </summary>
        /// <param name="GoodsName">项目名称</param>
        public void GetGoods(string GoodsName)
        {

        }

    }
}
