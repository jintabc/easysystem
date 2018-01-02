using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Business_HandoverSheetItem
    {
        public long HandoverSheetItemID { get; set; }
        public string HandoverSheetID { get; set; }
        public string ItemName { get; set; }
        public string Subject { get; set; }
        public int? A0 { get; set; }
        public int? A1 { get; set; }
        public int? A2 { get; set; }
        public int? A3 { get; set; }
        public string Description { get; set; }

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
