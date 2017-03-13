using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LukeVo.Faith.Website.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet, Route(""), Route("Home")]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet, Route("SoF"), Route("StatementOfFaith")]
        public ActionResult StatementOfFaith()
        {
            return this.View();
        }
    }
}
