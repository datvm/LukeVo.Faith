using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LukeVo.Faith.MainWebsite.Models;
using LukeVo.Faith.MainWebsite.Models.BibleGatewayApi;

namespace LukeVo.Faith.MainWebsite.Controllers
{
    public class HomeController : Controller
    {

        [Route("")]
        public async Task<IActionResult> Index()
        {
            var service = this.HttpContext.RequestServices.GetService(typeof(BibleGatewayConnector)) as BibleGatewayConnector;
            var model = await service.GetVotDAsync("NIV");

            return this.View(model.votd);
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
