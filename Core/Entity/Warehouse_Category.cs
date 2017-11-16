using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Warehouse_Category
    {
        /// <summary>
        /// ID
        /// </summary>
        public int CategoryID { get; set; }

        /// <summary>
        /// 货品类别
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 父类别ID
        /// </summary>
        public int ParentID { get; set; }

        /// <summary>
        /// 父类别
        /// </summary>
        public string ParentName { get; set; }

        public Warehouse_Category Clone()
        {
            return this.MemberwiseClone() as Warehouse_Category;
        }
    }
}
