using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.Model
{
    public class Class:BaseEntity
    {
        /// <summary>
        /// 班级姓名
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 是否毕业
        /// </summary>
        public bool IsGraduation { get; set; }

        /// <summary>
        /// 年级
        /// </summary>
        [ForeignKey(nameof(Grade))]
        public Guid GradeId { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public Grade Grade { get; set; }


    }
}
