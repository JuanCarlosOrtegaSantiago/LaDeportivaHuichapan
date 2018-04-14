using LaDeportivaHuichapan.COMMON.Entidades;
using LaDeportivaHuichapan.COMMON.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaDeportivaHuichapan.DAL
{
    public class RepositorioDeTorneo:IRepositorio<Torneo>
    {
        private string DBName = "Control.DB";
        private string TableName = "Torneo";

        public List<Torneo> Leer
        {
            get
            {
                List<Torneo> datos = new List<Torneo>();
                using (var db = new LiteDatabase(TableName))
                {
                    datos = db.GetCollection<Torneo>(TableName).FindAll().ToList();
                }
                return datos;
            }
        }

        public bool Cear(Torneo entidad)
        {
            try
            {
                entidad.Id = Guid.NewGuid().ToString();

                using (var db = new LiteDatabase(TableName))
                {
                    var coleccion = db.GetCollection<Torneo>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Editar(Torneo entidad)
        {
            try
            {
                using (var db = new LiteDatabase(TableName))
                {
                    var coleccion = db.GetCollection<Torneo>(TableName);
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
                    var coleccion = db.GetCollection<Torneo>(TableName);
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
