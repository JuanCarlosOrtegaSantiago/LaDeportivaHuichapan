using LaDeportivaHuichapan.COMMON.Entidades;
using LaDeportivaHuichapan.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaDeportivaHuichapan.DAL
{
    public class RepositorioDeJugador : IRepositorio<Jugador>
    {
        public List<Jugador> Leer => throw new NotImplementedException();

        public bool Cear(Jugador entidad)
        {
            throw new NotImplementedException();
        }

        public bool Editar(string id, Jugador entidad)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(string id)
        {
            throw new NotImplementedException();
        }
    }
}
