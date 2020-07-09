using BGMS_Repository.DTO;
using BGMS_Service.Services;
using BGMS_Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BGMS.Helpers
{
    public class RegisterVisitApi : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //var x = new GameDisplayInformationDTO();
            //x.GameId = 1;
            //x.DisplayTime = DateTime.Now;
            //x.DisplaySource = "webservice ";
            //statS.RegisterVisitAsync(x).Wait();

            ////_ = Task.Run(() => statS.RegisterVisitAsync(x));
        }
    }
}