using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Common_Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Cellphone { get; set; }
        public string OfficePhone { get; set; }
        public string Title { get; set; }
        public int Index { get; set; }
        public Common_Department Department { get; set; }
    }
}
