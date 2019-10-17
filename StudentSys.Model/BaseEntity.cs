using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.Model
{
    public class BaseEntity
    {
        /// <summary>
        /// 不会重复的Guid
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();
   
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool IsRemoved { get; set; }

    }
}
