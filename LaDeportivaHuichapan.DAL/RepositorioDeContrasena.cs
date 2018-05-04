using LaDeportivaHuichapan.COMMON.Entidades;
using LaDeportivaHuichapan.COMMON.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaDeportivaHuichapan.DAL
{
    public class RepositorioDeContrasena : IRepositorio<Contrasena>
    {
        private string DBName = "Control.DB";
        private string TableName = "Contrasena";
        public List<Contrasena> Leer
        {
            get
            {
                List<Contrasena> datos = new List<Contrasena>();
                using (var db = new LiteDatabase(TableName))
                {
                    datos = db.GetCollection<Contrasena>(TableName).FindAll().ToList();
                }
                return datos;
            }
        }
            

        public bool Cear(Contrasena entidad)
        {
            try
            {
                entidad.Id = Guid.NewGuid().ToString();

                using (var db = new LiteDatabase(TableName))
                {
                    var coleccion = db.GetCollection<Contrasena>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Editar(Contrasena entidad)
        {
            try
            {
                using (var db = new LiteDatabase(TableName))
                {
                    var coleccion = db.GetCollection<Contrasena>(TableName);
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
                    var coleccion = db.GetCollection<Contrasena>(TableName);
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
