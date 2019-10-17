using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.Model
{
    /// <summary>
    /// 学生毕业信息
    /// </summary>
    public class StudentGraduate:BaseEntity
    {
        [ForeignKey(nameof(Student))]
        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [Required]
        public string CopyName { get; set; }
        
        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime InTime { get; set; }

        /// <summary>
        /// 薪水
        /// </summary>
        [Required]
        public decimal Salary { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        [Required]
        public string Position { get; set; }

        public string Address { get; set; }
        
    }
}
