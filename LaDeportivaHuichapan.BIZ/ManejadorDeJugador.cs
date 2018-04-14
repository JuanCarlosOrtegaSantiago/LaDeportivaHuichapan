using LaDeportivaHuichapan.COMMON.Entidades;
using LaDeportivaHuichapan.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaDeportivaHuichapan.BIZ
{
    public class ManejadorDeJugador : IManejadorDeJugador
    {
        IRepositorio<Jugador> repositorio;
        public ManejadorDeJugador(IRepositorio<Jugador> repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<Jugador> listar => repositorio.Leer;

        public bool agregar(Jugador entidad)
        {
            return repositorio.Cear(entidad);
        }

        public Jugador buscarPorId(string id)
        {
            return listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Eliminar(id);
        }

        public bool Modificar(Jugador entidad)
        {
            return repositorio.Editar(entidad);
        }
    }
}
