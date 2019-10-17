using StudentSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.DAL
{
    public class StudentLabCompleteService:BaseService<StudentLabComplete>
    {
        public StudentLabCompleteService() : base(new StudentContext())
        {
        }
    }
}
