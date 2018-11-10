using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CityGame.Models;

namespace CityGame.Controllers
{
    public class CityGameController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            CityViewModel viewModel = new CityViewModel()
            {
                AnswerLog = Game.AnswerLog
            };
            return View(viewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CityViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Game.AddLog(new LogItem()
                {
                    CityName = viewModel.City.ToUpper(),
                    GamerName = viewModel.GamerName
                });
                return RedirectToAction("Index");
            }

            viewModel.AnswerLog = Game.AnswerLog;
            return View(viewModel);
        }
    }
}