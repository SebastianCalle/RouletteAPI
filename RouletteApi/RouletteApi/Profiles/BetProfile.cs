using AutoMapper;
using RouletteApi.Dtos;
using RouletteApi.Models;

namespace RouletteApi.Profiles
{
    public class BetProfile : Profile
    {
        public BetProfile()
        {
            CreateMap<Bet, BetReadDto>();
            CreateMap<BetCreateDto, Bet>();
        }
    }
}
