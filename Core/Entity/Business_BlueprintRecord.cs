using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Business_BlueprintRecord
    {
        public long ID { get; set; }
        public Business_Project Project { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
