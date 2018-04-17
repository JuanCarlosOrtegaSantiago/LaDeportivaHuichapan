using LaDeportivaHuichapan.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaDeportivaHuichapan.COMMON.Interfaces
{
    public interface IManejadorGenerico<T> where T:Base
    {
        bool agregar(T entidad);
        List<T> listar { get; }
        bool Eliminar(string id);
        bool Modificar(T entidad);
        T buscarPorId(String id);
    }
}
