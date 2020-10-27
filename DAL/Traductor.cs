using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Traductor
    {
        Acceso _acceso;
        public Traductor()
        {
            _acceso = new Acceso();
        }
        public List<BE.Idioma> ObtenerIdiomas()
        {
            List<BE.Idioma> _idiomas = new List<BE.Idioma>();

            string query = "select * from idioma";

            var reader = _acceso.GetReader(query);

            while (reader.Read())
            {

                _idiomas.Add(
                new BE.Idioma()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Nombre = reader["nombre"].ToString(),
                    Default = bool.Parse(reader["es_default"].ToString())

                });
            }
            _acceso.CloseReader(reader);
            return _idiomas;
        }

        public Dictionary<string, BE.Traduccion> ObtenerTraducciones(BE.Idioma idioma)
        {
            Dictionary<string, BE.Traduccion> _traducciones = new Dictionary<string, BE.Traduccion>();

            string query = $@"select t.id_idioma, t.traduccion as traduccion_traduccion, e.id as id_etiqueta, e.nombre as nombre_etiqueta 
                            from traduccion t inner join etiqueta e on t.id_etiqueta=e.id
                            where t.id_idioma = {idioma.Id}";
            var reader = _acceso.GetReader(query);
          
            while (reader.Read())
            {
                var etiqueta = reader["nombre_etiqueta"].ToString();
                _traducciones.Add(etiqueta,
                new BE.Traduccion()
                {
                    Texto = reader["traduccion_traduccion"].ToString(),
                    Etiqueta = new BE.Etiqueta()
                    {
                        Id = int.Parse(reader["id_etiqueta"].ToString()),
                        Nombre = etiqueta
                    }

                });
            }
            _acceso.CloseReader(reader);
            return _traducciones;
        }
    }
}

