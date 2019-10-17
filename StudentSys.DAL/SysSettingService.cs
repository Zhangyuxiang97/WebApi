using StudentSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.DAL
{
    public class SysSettingService:BaseService<SysSetting>
    {
        public SysSettingService() : base(new StudentContext())
        {
        }
    }
}
