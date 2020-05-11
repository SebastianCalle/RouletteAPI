using RouletteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RouletteApi.Data
{
    public class MockBetRepository : IBetRepository
    {
        private readonly RouletteApiContext _context;
        public MockBetRepository(RouletteApiContext context)
        {
            _context = context;
        }

        // Create bet and add to database
        public void CreateBet(Bet bet)
        {
            if (bet == null)
            {
                throw new ArgumentNullException(nameof(bet));
            }

            _context.Bet.Add(bet);
        }

        // Return the list of bets by Id of roulette
        public IEnumerable<Bet> GetBets(int id)
        {
            var bets = _context.Bet.Where(x => x.RouletteId.Equals(id));

            return bets;
        }

        // Return roulette by Id
        public object GetRouletteById(int id)
        {
            return _context.Roulette.FirstOrDefault(p => p.Id == id);
        }

        // Return True if save changes or False if not
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        // Update the status of a roulette to false 
        public void UpdateStatusRoulette(int id)
        {
            var roulette = _context.Roulette.FirstOrDefault(p => p.Id == id);
            if (roulette != null)
            {
                roulette.Status = false;
                _context.Roulette.Update(roulette);
                _context.SaveChanges();
            }
        }

        // Return the status of roulette filter by Id
        public bool StatusRoulette(int id)
        {
            var roulette = _context.Roulette.FirstOrDefault(p => p.Id == id);
            return roulette.Status;
        }
    }
}
