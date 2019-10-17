using StudentSys.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.DAL
{
    public class ClassService:BaseService<Class>
    {
        public ClassService() : base(new StudentContext())
        {

        }

        public async Task ChangeName(Guid id, string clsname)
        {
            var cls = new Class() { Id = id };
            _db.Entry(cls).State = EntityState.Unchanged;
            cls.Name = clsname;
            await SaveAsync();
        }

        public async Task ChangeGrade(Guid id, Guid gradeId)
        {
            var cls = new Class() { Id = id };
            _db.Entry(cls).State = EntityState.Unchanged;
            cls.GradeId = gradeId;
            await SaveAsync();
        }

        public async Task ClassGraduation(Guid id)
        {
            var cls = new Class() { Id = id };
            _db.Entry(cls).State = EntityState.Unchanged;
            cls.IsGraduation = true;
            await SaveAsync();
        }
    }
}
