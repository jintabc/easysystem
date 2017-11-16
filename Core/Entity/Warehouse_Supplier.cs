using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Warehouse_Supplier
    {
        /// <summary>
        /// ID
        /// </summary>
        public int SupplierID { get; set; }

        /// <summary>
        /// 供货商名称
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }

        public Warehouse_Supplier Clone()
        {
            return this.MemberwiseClone() as Warehouse_Supplier;
        }
    }
}
