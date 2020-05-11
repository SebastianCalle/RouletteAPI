using System;
using System.Collections.Generic;

namespace RouletteApi.Models
{
    public partial class Roulette
    {
        public Roulette()
        {
            Bet = new HashSet<Bet>();
        }

        public int Id { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Bet> Bet { get; set; }
    }
}
