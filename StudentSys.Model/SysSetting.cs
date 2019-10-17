using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.Model
{
    /// <summary>
    /// 系统设置
    /// </summary>
    public class SysSetting:BaseEntity
    {
        /// <summary>
        /// 作业分值
        /// </summary>
        public int JobScore { get; set; }

        /// <summary>
        /// 上机完成率
        /// </summary>
        public int CompleteScore { get; set; }

        /// <summary>
        /// 成绩分值
        /// </summary>
        public int ExamScore { get; set; }

        /// <summary>
        /// 触发分值
        /// </summary>
        public int TriggerScore { get; set; }

    }
}
