using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Business_CostSheet
    {
        [Key]
        public string CostSheetID { get; set; }

        [Required]
        public int ProjectID { get; set; }

        [Required]
        public int DepartmentID { get; set; }

        [Required]
        public string Contact { get; set; }

        public DateTime? FinishDate { get; set; }

        [ForeignKey("ProjectID")]
        public Business_Project Project { get; set; }

        [ForeignKey("DepartmentID")]
        public Common_Department Department { get; set; }
        
        public List<Business_CostSheetItem> Items { get; set; }
    }
}
