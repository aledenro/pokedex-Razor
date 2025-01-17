﻿using System.ComponentModel.DataAnnotations;

namespace PokedexWeb.Models
{
    public class PokemonModel
    {
        [Key]
        public int id_pokemon { get; set; }
        public string nombre { get; set; }
        public int altura { get; set; }
        public int peso { get; set; }
        public string foto { get; set; }

        public ICollection<PokemonTipoModel> PokemonTipos { get; set; }
        public ICollection<PokemonHabilidadModel> PokemonHabilidades { get; set; }
        public ICollection<EnfermeriaModel> PokemonEnfermeria { get; set; }
        public ICollection<UsuarioPokemonModel> PokemonUsuario { get; set; }

    }
}
