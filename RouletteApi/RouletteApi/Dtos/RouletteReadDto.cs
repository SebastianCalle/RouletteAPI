using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteApi.Dtos
{
    public class RouletteReadDto
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
