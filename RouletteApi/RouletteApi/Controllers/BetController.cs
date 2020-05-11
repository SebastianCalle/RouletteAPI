using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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

        //        // GET: api/Bets1
        //        [HttpGet]
        //        public async Task<ActionResult<IEnumerable<Bet>>> GetBet()
        //        {
        //            return await _context.Bet.ToListAsync();
        //        }
        //
        // GET: api/Bets1/5
        [HttpGet("{id}")]
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

        //        // PUT: api/Bets1/5
        //        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        //        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //        [HttpPut("{id}")]
        //        public async Task<IActionResult> PutBet(int id, Bet bet)
        //        {
        //            if (id != bet.BetId)
        //            {
        //                return BadRequest();
        //            }
        //
        //            _context.Entry(bet).State = EntityState.Modified;
        //
        //            try
        //            {
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!BetExists(id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //
        //            return NoContent();
        //        }
        //
        // POST: api/Bets1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<BetCreateDto> PostBet([FromBody] BetCreateDto betCreateDto)
        {
            if (ModelState.IsValid)
            {
                var betModel = _mapper.Map<Bet>(betCreateDto);
                _repository.CreateBet(betModel);
                _repository.SaveChanges();

                return NoContent();
            }
            return BadRequest();
        }
//
//        // DELETE: api/Bets1/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<Bet>> DeleteBet(int id)
//        {
//            var bet = await _context.Bet.FindAsync(id);
//            if (bet == null)
//            {
//                return NotFound();
//            }
//
//            _context.Bet.Remove(bet);
//            await _context.SaveChangesAsync();
//
//            return bet;
//        }
//
//        private bool BetExists(int id)
//        {
//            return _context.Bet.Any(e => e.BetId == id);
//        }
    }
}
