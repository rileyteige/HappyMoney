using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyMoney.Controllers
{
    public class BaseController : Controller
    {
		protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding)
		{
 			 return base.Json(data, contentType, JsonRequestBehavior.AllowGet);
		}
    }
}
