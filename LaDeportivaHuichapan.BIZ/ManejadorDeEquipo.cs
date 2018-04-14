using LaDeportivaHuichapan.COMMON.Entidades;
using LaDeportivaHuichapan.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaDeportivaHuichapan.BIZ
{
    public class ManejadorDeEquipo : IManejadorDeEquipo
    {
        IRepositorio<Equipo> repositorio;
        public ManejadorDeEquipo(IRepositorio<Equipo> repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<Equipo> listar => repositorio.Leer;

        public bool agregar(Equipo entidad)
        {
            return repositorio.Cear(entidad);
        }

        public Equipo buscarPorId(string id)
        {
            return listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Eliminar(id);
        }

        public bool Modificar(Equipo entidad)
        {
            return repositorio.Editar(entidad);
        }
    }
}
