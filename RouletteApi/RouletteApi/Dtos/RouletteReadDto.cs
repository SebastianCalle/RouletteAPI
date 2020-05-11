using System;

namespace RouletteApi.Dtos
{
    // Dto for rolette when it's read
    public class RouletteReadDto
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
