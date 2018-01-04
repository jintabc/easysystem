using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Common_PaperSize
    {
        [Key]
        public int PaperSizeID { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public string PaperSizeName { get; set; }
        public string Description { get; set; }
    }
}
