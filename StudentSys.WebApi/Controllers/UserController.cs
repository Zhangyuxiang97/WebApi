using StudentSys.BLL;
using StudentSys.WebApi.Filters;
using StudentSys.WebApi.Models.Users;
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
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        //跳过过滤器
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]        
        public IHttpActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //viewmodel校验合法性
                if (EmployeeManger.Login(model.LoginName, model.Password, out Guid userid))
                {
                    return this.SendData(JwtTools.Encoder(new Dictionary<string, object> {
                        { "username",model.LoginName},
                        { "userid",userid}
                    })
                        );
                }
                else
                {
                    return this.ErrorData("账号或密码错误");
                }
            }
            else
            {
                return this.ErrorData("您输入的数据不合法");
            }
        }

        [HttpPost]
        [Route("CreateEmp")]
        public async Task<IHttpActionResult> CreateEmp(CreateEmployeeLoginView model)
        {
            if (ModelState.IsValid)
            {
                await EmployeeManger.CreateEmployee(model.LoginName, model.PassWord, 
                    model.TypeId, model.Phone);
                return this.SendData("");
            }
            return this.ErrorData("您输入的数据有误");
        }
    }
}
