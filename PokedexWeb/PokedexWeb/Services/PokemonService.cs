﻿using PokedexWeb.Data;
using PokedexWeb.Models;

namespace PokedexWeb.Services
{
    public class PokemonService
    {
        private readonly ConnectionDbContext _dbContext;

        public PokemonService(ConnectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<PokemonModel> GetPokemones()
        {
            return _dbContext.Pokemon_G7.ToList();
        }

        public bool AddPokemon(PokemonModel pokemon)
        {
            try
            {
                _dbContext.Pokemon_G7.Add(pokemon);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}