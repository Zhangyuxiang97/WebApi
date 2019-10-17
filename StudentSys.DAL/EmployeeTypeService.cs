using StudentSys.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.DAL
{
    public class EmployeeTypeService : BaseService<EmployeeType>
    {
        public EmployeeTypeService() : base(new StudentContext())
        {

        }
        /// <summary>
        /// 保存员工类型
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task CreateEmployeeType(string name)
        {
            var empType = new EmployeeType()
            {
                Name = name
            };
            _db.Entry(empType).State = EntityState.Unchanged;
            empType.Name = name;
            await SaveAsync();
        }

    }
}
