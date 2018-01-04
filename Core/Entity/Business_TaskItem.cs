using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Business_TaskItem
    {
        public long TaskItemID { get; set; }
        public Business_Task Task { get; set; }
        public string ItemName { get; set; }
        public string Subject { get; set; }
        public int? A0 { get; set; }
        public int? A1 { get; set; }
        public int? A2 { get; set; }
        public int? A3 { get; set; }
        public int Copies { get; set; }
        public string Description { get; set; }

        public Business_TaskItem()
        {
            this.TaskItemID = -1;
        }

        public Business_TaskItem Clone()
        {
            return (Business_TaskItem)this.MemberwiseClone();
        }
    }
}
