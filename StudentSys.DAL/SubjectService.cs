using StudentSys.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.DAL
{
    public class SubjectService:BaseService<Subject>
    {
        public SubjectService() : base(new StudentContext())
        {
        }

        /// <summary>
        /// 编辑科目姓名
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task EditName(Guid id, string name)
        {
            var sub = new Subject()
            {
                Id = id
            };
            _db.Entry(sub).State = EntityState.Unchanged;
            sub.Name = name;
            await SaveAsync();
        }
    }
}
