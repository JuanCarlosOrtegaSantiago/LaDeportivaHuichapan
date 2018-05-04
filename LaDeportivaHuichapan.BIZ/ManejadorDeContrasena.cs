using LaDeportivaHuichapan.COMMON.Entidades;
using LaDeportivaHuichapan.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaDeportivaHuichapan.BIZ
{
    public class ManejadorDeContrasena : IManejadorDeContrasena
    {
        IRepositorio<Contrasena> repositorio;
        public ManejadorDeContrasena(IRepositorio<Contrasena> repositorio)
        {
            this.repositorio = repositorio;
        }
        public List<Contrasena> listar => repositorio.Leer;

        public bool agregar(Contrasena entidad)
        {
            return repositorio.Cear(entidad);
        }

        public Contrasena buscarPorId(string id)
        {
            return listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Eliminar(id);
        }

        public bool Modificar(Contrasena entidad)
        {
            return repositorio.Editar(entidad);
        }
    }
}
