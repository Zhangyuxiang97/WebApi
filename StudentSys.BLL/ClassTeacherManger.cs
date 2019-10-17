using StudentSys.DAL;
using StudentSys.Dto;
using StudentSys.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.BLL
{
    public class ClassTeacherManger
    {
        /// <summary>
        /// 创建班级
        /// </summary>
        /// <param name="clsName"></param>
        /// <param name="gradeid"></param>
        /// <returns></returns>
        public static async Task CreateClassAsync(string clsName,Guid gradeid)
        {
            using (var clsSvc=new ClassService())
            {
                await clsSvc.CreateAsync(new Class()
                {
                    GradeId = gradeid,
                    Name = clsName
                });
            }
        }

        /// <summary>
        /// 修改班级名称
        /// </summary>
        /// <param name="clsId"></param>
        /// <param name="clsName"></param>
        /// <returns></returns>
        public static async Task ChangeClassName(Guid clsId, string clsName)
        {
            using (var clsSvc = new ClassService())
            {
                await clsSvc.ChangeName(clsId, clsName);
            }
        }

        /// <summary>
        /// 升学
        /// </summary>
        /// <param name="clsId"></param>
        /// <returns></returns>
        public static async Task LeveUpClass(Guid clsId)
        {
            using (var clsSvc=new ClassService())
            {
                var cls = await clsSvc.GetOne(clsId);
                using (var gradeSvc=new GradeService())
                {
                    var grade = await gradeSvc.GetAll(m =>
                     m.Order > cls.Grade.Order).FirstOrDefaultAsync();
                    if (grade == null) { 
                        //如果没有年级了，升学
                        await Gtaduation(clsId);
                        return;
                    }

                    Guid gradeid = grade.Id;
                    await clsSvc.ChangeGrade(clsId, gradeid);
                }
            }
        }

        /// <summary>
        /// 毕业
        /// </summary>
        /// <param name="clsId"></param>
        /// <returns></returns>
        public static async Task Gtaduation(Guid clsId)
        {
            using (var clsSvc = new ClassService())
            {
                await clsSvc.ClassGraduation(clsId);
            }
        }

        /// <summary>
        /// 创建考试信息
        /// 需要班级时间科目
        /// </summary>
        /// <returns></returns>
        public static async Task CreateExam(Guid clsId,Guid subjectId,DateTime examTime)
        {
            using (var examSvc=new ExamService())
            {
                await examSvc.CreateAsync(new Exam()
                {
                    ClassId = clsId,
                    SubjectId = subjectId,
                    ExamTime = examTime
                });
            }
        }

        /// <summary>
        /// 通过班级Id获取学生的基本信息
        /// </summary>
        /// <param name="clsId"></param>
        /// <returns></returns>
        public static async Task<List<StudentExamDto>> GetStudentByClassId(Guid clsId)
        {
            using (var stuSvc=new StudentService())
            {
                return await stuSvc.GetAll(m => m.ClassId == clsId)
                    .Include(m => m.Class)
                    .Select(m => new StudentExamDto()
                    {
                        ClassId = m.ClassId.Value,
                        ClassName=m.Class.Name,
                        StudentId=m.Id,
                        Name=m.Name,
                        ImagePath=m.ImagePath
                    }).ToListAsync();
            }
        }

        /// <summary>
        /// 批量添加学生的科目成绩
        /// </summary>
        /// <param name="examId"></param>
        /// <param name="stuId"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public static async Task CreateExamScores(Guid examId,Dictionary<Guid,int> stuExamScores)
        {
            using (var scoreSvc=new ScoreService())
            {
                foreach (var stuExamScore in stuExamScores)
                {
                    await scoreSvc.CreateAsync(new Score()
                    {
                        ExamId = examId,
                        StudentId = stuExamScore.Key,
                        ExamScore = stuExamScore.Value
                    },false);
                }
                await scoreSvc.SaveAsync();
            }
        }

        /// <summary>
        /// 根据考试Id获取学生考试信息
        /// </summary>
        /// <param name="examId"></param>
        /// <returns></returns>
        public static async Task GetScoreByExamId(Guid examId)
        {
            using (var scoreSvc=new ScoreService())
            {
                await scoreSvc.GetAll(m => m.ExamId == examId)
                    .Include(m => m.Student.Class)
                    .Include(m => m.Exam.Subject)
                    .Select(m => new StudentScoreDto()
                    {
                        StudentId = m.Student.Id,
                        Name = m.Student.Name,
                        ImagePath = m.Student.ImagePath,
                        ScoreId = m.Id,
                        Score = m.ExamScore,
                        ExamId = m.ExamId,
                        ExamTime = m.Exam.ExamTime,
                        ClassId = m.Exam.ClassId,
                        ClassName = m.Student.Class.Name,
                        SubjectId = m.Exam.SubjectId,
                        SubjectName = m.Exam.Subject.Name
                    }).ToListAsync();
            }
        }

        /// <summary>
        /// 根据成绩ID修改成绩分数
        /// </summary>
        /// <param name="scoreId"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static async Task ChangeScore(Guid scoreId, int result)
        {
            using (var scoreSvc=new ScoreService())
            {
                await scoreSvc.ChangeScore(scoreId, result);
            }
        }

        /// <summary>
        /// 获取所有学生的签到信息
        /// </summary>
        /// <param name="clsId"></param>
        /// <returns></returns>
        public static async Task<List<StudentSignedDto>> GetStudentSigneds(Guid clsId)
        {
            using (var stuSignedSvc=new StudentSignedService())
            {
                return await stuSignedSvc.GetAll(m => m.ClassId == clsId)
                    .Include(m => m.Student.Class)
                    .Select(m => new StudentSignedDto()
                    {
                        ClassId = m.ClassId,
                        ClassName = m.Student.Class.Name,
                        ImagePath = m.Student.ImagePath,
                        StudentId = m.StudentId,
                        Name = m.Student.Name
                    }).ToListAsync();
            }
        }

        /// <summary>
        /// 创建签到
        /// </summary>
        /// <param name="clsId"></param>
        /// <param name="inTime"></param>
        /// <returns></returns>
        public static async Task CreateSigned(Guid clsId,DateTime? inTime=null)
        {
            var stus = await GetStudentSigneds(clsId);

            using (var stuSignedSvc= new StudentSignedService())
            {
                foreach (var studentSignedDto in stus)
                {
                    await stuSignedSvc.CreateAsync(new StudentSigned()
                    {
                        ClassId = clsId,
                        InTime = inTime == null ? DateTime.Now : inTime.Value,
                        SignedType = "正常",
                        StudentId = studentSignedDto.StudentId
                    }, false);
                }
                await stuSignedSvc.SaveAsync(false);
            }
        }

        /// <summary>
        /// 修改签到信息
        /// </summary>
        /// <param name="signId"></param>
        /// <param name="stateName"></param>
        /// <returns></returns>
        public static async Task CreateSigned(Guid signId,string stateName)
        {
            using (var signSvc=new StudentSignedService())
            {
                await signSvc.ChangeSignedType(signId, stateName);
            }
        }

        /// <summary>
        /// 签退
        /// </summary>
        /// <param name="signIds"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static async Task Signout(Guid[] signIds,DateTime? timeOut=null)
        {
            using (var stuSignSvc=new StudentSignedService())
            {
                await stuSignSvc.Signout(signIds, timeOut);
            }
        }

    }
}
