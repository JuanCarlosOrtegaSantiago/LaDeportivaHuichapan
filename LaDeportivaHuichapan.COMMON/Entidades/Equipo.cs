using System;
using System.Collections.Generic;
using System.Text;

namespace LaDeportivaHuichapan.COMMON.Entidades
{
    public class Equipo:Base
    {
        public int CantidadDeJugadores { get; set; }
        public List<Jugador> jugadores { get; set; }
        public int Puntos { get; set; }
    }
}
