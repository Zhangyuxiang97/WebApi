using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using StudentSys.WebApi.Models.Auth;

namespace StudentSys.WebApi.Filters
{
    public class MyAuthAttribute : Attribute, IAuthorizationFilter
    {
        public bool AllowMultiple { get; }

      
        public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext 
            actionContext, CancellationToken cancellationToken, 
            Func<Task<HttpResponseMessage>> continuation) 
        {
            //如果传过来的数据有AllowAnonymous，则跳过过滤器
            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Count>0)
                return await continuation();

            //获取request-->headers-->token
            IEnumerable<string> headers;
            if (actionContext.Request.Headers.TryGetValues("token", out headers))
            {
                var loginName = JwtTools.Decode(headers.First())["username"].ToString();
                var UserId = Guid.Parse(JwtTools.Decode(headers.First())["userid"].ToString());
                (actionContext.ControllerContext.Controller as ApiController).User = new ApplicationUser
                    (loginName, UserId);
                return await continuation();
            }

            return new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }
    }
}