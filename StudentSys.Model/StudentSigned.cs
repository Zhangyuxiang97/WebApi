using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.Model
{
    public class StudentSigned:BaseEntity
    {
        [ForeignKey(nameof(Student))]
        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        [ForeignKey(nameof(Class))]
        public Guid ClassId { get; set; }

        public Class Class { get; set; }

        public DateTime? InTime { get; set; }

        public DateTime? OutTime { get; set; }

        /// <summary>
        /// 签到类型 正常 未到 迟到
        /// </summary>
        public String SignedType { get; set; }


    }
}
