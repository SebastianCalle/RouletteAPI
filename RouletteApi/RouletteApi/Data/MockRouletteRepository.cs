using RouletteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteApi.Data
{
    public class MockRouletteRepository : IRouletteRepository
    {
        private readonly RouletteApiContext _context;
        public MockRouletteRepository(RouletteApiContext context)
        {
            _context = context;
        }

        // Return the list of all Roulettes
        public IEnumerable<Roulette> GetRoulettes()
        {
            var roulettes = _context.Roulette.ToList();
            return roulettes;
        }

        // Return a specific Roulette by id
        public Roulette GetRouletteById(int id)
        {
            return _context.Roulette.FirstOrDefault(p => p.Id == id);
        }

    }
}
