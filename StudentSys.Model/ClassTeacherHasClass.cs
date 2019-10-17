using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.Model
{
    public class ClassTeacherHasClass : BaseEntity
    {
        /// <summary>
        /// 老师的ID
        /// </summary>
        [ForeignKey(nameof(Employee))]
        public Guid EmployeeId { get; set; }

        public Employee Employee { get; set; }

        /// <summary>
        /// 老师管理的班级ID
        /// </summary>
        [ForeignKey(nameof(Class))]
        public Guid ClassId { get; set; }

        public Class Class { get; set; }


    }
}
