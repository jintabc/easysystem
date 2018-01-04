using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Business_ServiceType
    {
        [Key]
        public int ServiceTypeID { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string ServiceTypeName { get; set; }
    }
}
