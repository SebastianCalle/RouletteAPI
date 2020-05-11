using AutoMapper;
using RouletteApi.Dtos;
using RouletteApi.Models;

namespace RouletteApi.Profiles
{
    public class RouletteProfile : Profile
    {
        public RouletteProfile()
        {
            // Source -> Destination
            CreateMap<Roulette, RouletteReadDto>();
            CreateMap<RouletteCreateDto, Roulette>();
            CreateMap<RouletteUpdateDto, Roulette>();
            CreateMap<Roulette, RouletteUpdateDto>();
        }
    }
}
