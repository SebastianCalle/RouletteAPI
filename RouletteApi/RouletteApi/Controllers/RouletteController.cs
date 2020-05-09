using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouletteApi.Data;
using RouletteApi.Dtos;
using RouletteApi.Models;

namespace RouletteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        // Dependency Injection 
        private readonly IRouletteRepository _repository;
        private readonly IMapper _mapper;

        public RouletteController(IRouletteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //GET api/roulette
        [HttpGet]
        public ActionResult<IEnumerable<RouletteReadDto>> GetRoulettes()
        {
            var roulettes = _repository.GetRoulettes();
            if (roulettes != null)
            {

                return Ok(_mapper.Map<IEnumerable<RouletteReadDto>>(roulettes));
            }
            return NotFound();

        }

        //GET api/roulette/{id}
        [HttpGet("{id}")]
        public ActionResult<RouletteReadDto> GetRouletteById(int id)
        {
            var roulette = _repository.GetRouletteById(id);
            if(roulette != null)
            {
                return Ok(_mapper.Map<RouletteReadDto>(roulette));
            }
            return NotFound();


        }
    }
}