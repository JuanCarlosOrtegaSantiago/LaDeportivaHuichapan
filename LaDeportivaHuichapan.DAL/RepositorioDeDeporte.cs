using LaDeportivaHuichapan.COMMON.Entidades;
using LaDeportivaHuichapan.COMMON.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaDeportivaHuichapan.DAL
{
    public class RepositorioDeDeporte : IRepositorio<Deporte>
    {
        private string DBName = "Control.DB";
        private string TableName = "Deporte";

        public List<Deporte> Leer
        {
            get
            {
                List<Deporte> datos = new List<Deporte>();
                using (var db = new LiteDatabase(TableName))
                {
                    datos = db.GetCollection<Deporte>(TableName).FindAll().ToList();
                }
                return datos;
            }
        }

        public bool Cear(Deporte entidad)
        {
            try
            {
                entidad.Id = Guid.NewGuid().ToString();

                using (var db = new LiteDatabase(TableName))
                {
                    var coleccion = db.GetCollection<Deporte>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Editar(Deporte entidad)
        {
            try
            {
                using (var db = new LiteDatabase(TableName))
                {
                    var coleccion = db.GetCollection<Deporte>(TableName);
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
                    var coleccion = db.GetCollection<Deporte>(TableName);
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
