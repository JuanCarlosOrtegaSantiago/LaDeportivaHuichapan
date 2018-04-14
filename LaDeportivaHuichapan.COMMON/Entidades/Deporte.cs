using System;
using System.Collections.Generic;
using System.Text;

namespace LaDeportivaHuichapan.COMMON.Entidades
{
    public class Deporte:Base
    {
        public string LugarDeJuego { get; set; }
        public List<Equipo> Equipo { get; set; }
    }
}
