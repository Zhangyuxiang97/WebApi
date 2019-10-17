using StudentSys.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.DAL
{
    public class StudentSignedService:BaseService<StudentSigned>
    {
        public StudentSignedService() : base(new StudentContext())
        {
        }

        /// <summary>
        /// 修改签到信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public async Task ChangeSignedType(Guid id,string typeName)
        {
            var sign = new StudentSigned()
            {
                Id=id
            };
            _db.Entry(sign).State = EntityState.Unchanged;
            sign.SignedType = typeName;
            await SaveAsync(false);
        }

        /// <summary>
        /// 签退
        /// </summary>
        /// <param name="signIds"></param>
        /// <param name="outTime"></param>
        /// <returns></returns>
        public async Task Signout(Guid[] signIds,DateTime? outTime=null)
        {
            foreach (var signId in signIds)
            {
                var sign = new StudentSigned()
                {
                    Id = signId
                };
                _db.Entry(sign).State = EntityState.Unchanged;
                sign.OutTime = outTime==null? DateTime.Now:outTime;
            }
            await SaveAsync(false);
        }
    }
}
