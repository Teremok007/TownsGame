using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TownsGame.Controllers
{
    public class TownsGameController : Controller
    {
        // GET: TownsGame
        public ActionResult Index()
        {
            return View();
        }
    }
}