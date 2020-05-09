using RouletteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteApi.Data
{
    public class MockRouletteRepository : IRouletteRepository
    {
        public IEnumerable<Roulette> GetRoulettes()
        {
            var roulettes = new List<Roulette>
            {
                new Roulette { Id = 0, Status = true, CreatedAt= DateTime.Now },
                new Roulette { Id = 1, Status = false, CreatedAt = DateTime.Now },
                new Roulette { Id = 2, Status = true, CreatedAt = DateTime.Now },
                new Roulette { Id = 3, Status = false, CreatedAt = DateTime.Now }
            };

            return roulettes;
        }

        public Roulette GetRouletteById(int id)
        {

            return new Roulette { Id = 0, Status = true, CreatedAt= DateTime.Now };

        }

    }
}
