﻿using Microsoft.EntityFrameworkCore;
using PokedexWeb.Data;
using PokedexWeb.Models;

namespace PokedexWeb.Services
{
    public class EnfermeriaService
    {
        private readonly ConnectionDbContext _dbContext;

        public EnfermeriaService(ConnectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<EnfermeriaModel> GetEnfermeria()
        {
            return _dbContext.Enfermeria_G7.Include(e => e.Pokemon).Include(e => e.Entrenador).Include(e => e.Enfermero).ToList();
        }

        public bool Asignar(int id, int id_enfermero)
        {
            try
            {
                var detalle = _dbContext.Enfermeria_G7.Where(e => e.id_detalle_enfermeria == id).Single();

                if (detalle == null)
                {
                    return false;
                }

                detalle.id_enfermero = id_enfermero;
                detalle.estado = "Asignado";
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Liberar(int id)
        {
            try
            {
                var detalle = _dbContext.Enfermeria_G7.Where(e => e.id_detalle_enfermeria == id).Single();

                if (detalle == null)
                {
                    return false;
                }

                detalle.estado = "De Alta";
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