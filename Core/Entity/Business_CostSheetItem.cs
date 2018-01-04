using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Business_CostSheetItem
    {
        [Key]
        public long CostSheetItemID { get; set; }

        [Required]
        public string CostSheetID { get; set; }

        public int ServiceTypeID { get; set; }

        public int PaperSizeID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int Copies { get; set; }

        public decimal UnitPrice { get; set; }

        public string Description { get; set; }

        [ForeignKey("CostSheetID")]
        public Business_CostSheet CostSheet { get; set; }
    }
}
