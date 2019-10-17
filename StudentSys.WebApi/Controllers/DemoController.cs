using StudentSys.WebApi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace StudentSys.WebApi.Controllers
{

    /*
     * 准备工作
     * EF引用设置连接串
     * Jwt引用（token值不可被修改，有用户ID账户）
     * Attribute特性用来过滤校验登录的合法性
     * 
     * 每一个控制器都要跨域处理Cors
     * 为Action编写viewModel用来校验提交数据的合法性/正则表达式校验
     * 为返回结果编写一个ResponseDate处理统一的返回数据
     */
    
    //可以跨域
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    //过滤器
    [MyAuth]
    public class DemoController : ApiController
    {
        //跳过过滤器
        [AllowAnonymous]
        public IHttpActionResult Login()
        {
            return Json(new { a = "a" });
        } 
         


        /// <summary>
        /// 报错调用ErrorData
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Error()
        {
            return this.ErrorData("找不到页面", 404);
        }
    }
}