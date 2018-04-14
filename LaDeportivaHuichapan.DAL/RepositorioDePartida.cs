using LaDeportivaHuichapan.COMMON.Entidades;
using LaDeportivaHuichapan.COMMON.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaDeportivaHuichapan.DAL
{
    public class RepositorioDePartida:IRepositorio<Partida>
    {
        private string DBName = "Control.DB";
        private string TableName = "Partida";

        public List<Partida> Leer
        {
            get
            {
                List<Partida> datos = new List<Partida>();
                using (var db = new LiteDatabase(TableName))
                {
                    datos = db.GetCollection<Partida>(TableName).FindAll().ToList();
                }
                return datos;
            }
        }

        public bool Cear(Partida entidad)
        {
            try
            {
                entidad.Id = Guid.NewGuid().ToString();

                using (var db = new LiteDatabase(TableName))
                {
                    var coleccion = db.GetCollection<Partida>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Editar(Partida entidad)
        {
            try
            {
                using (var db = new LiteDatabase(TableName))
                {
                    var coleccion = db.GetCollection<Partida>(TableName);
                    coleccion.Update(entidad);
                }
                return true;
            }
            catch (Exception)
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
                    var coleccion = db.GetCollection<Partida>(TableName);
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
