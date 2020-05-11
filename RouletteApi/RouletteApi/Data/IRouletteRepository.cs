using RouletteApi.Dtos;
using RouletteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteApi.Data
{
    public interface IRouletteRepository
    {
        bool SaveChanges();
        IEnumerable<Roulette> GetRoulettes();
        Roulette GetRouletteById(int Id);
        void CreateRoulette(Roulette rlt);
        void UpdateRoulette(Roulette rlt);

    }
}
