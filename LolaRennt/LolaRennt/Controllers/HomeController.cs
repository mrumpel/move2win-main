﻿using LolaRenntServer;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LolaRennt.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FinishedRaces()
        {
            return View();
        }

        public ActionResult FinishedRace(string roomKey)
        {
            return View("FinishedRace", (object)roomKey);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Room(string roomKey)
        {
            return View();
        }

        public ActionResult Bet(string roomKey)
        {
            return View();
        }
    }
}