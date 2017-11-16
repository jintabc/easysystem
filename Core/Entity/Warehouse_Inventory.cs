using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Warehouse_Inventory
    {
        /// <summary>
        /// ID
        /// </summary>
        public int InventoryID { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public int WarehouseID { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WarehouseName { get; set; }

        /// <summary>
        /// 货品ID
        /// </summary>
        public int GoodsID { get; set; }

        /// <summary>
        /// 货品名称
        /// </summary>
        public string GoodsName { get; set; }
           
        /// <summary>
        /// 存量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 缺货提醒
        /// </summary>
        public int MinStorage { get; set; }

        /// <summary>
        /// 关联货品
        /// </summary>
        public Warehouse_Goods Goods { get; set; }
    }
}
