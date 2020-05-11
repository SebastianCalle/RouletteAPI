using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RouletteApi.Data;
using RouletteApi.Dtos;
using RouletteApi.Models;
using System.Collections.Generic;

namespace RouletteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
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
        [HttpGet("{id}", Name = "GetRouletteById")]
        public ActionResult<RouletteReadDto> GetRouletteById(int id)
        {
            var roulette = _repository.GetRouletteById(id);
            if (roulette != null)
            {
                return Ok(_mapper.Map<RouletteReadDto>(roulette));
            }
            return NotFound();
        }

        // POST api/roulette
        [HttpPost]
        public ActionResult<RouletteReadDto> CreateRoulette(RouletteCreateDto rouletteCreateDto)
        {
            var rouletteModel = _mapper.Map<Roulette>(rouletteCreateDto);
            _repository.CreateRoulette(rouletteModel);
            _repository.SaveChanges();

            var rouletteReadDto = _mapper.Map<RouletteReadDto>(rouletteModel);

            return CreatedAtRoute(nameof(GetRouletteById), new { rouletteReadDto.Id }, rouletteReadDto);
        }

        // PATCH api/roulette/{id}
        [HttpPatch("{id}")]
        public ActionResult StatusRouletteUpdate(int id, JsonPatchDocument<RouletteUpdateDto> patchDoc)
        {
            var rouletteModel = _repository.GetRouletteById(id);
            if (rouletteModel == null)
            {
                return NotFound();
            }

            var rouletteToPatch = _mapper.Map<RouletteUpdateDto>(rouletteModel);
            patchDoc.ApplyTo(rouletteToPatch, ModelState);
            if (!TryValidateModel(rouletteToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(rouletteToPatch, rouletteModel);
            _repository.UpdateRoulette(rouletteModel);
            _repository.SaveChanges();

            return Ok();
        }
    }
}