using AutoMapper;
using BGMS_Repository.DAL;
using BGMS_Repository.DTO;
using BGMS_Repository.Model;
using BGMS_Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGMS_Service.Services
{
    public class StatisticService : IStatisticService
    {
        private AppDbContext _db;
        private IMapper _mapper;
        public StatisticService(IMapper mapper, AppDbContext db)
        {
            this._mapper = mapper;
            this._db = db;
        }
        public async Task RegisterGameDetailsVisitAsync(int gameId, string source)
        {
            GameDisplayInformationDTO gdi = new GameDisplayInformationDTO
            {
                GameId = gameId,
                DisplayTime = DateTime.Now,
                DisplaySource = source
            };
            var gdiModel = _mapper.Map<GameDisplayinformationModel>(gdi);
            _db.GameDisplays.Add(gdiModel);
            await _db.SaveChangesAsync();
        }
    }
}
