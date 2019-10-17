using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.Model
{
    public class Student:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Sex { get; set; }
        public DateTime BornDate { get; set; }

        public string Phone { get; set; }
        public string QQ { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// 照片路径
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// 班级
        /// </summary>
        [ForeignKey(nameof(Class))]

        public Guid? ClassId { get; set; }
        /// <summary>
        /// 学生导航属性
        /// </summary>
        public Class Class { get; set; }
    }
}
