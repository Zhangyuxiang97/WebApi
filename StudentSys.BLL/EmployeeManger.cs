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
    public class EmployeeManger
    {
        /// <summary>
        /// 登录业务
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="pwd"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool Login(string mail, string pwd, out Guid userId)
        {
            using (var empSvc = new EmployeeService())
            {
                var emp = empSvc.GetAll(m => m.Email == mail && m.Password == pwd).
                     FirstOrDefaultAsync();
                emp.Wait();
                if (emp.Result == null)
                {
                    userId = Guid.Empty;
                    return false;
                }
                else
                {
                    userId = emp.Result.Id;
                    return true;
                }
            }
        }

        /// <summary>
        /// 创建职工
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pwd"></param>
        /// <param name="typeid"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static async Task CreateEmployee(string email, string pwd,
            Guid typeid, string phone = null)
        {
            using (var empSvc = new EmployeeService())
            {
                await empSvc.CreateAsync(new Employee()
                {
                    Email = email,
                    Password = pwd,
                    EmployeeTypeId = typeid,
                    Phone = phone
                });

            }
        }
    }
}
