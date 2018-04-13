using System;
using System.Collections.Generic;
using System.Text;

namespace LaDeportivaHuichapan.COMMON.Entidades
{
    public class Torneo:Base
    {
        public Deporte deporte { get; set; }
        public List<Equipo> equipos{ get; set; }
        public List<Partida> partidas { get; set; }
    }
}
