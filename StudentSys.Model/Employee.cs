using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.Model
{
    public class Employee:BaseEntity
    {
        /// <summary>
        /// 员工邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 员工信息类型
        /// </summary>
        [ForeignKey(nameof(EmployeeType))]
        public Guid EmployeeTypeId { get; set; }
        
        public EmployeeType EmployeeType { get; set; }



    }
}
