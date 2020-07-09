using BGMS_Repository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGMS_Service.Services.Interfaces
{
    public interface IStatisticService
    {
        Task RegisterGameDetailsVisitAsync(int gameId, string source);
    }
}
