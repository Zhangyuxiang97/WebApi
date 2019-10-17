using StudentSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.DAL
{
    public class StudentService:BaseService<Student>
    {
        public StudentService() : base(new StudentContext())
        {

        }

        public async Task ChangeClass(Guid stuId, Guid clsId)
        {
            Student stu = new Student() { Id=stuId};
            stu.ClassId = clsId;
            await SaveAsync(false);
        }
    }
}
