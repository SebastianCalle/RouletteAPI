using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouletteApi.Data;
using RouletteApi.Dtos;
using RouletteApi.Models;
using System.Collections.Generic;

namespace RouletteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        private readonly IBetRepository _repository;
        private readonly IMapper _mapper;

        public BetController(IBetRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Show the gets created with the id of roulette
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return the list of bets</returns>
        [HttpGet("{id}", Name = "GetBets")]
        public ActionResult<IEnumerable<BetReadDto>> GetBets(int id)
        {
            var bets = _repository.GetBets(id);
            if (bets != null)
            {
                return Ok(_mapper.Map<IEnumerable<BetReadDto>>(bets));
            }
            return NotFound();
        }

        /// <summary>
        /// Create a bet if roulette is open
        /// </summary>
        /// <param name="betCreateDto"></param>
        /// <returns>Return the status of response </returns>
        [HttpPost]
        public ActionResult<BetCreateDto> PostBet([FromBody] BetCreateDto betCreateDto)
        {
            var rouletteModel = _repository.GetRouletteById(betCreateDto.RouletteId);
            var status = _repository.StatusRoulette(betCreateDto.RouletteId);
            if (rouletteModel == null || status == false)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var betModel = _mapper.Map<Bet>(betCreateDto);
                _repository.CreateBet(betModel);
                _repository.SaveChanges();

                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        /// Show all bets for id of roulette
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return the list of bets</returns>
        [HttpGet("close/{id}", Name = "CloseBet")]
        public ActionResult<IEnumerable<BetReadDto>> CloseBet(int id)
        {
            _repository.UpdateStatusRoulette(id);
            var bets = _repository.GetBets(id);
            if (bets != null)
            {
                return Ok(_mapper.Map<IEnumerable<BetReadDto>>(bets));
            }
            return NotFound();
        }
    }
}
