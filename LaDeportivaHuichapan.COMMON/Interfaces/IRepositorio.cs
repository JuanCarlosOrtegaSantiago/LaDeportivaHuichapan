using LaDeportivaHuichapan.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaDeportivaHuichapan.COMMON.Interfaces
{
    public interface IRepositorio<T>where T:Base
    {
        bool Cear(T entidad);
        bool Editar(string id, T entidad);
        bool Eliminar(string id);
        List<T> Leer { get; }
    }
}
