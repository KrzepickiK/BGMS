using BGMS_Repository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGMS_Service.Services.Interfaces
{
    public interface IGameService
    {
        Task<GameListDTO> GetGamesListAsync();
        Task<GameListDTO> GetGamesListAsync(int? limit);
        Task<GameDetailsDTO> GetGameDetailsAsync(int? id);
        Task<GameDTO> UpdateGameDataAsync(GameDTO editedGame);
        Task<int> AddNewGame(GameDTO newGame);
        Task<bool> DeleteGameAsync(int gameId);
    }
}
