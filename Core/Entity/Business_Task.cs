using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Business_Task
    {
        public long TaskID { get; set; }
        public Business_Project Project { get; set; }
        public Common_Department Department { get; set; }
        public DateTime? FinishDate { get; set; }
        public string Contact { get; set; }
        public string CostSheetNo { get; set; }
        public string StampSheetNo { get; set; }
        public string HandoverSheetNo { get; set; }
        public Common_BusinessType BusinessType { get; set; }
        public decimal? TotalPrice { get; set; }
        
        public ObservableCollection<Business_TaskItem> Items { get; set; }
    }
}
