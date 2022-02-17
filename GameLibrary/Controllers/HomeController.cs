using GameLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GameLibrary.Data;

namespace GameLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IDataAccessLayer dal;

        public HomeController(ILogger<HomeController> logger, IDataAccessLayer indal)
        {
            _logger = logger;
            dal = indal;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoanedOutGame(int Id, string LoanGame)
        {
            var loan = dal.GetGame(Id);
           //Game game = dal.GameList.Find(x => x.Title == title);
            loan.LoanOutGame(LoanGame);

            return View("Collection", dal.GetGames());
        }

        public IActionResult ReturnLoanedGame(int Id)
        {
            var returnGame = dal.GetGame(Id);
            //Game game = dal.GameList.Find(x => x.Title == title);
            returnGame.ReturnLoanedGame();

            return View("Collection", dal.GetGames());
        }

        public IActionResult Collection()
        {
            return View(dal.GetGames().OrderBy(m => m.Title).ToList());
        }

       /* public IActionResult SearchGame(string search) {
            return View("collection", dal.SearchForGames(search));
        }

        public IActionResult FilterGames(string genre, string platform, string ersb) {
            return View("collection", dal.FilterCollection(genre, platform, ersb));
        }*/

        public IActionResult AddGames(string title, int year, string platform, string genre, string esrbrating) {
            if (!string.IsNullOrEmpty(title) && year > 0 && !string.IsNullOrEmpty(platform) && !string.IsNullOrEmpty(genre) && !string.IsNullOrEmpty(esrbrating)) {
                dal.AddGame(new Game(title, year, platform, genre, esrbrating));
                return View("collection", dal.GetGames());
            }
            return Content("Please try again");
        }

        public IActionResult AddGame(Game game) {
            if (ModelState.IsValid)
            {
                dal.AddGame(game);
                return Redirect("/Game/Index");
            }
            return View("Collection", game);
        }

        public IActionResult EditGame(int id) {

            Game g;
            g = dal.GetGame(id);
            ViewBag.Mode = "Edit";
            ViewBag.ID = id;
            return View("GameForm", g);
        }

        public IActionResult UpdateGame(Game game) {
            if (ModelState.IsValid)
            {
                dal.UpdateGame(game);
                return Redirect("/Game/Index");
            }
            return View("GameForm", game);
        }

        public IActionResult RemoveGame(int id)
        {
            dal.RemoveGame(id);
            return View("collection", dal.GetGames());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
