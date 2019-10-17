using StudentSys.DAL;
using StudentSys.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.BLL
{
    public class SystemManager
    {
        /// <summary>
        /// 创建员工类型
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static async Task CreateEmployeeType(string name)
        {
            using (var TypeSvc = new EmployeeTypeService())
            {
                await TypeSvc.CreateAsync(new EmployeeType()
                {
                    Name = name
                });
            }
        }

        /// <summary>
        /// 创建年级
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static async Task CreateGrade(string name)
        {
            using (var gradeSvc = new GradeService())
            {
                var maxOrder = await gradeSvc.GetAll().MaxAsync(m => m.Order);
                await gradeSvc.CreateAsync(new Grade()
                {
                    Name = name
                });
            }
        }

        /// <summary>
        /// 年级上移
        /// </summary>
        /// <param name="gradeid"></param>
        /// <returns></returns>
        public static async Task GradeUp(Guid gradeid)
        {
            using (var gradeSvc = new GradeService())
            {
                var grade = await gradeSvc.GetOne(gradeid);
                var beforeGrade = await gradeSvc.GetAll
                    (m=>m.Order<grade.Order).FirstOrDefaultAsync();
                if (beforeGrade == null) return;
                await gradeSvc.ChangeOrder(gradeid, beforeGrade.Order, false);
                await gradeSvc.ChangeOrder(beforeGrade.Id, grade.Order);
            }
        }

        /// <summary>
        /// 年级下移
        /// </summary>
        /// <param name="gradeid"></param>
        /// <returns></returns>
        public static async Task GradeDown(Guid gradeid)
        {
            using (var gradeSvc = new GradeService())
            {
                var grade = await gradeSvc.GetOne(gradeid);
                var beforeGrade = await gradeSvc.GetAll
                    (m => m.Order > grade.Order).FirstOrDefaultAsync();
                if (beforeGrade == null) return;
                await gradeSvc.ChangeOrder(gradeid, beforeGrade.Order, false);
                await gradeSvc.ChangeOrder(beforeGrade.Id, grade.Order);
            }
        }

        /// <summary>
        /// 修改年级名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static async Task ChangeName(Guid id, string name)
        {
            using (var gradeSvc=new GradeService())
            {
                await gradeSvc.ChangeName(id,name);
            }
        }

        /// <summary>
        /// 创建科目
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="gradeId"></param>
        /// <returns></returns>
        public static async Task CreateSubject(string Name, Guid gradeId)
        {
            using (var subSvc = new SubjectService())
            {
                await subSvc.CreateAsync(new Subject()
                {
                    Name = Name,
                    GradeId = gradeId
                });
            }
        }

        /// <summary>
        /// 修改科目全部内容
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gradeid"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static async Task EditSubJect(Guid id,Guid gradeid,string name)
        {
            using (var subSvc = new SubjectService())
            {
                await subSvc.EditAsvnc(new Subject()
                {
                    Id = id,
                    Name = name,
                    GradeId = gradeid
                });
            }
        }

        /// <summary>
        /// 修改科目名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static async Task EditSubJectName(Guid id, string name)
        {
            using (var subSvc=new SubjectService())
            {
                await subSvc.EditName(id, name);
            }
        }

    }
}
