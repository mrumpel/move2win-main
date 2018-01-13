using LolaRenntFBServer;
using LolaRenntServer;
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

        public ActionResult RoomList()
        {
            FBService service = new FBService();
            List<Room> rooms = service.LoadRoomsByStatus(Status.Full);
            return View(rooms);
        }

        public ActionResult Room(string roomKey)
        {
            var room = new Room()
            {
                Bets = new BetItem[]
                {
                }
            };
            return View(room);
        }

        public ActionResult Bet(string roomKey)
        {
            return View();
        }
    }
}