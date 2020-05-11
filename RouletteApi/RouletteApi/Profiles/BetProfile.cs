using AutoMapper;
using RouletteApi.Dtos;
using RouletteApi.Models;

namespace RouletteApi.Profiles
{
    public class BetProfile : Profile
    {
        public BetProfile()
        {
            // Source -> Destination
            CreateMap<Bet, BetReadDto>();
            CreateMap<BetCreateDto, Bet>();
        }
    }
}
