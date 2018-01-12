using EasySystem.Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Controllers
{
    public class HandoverSheetController
    {
        public List<Business_HandoverSheet> GetList()
        {
            return new List<Business_HandoverSheet>();
        }

        public int Add(Business_HandoverSheet business_HandoverSheet)
        {
            return 0;
        }

        public int Update(Business_HandoverSheet business_HandoverSheet)
        {
            return 0;
        }

        public Business_HandoverSheet Get(int sheetID)
        {
            Business_HandoverSheet sheet = new Business_HandoverSheet()
            {
                HandoverSheetID = "ssss",
                DepartmentID = 1,
                Project = new Business_Project()
                {
                    ProjectID = 1,
                    ProjectName = "asdkjflsadkfj",
                    ProjectLeader = "333",
                    Company = "ooo",
                    DesignNo = "asdf"
                },
            };
            return sheet;
        }
    }
}