using System;
using System.Collections.Generic;
using System.Text;

namespace LaDeportivaHuichapan.COMMON.Entidades
{
    public class Partida:Base
    {
        public Equipo equipo1 { get; set; }
        public Equipo equipo2 { get; set; }
        public int MarcadorEqiopo1 { get; set; }
        public int MarcadorEqiopo2 { get; set; }
        public DateTime? FechaDePartida { get; set; }
    }
}
