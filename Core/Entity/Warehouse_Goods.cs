using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Warehouse_Goods
    {
        /// <summary>
        /// ID
        /// </summary>
        public int GoodsID { get; set; }

        /// <summary>
        /// 货品名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string Specification { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        
        /// <summary>
        /// 类别ID
        /// </summary>
        public int CategoryID { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 默认供货商ID
        /// </summary>
        public int SupplierID { get; set; }

        /// <summary>
        /// 默认供货商名称
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// 默认单价
        /// </summary>
        public double UnitPrice { get; set; }

        public Warehouse_Goods Clone()
        {
            return this.MemberwiseClone() as Warehouse_Goods;
        }
    }
}
