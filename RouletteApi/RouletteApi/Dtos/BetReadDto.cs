using System;

namespace RouletteApi.Dtos
{
    // Dto for bet when it's read
    public class BetReadDto
    {
        public int BetId { get; set; }
        public string Color { get; set; }
        public int? Number { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
