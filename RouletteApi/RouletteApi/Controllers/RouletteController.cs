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

        /// <summary>
        /// Show the all roulettes creteds with his states
        /// </summary>
        /// <param name=""></param>
        /// <returns>Return the list of roulettes</returns>
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

        /// <summary>
        /// Show an specific roulette by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return the roulettes</returns>
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

        /// <summary>
        /// Create a new roulette
        /// </summary>
        /// <param name="rouletteCreateDto"></param>
        /// <returns>Return the dates of roulette created</returns>
        [HttpPost]
        public ActionResult<RouletteReadDto> CreateRoulette(RouletteCreateDto rouletteCreateDto)
        {
            var rouletteModel = _mapper.Map<Roulette>(rouletteCreateDto);
            _repository.CreateRoulette(rouletteModel);
            _repository.SaveChanges();

            var rouletteReadDto = _mapper.Map<RouletteReadDto>(rouletteModel);

            return CreatedAtRoute(nameof(GetRouletteById), new { rouletteReadDto.Id }, rouletteReadDto);
        }

        /// <summary>
        /// Update status of a roulette
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns>Return the status of response</returns>
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