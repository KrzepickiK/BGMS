using AutoMapper;
using AutoMapper.QueryableExtensions;
using BGMS_Repository.DAL;
using BGMS_Repository.DTO;
using BGMS_Repository.Model;
using BGMS_Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGMS_Service.Services
{
    public class GameService : IGameService
    {
        private AppDbContext _db;
        private IMapper _mapper;
        public GameService(IMapper mapper, AppDbContext db)
        {
            this._mapper = mapper;
            this._db = db;
        }

        public async Task<GameDetailsDTO> GetGameDetailsAsync(int? id)
        {
            var gameDetails = await _db.Game
                .ProjectTo<GameDetailsDTO>(_mapper.ConfigurationProvider)
                .Where(g => g.Id == id)
                .FirstOrDefaultAsync();

            return gameDetails;
        }

        public async Task<GameListDTO> GetGamesListAsync(int? limit)
        {
            IQueryable<GameModel> dbGames = _db.Game.AsQueryable();

            if (limit.HasValue)
            {
                dbGames = dbGames.Take(limit.Value);
            }

            GameListDTO gamesList = new GameListDTO
            {
                Games = await dbGames
                .ProjectTo<GameDTO>(_mapper.ConfigurationProvider)
                .ToListAsync()
            };

            return gamesList;
        }

        public async Task<GameListDTO> GetGamesListAsync()
        {
            return await this.GetGamesListAsync(null);
        }


        public async Task<bool> DeleteGameAsync(int gameId)
        {
            try
            {
                var gameModel = _db.Game.Find(gameId);
                _db.Game.Remove(gameModel);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<int> AddNewGame(GameDTO newGame)
        {
            try
            {
                var gameModel = _mapper.Map<GameModel>(newGame);
                _db.Game.Add(gameModel);
                await _db.SaveChangesAsync();
                return gameModel.Id;
            }
            catch (Exception)
            {
                return 0;
            }
            
        }

        public async Task<GameDTO> UpdateGameDataAsync(GameDTO editedGame)
        {
            try
            {
                var gameModel = _db.Game.Find(editedGame.Id);
                _mapper.Map(editedGame, gameModel);
                await _db.SaveChangesAsync();
                return editedGame;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
