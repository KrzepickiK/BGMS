using BGMS_Repository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BGMS_Service.Services.Interfaces;
using BGMS_Service.Services;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Net;
using BGMS_Repository.Model;
using BGMS.Helpers;

namespace BGMS.Controllers
{
    public class GameController : Controller
    {
        private IGameService _gameS;
        private IStatisticService _statS;

        public GameController(IGameService gameS, IStatisticService statS)
        {
            this._gameS = gameS;
            this._statS = statS;
        }

        // GET: Game
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Board Games Management System";
            return View(await _gameS.GetGamesListAsync());
        }

        // GET: Game/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            GameDetailsDTO gameDto = await _gameS.GetGameDetailsAsync(id);

            if (gameDto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Title = gameDto.Name;

            await _statS.RegisterGameDetailsVisitAsync(id ?? 0, "www application");

            return View(gameDto);
        }

        // GET: Game/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Add new game";
            return View();
        }

        // POST: Game/Create
        [HttpPost]
        public async Task<ActionResult> Create(GameDTO newGame)
        {
            try
            {
                await _gameS.AddNewGame(newGame);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(newGame);
            }
        }

        // GET: Game/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            GameDetailsDTO gameDto = await _gameS.GetGameDetailsAsync(id);

            if (gameDto == null)
            {
                return HttpNotFound();
            }

            ViewBag.Title = $"Edit: {gameDto.Name}";

            return View(gameDto);
        }

        // POST: Game/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(GameDetailsDTO editedGame)
        {
            try
            {
                await _gameS.UpdateGameDataAsync(editedGame);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(editedGame);
            }
        }

        // GET: Game/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            GameDetailsDTO gameDto = await _gameS.GetGameDetailsAsync(id);

            if (gameDto == null)
            {
                return HttpNotFound();
            }

            ViewBag.Title = $"Delete {gameDto.Name}";

            return View(gameDto);
        }

        // POST: Game/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(GameDetailsDTO gameToDelete)
        {
            try
            {
                await _gameS.DeleteGameAsync(gameToDelete.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
