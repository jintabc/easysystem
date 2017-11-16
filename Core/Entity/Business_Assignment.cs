using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Business_Assignment
    {
        public long AssignmentID { get; set; }
        public Business_Project ProjectName { get; set; }
        public Common_Department Department { get; set; }
        public DateTime FinishTime { get; set; }
        public string Client { get; set; }
        public int MyProperty { get; set; }
    }
}
