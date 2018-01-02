using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Business_TaskListModel
    {
        public int TaskID { get; private set; }
        public DateTime? FinishDate { get; private set; }
        public string ProjectName { get; private set; }
        public string DepartmentName { get; private set; }
        public int A0 { get; private set; }
        public int A1 { get; private set; }
        public int A2 { get; private set; }
        public int A3 { get; private set; }
        public string CostSheetNo { get; private set; }
        public string StampSheetNo { get; private set; }
        public string HandoverSheetNo { get; private set; }
        public int BusinessType { get; private set; }

        public Business_TaskListModel(int taskID,DateTime? finishDate,string projectName,string departmentName,
            int a0,int a1,int a2,int a3,string costSheetNo,string stampSheetNo,string handoverSheetNo,int businessType)
        {
            this.TaskID = taskID;
            this.FinishDate = finishDate;
            this.ProjectName = projectName;
            this.DepartmentName = departmentName;
            this.A0 = a0;
            this.A1 = a1;
            this.A2 = a2;
            this.A3 = a3;
            this.CostSheetNo = costSheetNo;
            this.StampSheetNo = stampSheetNo;
            this.HandoverSheetNo = handoverSheetNo;
            this.BusinessType = businessType;
        }
    }
}
