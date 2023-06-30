using AutoMapper;
using Application.DTOs;
using Domain.Models;

namespace Application.Mapping
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {

            CreateMap<GameDto, Game>().ReverseMap();
            CreateMap<PlatformsDto, Platforms>().ReverseMap();
            CreateMap<TagsDto, Tags>().ReverseMap();
            CreateMap<ApiPagedResult<GameDto>, PagedResult<Game>>().ReverseMap();
            
        }
    }
}
