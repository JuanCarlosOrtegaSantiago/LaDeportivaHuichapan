using LaDeportivaHuichapan.COMMON.Entidades;
using LaDeportivaHuichapan.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaDeportivaHuichapan.BIZ
{
    public class ManejadorDeTorneo : IManejadorDeTorneo
    {
        IRepositorio<Torneo> repositorio;
        public ManejadorDeTorneo(IRepositorio<Torneo> repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<Torneo> listar => repositorio.Leer;

        public bool agregar(Torneo entidad)
        {
            return repositorio.Cear(entidad);
        }

        public Torneo buscarPorId(string id)
        {
            return listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Eliminar(id);
        }

        public bool Modificar(Torneo entidad)
        {
            return repositorio.Editar(entidad);
        }
    }
}
