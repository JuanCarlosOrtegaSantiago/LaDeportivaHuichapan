﻿using LaDeportivaHuichapan.COMMON.Entidades;
using LaDeportivaHuichapan.COMMON.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaDeportivaHuichapan.DAL
{
    public class RepositorioDeJugador : IRepositorio<Jugador>
    {
        private string DBName = "Control.DB";
        private string TableName = "Jugador";

        public List<Jugador> Leer
        {
            get{
                List<Jugador> datos = new List<Jugador>();
                using (var db = new LiteDatabase(TableName))
                {
                    datos = db.GetCollection<Jugador>(TableName).FindAll().ToList();
                }
                return datos;
            }
        }

        public bool Cear(Jugador entidad)
        {
            try
            {
                entidad.Id = Guid.NewGuid().ToString();

                using (var db = new LiteDatabase(TableName))
                {
                    var coleccion = db.GetCollection<Jugador>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch(Exception)
            {

                return false;
            }
        }

        public bool Editar(Jugador entidad)
        {
            try
            {
                using (var db = new LiteDatabase(TableName))
                {
                    var coleccion = db.GetCollection<Jugador>(TableName);
                    coleccion.Update(entidad);
                }
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool Eliminar(string id)
        {
            try
            {
                int r;
                using (var db = new LiteDatabase(TableName))
                {
                    var coleccion = db.GetCollection<Jugador>(TableName);
                    r = coleccion.Delete(e => e.Id == id);
                }
                return r > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
