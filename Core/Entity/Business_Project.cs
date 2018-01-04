using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EasySystem.Core.Entity
{
    public class Business_Project
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int ProjectID { get; set; }

        /// <summary>
        /// 设计号
        /// </summary>
        [MaxLength(15)]
        public string DesignNo { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string ProjectName { get; set; }

        /// <summary>
        /// 建设单位
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Company { get; set; }

        /// <summary>
        /// 项目负责人
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string ProjectLeader{ get; set; }

        public Business_Project Clone()
        {
            return this.MemberwiseClone() as Business_Project;
        }
    }
}
