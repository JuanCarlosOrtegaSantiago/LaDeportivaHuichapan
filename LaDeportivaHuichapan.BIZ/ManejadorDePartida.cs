using LaDeportivaHuichapan.COMMON.Entidades;
using LaDeportivaHuichapan.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaDeportivaHuichapan.BIZ
{
    public class ManejadorDePartida : IManejadorDePartida
    {
        IRepositorio<Partida> repositorio;
        public ManejadorDePartida(IRepositorio<Partida> repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<Partida> listar => repositorio.Leer;

        public bool agregar(Partida entidad)
        {
            return repositorio.Cear(entidad);
        }

        public bool AsignarPuntos(Equipo Equipo1, int Marcador1, Equipo Equipo2, int Marcador2)
        {
            try
            {
                if (Marcador1 > Marcador2)
                {
                    Equipo1.Puntos += 3;
                    Equipo2.Puntos += 1;
                }
                else if (Marcador1 < Marcador2)
                {
                    Equipo1.Puntos += 1;
                    Equipo2.Puntos += 3;
                }
                else
                {
                    Equipo1.Puntos += 2;
                    Equipo2.Puntos += 2;
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public Partida buscarPorId(string id)
        {
            return listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Eliminar(id);
        }

        public bool Modificar(Partida entidad)
        {
            return repositorio.Editar(entidad);
        }
    }
}
