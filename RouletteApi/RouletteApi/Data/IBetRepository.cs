using RouletteApi.Models;
using System.Collections.Generic;

namespace RouletteApi.Data
{
    public interface IBetRepository
    {
        bool SaveChanges();
        IEnumerable<Bet> GetBets(int id);
        void CreateBet(Bet bt);
        object GetRouletteById(int id);
        void UpdateStatusRoulette(int id);
        bool StatusRoulette(int id);
    }
}
