using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LukeVo.Faith.MainWebsite.Controllers
{
    public class AppsController : Controller
    {

        [Route("daily-bible-verse")]
        public IActionResult DailyBibleVerse()
        {
            return this.View();
        }

    }
}