using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Business_HandoverSheetItem
    {
        [Key]
        public long HandoverSheetItemID { get; set; }

        [Required]
        public string HandoverSheetID { get; set; }

        [MaxLength(15)]
        public string ItemName { get; set; }

        [MaxLength(20)]
        public string Subject { get; set; }
        public int? A0 { get; set; }
        public int? A1 { get; set; }
        public int? A2 { get; set; }
        public int? A3 { get; set; }
        public string Description { get; set; }

        [ForeignKey("HandoverSheetID")]
        public Business_HandoverSheet HandoverSheet { get; set; }

        public Business_HandoverSheetItem(Business_TaskItem taskItem)
        {
            this.ItemName = taskItem.ItemName;
            this.Subject = taskItem.Subject;
            this.A0 = taskItem.A0;
            this.A1 = taskItem.A1;
            this.A2 = taskItem.A2;
            this.A3 = taskItem.A3;
            this.Description = taskItem.Description;
        }
    }
}
