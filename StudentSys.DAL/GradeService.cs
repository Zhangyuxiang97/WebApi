using StudentSys.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.DAL
{
    public class GradeService : BaseService<Grade>
    {
        public GradeService() : base(new StudentContext())
        {

        }

        /// <summary>
        /// 年级序号
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <param name="isSaved"></param>
        /// <returns></returns>
        public async Task ChangeOrder(Guid id, int order,bool isSaved = true)
        {
            var grade = new Grade() { Id = id };
            _db.Entry(grade).State = EntityState.Unchanged;
            grade.Order = order;
            if (isSaved)
            {
                await SaveAsync();
            }
        }

        /// <summary>
        /// 修改年级名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task ChangeName(Guid id, string name)
        {
            var grade = new Grade() { Id = id };
            _db.Entry(grade).State = EntityState.Unchanged;
            grade.Name = name;
            await SaveAsync();

        }
    }
}
