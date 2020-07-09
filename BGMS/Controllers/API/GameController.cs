using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BGMS.Helpers;
using BGMS_Repository.DAL;
using BGMS_Repository.DTO;
using BGMS_Repository.Model;
using BGMS_Service.Services.Interfaces;

namespace BGMS.Controllers.API
{
    public class GameController : ApiController
    {
        private IGameService _gameS;
        private IStatisticService _statS;

        public GameController(IGameService gameS, IStatisticService statS)
        {
            this._gameS = gameS;
            this._statS = statS;
        }

        // GET: api/Game/List/10
        /// <summary>
        /// Get games list with optional limit parameter
        /// </summary>
        /// <param name="limit">Maximum number of records to be returned (OPTIONAL)</param>
        /// <returns>Returns list of games limited by optional parameter (if param not set returns all data from database)</returns>
        [HttpGet]
        [Route("api/game/list/{limit:int?}")]
        public async Task<GameListDTO> GetGames(int? limit = null)
        {
            return await _gameS.GetGamesListAsync(limit);
        }

        // GET: api/Game/Details/5
        /// <summary>
        /// Get game data by Id
        /// </summary>
        /// <param name="id">The Id of the game</param>
        /// <returns>Returns detailed information about selected game</returns>
        [HttpGet]
        [Route("api/game/details/{id}")]
        [ResponseType(typeof(GameDetailsDTO))]
        public async Task<IHttpActionResult> GetGameModel(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            GameDetailsDTO gameDto = await _gameS.GetGameDetailsAsync(id);

            if (gameDto == null)
            {
                return NotFound();
            }

            await _statS.RegisterGameDetailsVisitAsync(id ?? 0, "webservice");

            return Ok(gameDto);
        }
    }
}