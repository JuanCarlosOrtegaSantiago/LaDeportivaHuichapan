using LaDeportivaHuichapan.COMMON.Entidades;
using LaDeportivaHuichapan.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaDeportivaHuichapan.BIZ
{
    public class ManejadorDeDeporte : IManejadorDeDeportes
    {
        IRepositorio<Deporte> repositorio;
        public ManejadorDeDeporte(IRepositorio<Deporte> repositorio)
        {
            this.repositorio = repositorio;
        }
        public List<Deporte> listar => repositorio.Leer;

        public bool agregar(Deporte entidad)
        {
            return repositorio.Cear(entidad);
        }

        public Deporte buscarPorId(string id)
        {
            return listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Eliminar(id);
        }

        public bool Modificar(Deporte entidad)
        {
            return repositorio.Editar(entidad);
        }
    }
}
