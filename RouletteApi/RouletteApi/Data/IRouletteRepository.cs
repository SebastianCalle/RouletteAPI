using RouletteApi.Models;
using System.Collections.Generic;

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
