using LaDeportivaHuichapan.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaDeportivaHuichapan.COMMON.Interfaces
{
    public interface IManejadorDePartida:IManejadorGenerico<Partida>
    {
        void AsignarPuntos(Equipo Equipo1, int Marcador1, Equipo Equipo2, int Marcador2);
    }
}
