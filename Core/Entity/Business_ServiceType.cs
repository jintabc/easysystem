using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Business_ServiceType
    {
        public int ServiceTypeID { get; set; }
        public string Code { get; set; }
        public string ServiceTypeName { get; set; }
        public Common_PaperSize PaperSize { get; set; }
        public int InsidePrice { get; set; }
        public int OutsidePrice { get; set; }
    }
}
