using AutoMapper;
using BGMS_Repository.DTO;
using BGMS_Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGMS_Repository.AutoMapperConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GameModel, GameDTO>();
            CreateMap<GameDTO, GameModel>();

            CreateMap<GameDetailsDTO, GameModel>();
            CreateMap<GameModel, GameDetailsDTO>()
                .ForMember(o => o.LastDisplays,
                           opt => opt.MapFrom<ICollection<GameDisplayinformationModel>>(
                               src => src.GameDisplays
                                .AsEnumerable()
                                .OrderByDescending(o=>o.DisplayTime)
                                .Take(10)
                                .ToList()));

            CreateMap<GameDisplayInformationDTO, GameDisplayinformationModel>();
            CreateMap<GameDisplayinformationModel, GameDisplayInformationDTO>();

        }
    }
}
