using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouletteApi.Data;
using RouletteApi.Dtos;
using RouletteApi.Models;

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
            //_context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetBets")]
        public ActionResult<IEnumerable<BetReadDto>> GetBets(int id)
        {
            //var bets = _context.Bet.Where(x => x.RouletteId.Equals(id));
            var bets = _repository.GetBets(id);
            if (bets != null)
            {
                return Ok(_mapper.Map<IEnumerable<BetReadDto>>(bets));
            }
            return NotFound();
        }


        // POST: api/bet
        [HttpPost]
        public ActionResult<BetCreateDto> PostBet([FromBody] BetCreateDto betCreateDto)
        {
            var rouletteModel = _repository.GetRouletteById(betCreateDto.RouletteId);
            if (rouletteModel == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var betModel = _mapper.Map<Bet>(betCreateDto);
                _repository.CreateBet(betModel);
                _repository.SaveChanges();

                return NoContent();
            }
            return BadRequest();
        }

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
