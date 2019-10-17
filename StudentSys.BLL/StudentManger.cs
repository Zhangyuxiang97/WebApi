using StudentSys.DAL;
using StudentSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.BLL
{
    public class StudentManger
    {
        /// <summary>
        /// 添加学生信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sex"></param>
        /// <param name="bornDate"></param>
        /// <param name="classid"></param>
        /// <param name="phone"></param>
        /// <param name="qq"></param>
        /// <param name="email"></param>
        /// <param name="imagepath"></param>
        /// <returns></returns>
        public static async Task CreateStudentAsync(string name, string sex, DateTime bornDate,
            Guid? classid, string phone = null, string qq = null, string email = null,
            string imagepath=null)
        {
            using (StudentService stuSvc=new StudentService())
            {
                await stuSvc.CreateAsync(new Student()
                {
                    Name = name,
                    Sex = sex,
                    BornDate = bornDate,
                    ClassId = classid,
                    Email = email,
                    Phone = phone,
                    QQ = qq,
                    ImagePath = imagepath
                });
            }
        }

        /// <summary>
        /// 修改某个学生的班级
        /// </summary>
        /// <param name="stuId"></param>
        /// <param name="classId"></param>
        /// <returns></returns>
        public static async Task StudentChangeClass(Guid stuId, Guid classId)
        {
            using (StudentService stuSvc=new StudentService())
            {
                await stuSvc.ChangeClass(stuId, classId);
            }
        }
    }
}
