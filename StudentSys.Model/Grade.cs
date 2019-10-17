using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.Model
{
    public class Grade:BaseEntity
    {
        /// <summary>
        /// 年级名称
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 序号 1 2 3 4
        /// </summary>
        public int Order { get; set; }
    }
}
