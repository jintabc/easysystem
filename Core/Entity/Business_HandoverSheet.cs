using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Business_HandoverSheet
    {
        [Key]
        public string HandoverSheetID { get; set; }

        [Required]
        public int ProjectID { get; set; }

        [Required]
        public int DepartmentID { get; set; }

        public DateTime? HandoverDate { get; set; }
        public string Remarks { get; set; }

        [ForeignKey("ProjectID")]
        public Business_Project Project { get; set; }

        [ForeignKey("DepartmentID")]
        public Common_Department Department { get; set; }

        [InverseProperty("HandoverSheetID")]
        public List<Business_HandoverSheetItem> Items { get; set; }
    }
}
