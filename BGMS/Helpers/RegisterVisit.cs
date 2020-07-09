using BGMS_Repository.DTO;
using BGMS_Service.Services;
using BGMS_Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BGMS.Helpers
{
    public class RegisterVisit : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            //var statS = new StatisticService();
            //var x = new GameDisplayInformationDTO
            //{
            //    GameId = 1,
            //    DisplayTime = DateTime.Now,
            //    DisplaySource = "www application"
            //};
            //_ = Task.Run(() => statS.RegisterVisitAsync(x));
        }
    }
}