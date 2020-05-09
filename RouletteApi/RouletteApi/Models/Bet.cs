using System;
using System.Collections.Generic;

namespace RouletteApi.Models
{
    public partial class Bet
    {
        public int BetId { get; set; }
        public string Color { get; set; }
        public int? Number { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? RouletteId { get; set; }

        public virtual Roulette Roulette { get; set; }
    }
}
