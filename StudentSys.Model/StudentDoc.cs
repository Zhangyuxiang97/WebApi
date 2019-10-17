using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.Model
{
    /// <summary>
    /// 学生档案
    /// </summary>
    public class StudentDoc : BaseEntity
    {
        [ForeignKey(nameof(Student))]
        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        /// <summary>
        /// 内容描述
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImagePath { get; set; }

    }
}
