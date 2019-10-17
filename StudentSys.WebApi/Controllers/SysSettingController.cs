using StudentSys.BLL;
using StudentSys.WebApi.Filters;
using StudentSys.WebApi.Models.SysSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace StudentSys.WebApi.Controllers
{
    //过滤器
    [MyAuth]
    //可以跨域
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/setting")]
    public class SysSettingController : ApiController
    {
        [HttpPost]
        [Route("createEmpType")]
        public async Task<IHttpActionResult> CreateEmpType(CreateEmployeeTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                await SystemManager.CreateEmployeeType(model.Name);
                return this.SendData("");
            }
            else
            {
                return this.ErrorData("数据有误");
            }
        }
    }
}
