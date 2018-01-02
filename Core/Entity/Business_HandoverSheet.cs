using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Business_HandoverSheet
    {
        public string HandoverSheetID { get; set; }
        public Business_Project Project { get; set; }
        public Common_Department Department { get; set; }
        public DateTime HandoverDate { get; set; }
        public string Remarks { get; set; }

        public List<Business_HandoverSheetItem> Items { get; set; }
    }
}
