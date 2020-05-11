namespace RouletteApi.Dtos
{
    public class BetCreateDto
    {
        public int RouletteId { get; set; }
        public string Color { get; set; }
        public int? Number { get; set; }
        public int Amount { get; set; }
    }
}
