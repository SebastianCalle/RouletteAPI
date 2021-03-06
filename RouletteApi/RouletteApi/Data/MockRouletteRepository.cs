﻿using RouletteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RouletteApi.Data
{
    public class MockRouletteRepository : IRouletteRepository
    {
        private readonly RouletteApiContext _context;
        public MockRouletteRepository(RouletteApiContext context)
        {
            _context = context;
        }

        // Return the list of all Roulettes
        public IEnumerable<Roulette> GetRoulettes()
        {
            var roulettes = _context.Roulette.ToList();
            return roulettes;
        }

        // Return a specific Roulette by id
        public Roulette GetRouletteById(int id)
        {
            return _context.Roulette.FirstOrDefault(p => p.Id == id);
        }

        // Return true if save changes or false if not
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        // Craete roulette and add to database
        public void CreateRoulette(Roulette rlt)
        {
            if (rlt == null)
            {
                throw new ArgumentNullException(nameof(rlt));
            }

            _context.Roulette.Add(rlt);

        }

        // Update Roulette
        public void UpdateRoulette(Roulette rlt)
        {
            // Nothing
        }
    }
}
