using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RouletteApi.Data;
using RouletteApi.Models;

namespace RouletteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IRouletteRepository _repository;
        public RouletteController(IRouletteRepository repository)
        {
            _repository = repository;
        }
        //GET api/roulette
        [HttpGet]
        public ActionResult<IEnumerable<Roulette>> GetRoulettes()
        {
            var roulettes = _repository.GetRoulettes();

            return Ok(roulettes);
        }

        //GET api/roulette/{id}
        [HttpGet("{id}")]
        public ActionResult<Roulette> GetRouletteById(int id)
        {
            var roulette = _repository.GetRouletteById(id);

            return Ok(roulette);
        }
    }
}