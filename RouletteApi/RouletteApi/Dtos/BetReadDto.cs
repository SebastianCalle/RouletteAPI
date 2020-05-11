using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteApi.Dtos
{
    public class BetReadDto
    {
        public int BetId { get; set; }
        public string Color { get; set; }
        public int? Number { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
