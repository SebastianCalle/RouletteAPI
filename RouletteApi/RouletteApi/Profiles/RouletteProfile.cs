using AutoMapper;
using RouletteApi.Dtos;
using RouletteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteApi.Profiles
{
    public class RouletteProfile : Profile
    {
        public RouletteProfile()
        {
            CreateMap<Roulette, RouletteReadDto>();
        }
    }
}
