using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Business_Task
    {
        [Key]
        public long TaskID { get; set; }

        [Required]
        public int ProjectID { get; set; }

        [Required]
        public int DepartmentID { get; set; }


        public DateTime? FinishDate { get; set; }

        [StringLength(10)]
        public string Contact { get; set; }


        public string CostSheetNo { get; set; }
        public string StampSheetNo { get; set; }
        public string HandoverSheetNo { get; set; }


        public Common_BusinessType BusinessType { get; set; }
        public decimal? TotalPrice { get; set; }

        [ForeignKey("ProjectID")]
        public Business_Project Project { get; set; }

        [ForeignKey("DepartmentID")]
        public Common_Department Department { get; set; }
        
        public ObservableCollection<Business_TaskItem> Items { get; set; }
        
    }
}
