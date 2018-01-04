using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Business_StampSheet
    {
        [Key]
        public string StampSheetID { get; set; }

        public int ProjectID { get; set; }

        public int DepartmentID { get; set; }

        [Required]
        public DateTime StampDate { get; set; }
        public string Remarks { get; set; }

        [ForeignKey("ProjectID")]
        public Business_Project Project { get; set; }

        [ForeignKey("DepartmentID")]
        public Common_Department Department { get; set; }

        [InverseProperty("StampSheetID")]
        public List<Business_StampSheetItem> Items { get; set; }
    }
}
