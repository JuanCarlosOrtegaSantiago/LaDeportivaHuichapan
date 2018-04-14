using LaDeportivaHuichapan.COMMON.Entidades;
using LaDeportivaHuichapan.COMMON.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaDeportivaHuichapan.DAL
{
    public class RepositorioDeEquipo:IRepositorio<Equipo>
    {
        private string DBName = "Control.DB";
        private string TableName = "Equipo";

        public List<Equipo> Leer
        {
            get
            {
                List<Equipo> datos = new List<Equipo>();
                using (var db = new LiteDatabase(TableName))
                {
                    datos = db.GetCollection<Equipo>(TableName).FindAll().ToList();
                }
                return datos;
            }
        }

        public bool Cear(Equipo entidad)
        {
            try
            {
                entidad.Id = Guid.NewGuid().ToString();

                using (var db = new LiteDatabase(TableName))
                {
                    var coleccion = db.GetCollection<Equipo>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Editar(Equipo entidad)
        {
            try
            {
                using (var db = new LiteDatabase(TableName))
                {
                    var coleccion = db.GetCollection<Equipo>(TableName);
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
                    var coleccion = db.GetCollection<Equipo>(TableName);
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
