using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Business_Price
    {
        [Key]
        public int ServiceTypeID { get; set; }

        [Key]
        public int PaperSizeID { get; set; }

        [Key]
        public int BusinessTypeID { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("ServiceTypeID")]
        public Business_ServiceType ServiceType { get; set; }

        [ForeignKey("PaperSizeID")]
        public Common_PaperSize PaperSize { get; set; }
    }
}
