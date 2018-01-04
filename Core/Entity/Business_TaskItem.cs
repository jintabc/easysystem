using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Business_TaskItem
    {
        [Key]
        public long TaskItemID { get; set; }

        [Required]
        public long TaskID { get; set; }

        [MaxLength(15)]
        public string ItemName { get; set; }

        [MaxLength(20)]
        public string Subject { get; set; }
        
        public int? A0 { get; set; }
        public int? A1 { get; set; }
        public int? A2 { get; set; }
        public int? A3 { get; set; }

        [Required]
        public int Copies { get; set; }
        public string Description { get; set; }

        [ForeignKey("TaskID")]
        public Business_Task Task { get; set; }

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
