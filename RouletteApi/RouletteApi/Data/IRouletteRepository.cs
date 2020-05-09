using RouletteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteApi.Data
{
    public interface IRouletteRepository
    {
        IEnumerable<Roulette> GetRoulettes();
        Roulette GetRouletteById(int i);
    }
}
