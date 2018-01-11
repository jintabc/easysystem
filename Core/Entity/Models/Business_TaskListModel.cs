using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    [Table("dbo.View_TaskListModel")]
    public class Business_TaskListModel
    {
        [Key]
        public long TaskID { get; set; }
        public DateTime? FinishDate { get; set; }
        public string ProjectName { get; set; }
        public string DepartmentName { get; set; }
        public int? A0 { get; set; }
        public int? A1 { get; set; }
        public int? A2 { get; set; }
        public int? A3 { get; set; }
        public string CostSheetNo { get; set; }
        public string StampSheetNo { get; set; }
        public string HandoverSheetNo { get; set; }
        public Common_BusinessType BusinessType { get; set; }

        public Business_TaskListModel() { }
        public Business_TaskListModel(long taskID,DateTime? finishDate,string projectName,string departmentName,
            int? a0,int? a1,int? a2,int? a3,string costSheetNo,string stampSheetNo,string handoverSheetNo, Common_BusinessType businessType)
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
