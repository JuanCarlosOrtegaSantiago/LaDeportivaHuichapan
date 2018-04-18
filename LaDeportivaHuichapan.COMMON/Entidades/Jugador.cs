using System;
using System.Collections.Generic;
using System.Text;

namespace LaDeportivaHuichapan.COMMON.Entidades
{
    public class Jugador:Base
    {
        public char Sexo { get; set; }
        public string Puesto { get; set; }

        //public override string ToString()
        //{
        //    return string.Format("{0}", Nombre);
        //}
    }
}
