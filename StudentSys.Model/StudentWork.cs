using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.Model
{
    /// <summary>
    /// 学生作业
    /// </summary>
    public class StudentWork:BaseEntity
    {
        [ForeignKey(nameof(Student))]
        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        [ForeignKey(nameof(Class))]
        public Guid ClassId { get; set; }

        public Class Class { get; set; }

        public DateTime Time { get; set; }

        public string State { get; set; }

        /// <summary>
        /// 评价
        /// </summary>
        public string Achievement { get; set; }

    }
}
