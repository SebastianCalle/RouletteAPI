using RouletteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteApi.Data
{
    public interface IBetRepository
    {
        bool SaveChanges();
        IEnumerable<Bet> GetBets(int id);
        void CreateBet(Bet bt);
    }
}
