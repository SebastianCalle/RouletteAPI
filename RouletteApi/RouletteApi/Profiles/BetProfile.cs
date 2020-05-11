using AutoMapper;
using RouletteApi.Dtos;
using RouletteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
